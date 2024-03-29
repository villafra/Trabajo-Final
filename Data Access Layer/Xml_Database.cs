﻿using System;
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
        private static Xml_Database _acceso = null;
        private XDocument doc = new XDocument();

        public static Xml_Database DevolverInstancia()
        {
            if (_acceso == null) _acceso = new Xml_Database();
            return _acceso;
        }
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
                string CodigoNuevo = null;
                foreach (BE_TuplaXML tupla in datos)
                {
                    XElement nodoPadre = doc.Root.Element(tupla.NodoRoot);
                    
                    if (nodoPadre == null)
                    {
                        doc.Root.Add( new XElement(tupla.NodoRoot));
                        CerrarConexion();
                        AbrirConexion();
                        nodoPadre = doc.Root.Element(tupla.NodoRoot);

                    }
                    if (tupla.Xelement.Elements("ID").Any() != false ? Convert.ToInt32(tupla.Xelement.Element("ID").Value) == 0:false)
                    {
                        AutogenerarID(tupla);
                    }
                    else
                    {
                        tupla.Xelement.Elements().FirstOrDefault(x => x.Value == "0").Value = CodigoNuevo;
                    }
                    CodigoNuevo = tupla.Xelement.Elements("ID").Any() != false ? tupla.Xelement.Element("ID").Value: "";
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

        public bool Baja (List<BE_TuplaXML> datos)
        {
            AbrirConexion();
            try
            {
                foreach (BE_TuplaXML tupla in datos)
                {
                    XElement modificarObjeto = doc.Root.Element(tupla.NodoRoot).Descendants(tupla.NodoLeaf)
                                        .Where(n => n.Element("ID").Value == tupla.Xelement.Element("ID").Value)
                                        .FirstOrDefault();
                    modificarObjeto.Element("Activo").Value = false.ToString();
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
                    XElement borrarObjeto = doc.Root.Element(tupla.NodoRoot).Descendants(tupla.NodoLeaf)
                                                            .Where(n => n.Element("ID").Value == tupla.Xelement.Element("ID").Value)
                                                            .FirstOrDefault();
                    borrarObjeto.Remove();
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

        public bool ModificarMatLot(List<BE_TuplaXML> datos)
        {
            AbrirConexion();
            try
            {
                foreach (BE_TuplaXML tupla in datos)
                {
                    XElement modificarObjeto = doc.Root.Element(tupla.NodoRoot).Descendants(tupla.NodoLeaf)
                                        .Where(n => n.Element("ID_Ingrediente").Value == tupla.Xelement.Element("ID_Ingrediente").Value
                                        && n.Element("Lote").Value == tupla.Xelement.Element("Lote").Value)
                                        .FirstOrDefault();
                    foreach (XElement dato in modificarObjeto.Elements())
                    {
                        dato.Value = dato.Name != "Stock" ? tupla.Xelement.Element(dato.Name).Value: (Convert.ToDecimal(dato.Value) + Convert.ToDecimal(tupla.Xelement.Element(dato.Name).Value)).ToString();
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
                throw new FileNotFoundException("La base de datos es inexistente");
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
                Leaf.Add(ReferenciasBD.CrearAdmin);
                Root.Add(Leaf);
                Leaf = new XElement("Permisos");
                foreach (XElement perm in ReferenciasBD.ArmarPermisos)
                {
                    Leaf.Add(perm);
                }
                Root.Add(Leaf);
                Leaf = new XElement("Padres-Hijos");
                foreach (XElement ph in ReferenciasBD.ArmaPadreHijo)
                {
                    Leaf.Add(ph);
                }
                Root.Add(Leaf);
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
        public bool Existe (BE_TuplaXML tupla, string element)
        {
            AbrirConexion();
            bool existe;
            try
            {
                return existe = doc.Root.Element(tupla.NodoRoot) != null ? !doc.Root.Element(tupla.NodoRoot).Descendants(tupla.NodoLeaf)
                                .Any(x => x.Element(element).Value == tupla.Xelement.Element(element).Value):true;
            }
            catch (Exception ex)
            {
                return true;
                throw ex;
            }
            finally { CancelarConexion(); }
        }
        public bool ExisteMatLot(BE_TuplaXML tupla)
        {
            AbrirConexion();
            bool existe;
            try
            {
                return existe = doc.Root.Element(tupla.NodoRoot) != null ? doc.Root.Element(tupla.NodoRoot).Descendants(tupla.NodoLeaf)
                                .Any(x => x.Element("ID_Ingrediente").Value == tupla.Xelement.Element("ID_Ingrediente").Value
                                && x.Element("Lote").Value == tupla.Xelement.Element("Lote").Value):false;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            finally
            {
                CancelarConexion();
            }
        }
        public XElement DevolverInactivo(BE_TuplaXML tupla, string element)
        {
            AbrirConexion();
            XElement encontrado = doc.Root.Element(tupla.NodoRoot).Descendants(tupla.NodoLeaf)
                                  .FirstOrDefault(x => x.Element(element)?.Value == tupla.Xelement.Element(element)?.Value);
            return encontrado;

        }
        public void AutogenerarID(BE_TuplaXML tupla)
        {
            int ID;
            try
            {
                if (tupla.NodoRoot != "Empleados")
                {
                    ID = doc.Root.Element(tupla.NodoRoot).Descendants(tupla.NodoLeaf)
                                             .Select(x => Convert.ToInt32(x.Element("ID")?.Value ?? "0001"))
                                             .Max();
                }
                else
                {
                    ID = doc.Root.Element(tupla.NodoRoot)
                                            .Descendants()
                                            .Where(x => x.Name.LocalName == "ID")
                                            .Select(x => Convert.ToInt32(x.Value))
                                            .DefaultIfEmpty(0)
                                            .Max();
                }
                

                ID += 1;
                tupla.Xelement.Element("ID").Value = Cálculos.IDPadleft(ID);
            }
            catch
            {
                tupla.Xelement.Element("ID").Value = Cálculos.IDPadleft(1);
            }
        }
        public int DevolverID(BE_TuplaXML tupla)
        {
            AbrirConexion();
            int ID;
            try
            {
                if (tupla.NodoRoot != "Empleados")
                {
                    ID = doc.Root.Element(tupla.NodoRoot).Descendants(tupla.NodoLeaf)
                                             .Select(x => Convert.ToInt32(x.Element("ID")?.Value ?? "0001"))
                                             .Max();
                }
                else
                {
                    ID = doc.Root.Element(tupla.NodoRoot)
                                            .Descendants()
                                            .Where(x => x.Name.LocalName == "ID")
                                            .Select(x => Convert.ToInt32(x.Value))
                                            .DefaultIfEmpty(0)
                                            .Max();
                }


                ID += 1;
                return ID;
            }
            catch
            {
                ID = 1;
                return ID;
            }
            finally { CancelarConexion();  }
        }
        public bool EscribirPermiso(List<BE_TuplaXML> datos)
        {
            AbrirConexion();
            try
            {
                foreach (BE_TuplaXML tupla in datos)
                {
                    XElement nodoPadre = doc.Root.Element(tupla.NodoRoot);
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
        public bool ModificarPermiso(List<BE_TuplaXML> datos)
        {
            AbrirConexion();
            try
            {
                foreach (BE_TuplaXML tupla in datos)
                {
                    XElement modificarObjeto = doc.Root.Element(tupla.NodoRoot).Descendants(tupla.NodoLeaf)
                                        .Where(n => n.Element("Codigo").Value == tupla.Xelement.Element("Codigo").Value)
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
        public bool BorrarPerfil(List<BE_TuplaXML> datos)
        {
            AbrirConexion();
            try
            {
                foreach (BE_TuplaXML tupla in datos)
                {
                    XElement borrarObjeto = doc.Root.Element(tupla.NodoRoot).Descendants(tupla.NodoLeaf)
                                                            .Where(n => n.Element("Codigo").Value == tupla.Xelement.Element("Codigo").Value)
                                                            .FirstOrDefault();
                    borrarObjeto.Remove();
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
        public bool ExistePermiso(List<BE_TuplaXML> datos)
        {
            AbrirConexion();
            try
            {
                XElement existe1 = null;
                XElement existe2 = null;
                foreach (BE_TuplaXML tupla in datos)
                {
                    existe1 =  doc.Root.Element(tupla.NodoRoot).Descendants(tupla.NodoLeaf)
                                                    .Where(n => n.Element("Padre").Value == tupla.Xelement.Element("Padre").Value
                                                    & n.Element("Hijo").Value == tupla.Xelement.Element("Hijo").Value)
                                                    .FirstOrDefault();
                    existe2 = doc.Root.Element(tupla.NodoRoot).Descendants(tupla.NodoLeaf)
                                                    .Where(n => n.Element("Padre").Value == tupla.Xelement.Element("Hijo").Value
                                                    & n.Element("Hijo").Value == tupla.Xelement.Element("Padre").Value)
                                                    .FirstOrDefault();
                }
                return existe1 == null && existe2 == null;
            }
            finally
            {
                CancelarConexion();
            }
            
        }
        public bool BorrarPermiso(List<BE_TuplaXML> datos)
        {
            AbrirConexion();
            try
            {
                foreach (BE_TuplaXML tupla in datos)
                {
                    doc.Root.Element(tupla.NodoRoot).Descendants(tupla.NodoLeaf)
                                                    .Where(n => n.Element("Padre").Value == tupla.Xelement.Element("Padre").Value 
                                                    &  n.Element("Hijo").Value == tupla.Xelement.Element("Hijo").Value)
                                                    .FirstOrDefault().Remove();
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
        public bool CambiarStatusPermiso(List<BE_TuplaXML> datos)
        {
            AbrirConexion();
            try
            {
                foreach (BE_TuplaXML tupla in datos)
                {
                    doc.Root.Element(tupla.NodoRoot).Descendants(tupla.NodoLeaf)
                                                    .Where(n => n.Element("Padre").Value == tupla.Xelement.Element("Padre").Value
                                                    & n.Element("Hijo").Value == tupla.Xelement.Element("Hijo").Value)
                                                    .FirstOrDefault().Element("Activo").Value = tupla.Xelement.Element("Activo").Value;
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

    }
}
