using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Business_Entities;
using Abstraction_Layer;
using Automate_Layer;

namespace Data_Access_Layer
{
    public class Xml_Database
    {
        private XDocument doc = new XDocument();
        private bool ExisteBD()
        {
            if (File.Exists(ReferenciasBD.BaseDatosRestaurant))
            {
                return true;
            }
            else
            {
               return CrearArchivo(); 
            }
        }
        private void AbrirConexion()
        {
            doc = XDocument.Load(ReferenciasBD.BaseDatosRestaurant);
        }
        private void CerrarConexion()
        {
            doc.Save(ReferenciasBD.BaseDatosRestaurant);
            doc = null;
            GC.Collect();
        }
        private void CancelarConexion()
        {
            doc = null;
            GC.Collect();
        }
        public bool Escribir(List<BE_TuplaXML> datos)
        {
            AbrirConexion();
            try
            {
                foreach (BE_TuplaXML tupla in datos)
                {
                    XElement nodoPadre = doc.Root.Element(tupla.NodoRoot);
                    if (nodoPadre == null)
                    {
                        doc.Root.Add(tupla.NodoRoot);
                        nodoPadre = doc.Root.Element(tupla.NodoRoot);
                    }
                    if (Convert.ToInt32(tupla.Xelement.Element("ID").Value) == 0)
                    {
                        AutogenerarID(tupla);
                    }
                    nodoPadre.Add(tupla.Xelement);

                }
                CerrarConexion();
                return true;
            }
            catch (Exception ex)
            {
                CancelarConexion();
                return false;
                throw ex;
            }
        }

        public bool Borrar(List<BE_TuplaXML> datos)
        {
            AbrirConexion();
            try
            {
                foreach (BE_TuplaXML tupla in datos)
                {
                    IEnumerable<XElement> borrarObjeto = doc.Root.Element(tupla.NodoRoot).Descendants(tupla.NodoLeaf);
                    borrarObjeto
                            .Where(n => n.Element("ID") == tupla.Xelement.Element("ID"))
                            .Remove();
                }
                CerrarConexion();
                return true;
            }   
            catch (Exception ex)
            {
                CancelarConexion();
                return false;
                throw ex;
            }
        }

        public bool Modificar(List<BE_TuplaXML> datos)
        {
            AbrirConexion();
            try
            {
                foreach (BE_TuplaXML tupla in datos)
                {
                    XElement modificarObjeto = doc.Root.Element(tupla.NodoRoot).Descendants(tupla.NodoLeaf)
                                        .Where(n => n.Element("ID").Value == tupla.Xelement.Element("ID").Value)
                                        .FirstOrDefault();
                    foreach (XElement dato in modificarObjeto.Elements())
                    {
                        dato.Value = tupla.Xelement.Element(dato.Name).Value;
                    }
                }
                CerrarConexion();
                return true;
            }
            catch (Exception ex)
            {
                CancelarConexion();
                return false;
                throw ex;
            }
        }

        public DataSet Listar()
        {
            if (!ExisteBD())
            {
                throw new FileNotFoundException("La base de datos es inexsitente");
            }
            DataSet ds = new DataSet();
            ds.ReadXml(ReferenciasBD.BaseDatosRestaurant, XmlReadMode.Auto);
            return ds;
        }

        public bool CrearCalendario(List<BE_TuplaXML> datos)
        {
            AbrirConexion();
            try
            {
                foreach (BE_TuplaXML tupla in datos)
                {
                    XElement nodoPadre = doc.Root.Element(tupla.NodoLeaf);
                    nodoPadre.Add(tupla.Xelement);
                }
                CerrarConexion();
                return true;
            }
            catch (Exception ex)
            {
                CancelarConexion();
                return false;
                throw ex;
            }
        }

        public bool CrearArchivo()
        {
            try
            {
                XDocument Restaurant = new XDocument();
                XElement Root = new XElement(ReferenciasBD.Root);
                XElement Leaf = new XElement("Logins");
                Leaf.Add(CrearAdmin());
                Root.Add(Leaf);
                foreach(string hoja in ReferenciasBD.ArmaBD)
                {
                    Leaf = new XElement(hoja);
                    Root.Add(Leaf);
                }
                Restaurant.Add(Root);
                Restaurant.Save(ReferenciasBD.BaseDatosRestaurant);
                return true;
            }
            catch(Exception ex)
            {
                return false;
                throw ex;
            }
            
        }

        public XElement CrearAdmin()
        {
            XElement Admin = new XElement("Login",
                new XElement("ID", "0001"),
                new XElement("ID_Empleado", ""),
                new XElement("Usuario", "admin"),
                new XElement("Password", "ys/ihoA4NkE="),
                new XElement("Cantidad_Intentos", 0),
                new XElement("Permiso", ""),
                new XElement("Activo",true.ToString()),
                new XElement("Bloqueado", false.ToString())
                );
            return Admin;
        }

        private void AutogenerarID(BE_TuplaXML tupla)
        {

            int ID = doc.Root.Element(tupla.NodoRoot).Descendants(tupla.NodoLeaf)
                     .Select(x => Convert.ToInt32(x.Element("ID")?.Value ?? "0001"))
                     .Max();

            ID += 1;
            tupla.Xelement.Element("ID").Value = Cálculos.IDPadleft(ID);
                
        }



    }
}
