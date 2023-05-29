using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Business_Entities;

namespace Data_Access_Layer
{
    public class Xml_Database
    {
        XDocument doc = new XDocument();

        private void AbrirConexion()
        {
            doc = XDocument.Load("Restaurant.xml");
        }

        private void CerrarConexion()
        {
            doc.Save("Restaurant.xml");
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
            DataSet ds = new DataSet();
            ds.ReadXml("Restaurant.xml");
            return ds;
        }
    }
}
