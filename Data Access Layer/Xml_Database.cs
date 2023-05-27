using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

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
        public bool Escribir(string nombreNodo, XElement nuevoNodo = null, List<XElement> listaNodos = null)
        {
            AbrirConexion();
            try
            {
                XElement nodoPadre = doc.Root.Element(nombreNodo);
                if (listaNodos != null)
                {
                    foreach (XElement nodo in listaNodos)
                    {
                        nodoPadre.Add(nodo);
                    }
                }
                else
                {
                    nodoPadre.Add(nuevoNodo);
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            finally
            {
                CerrarConexion();
            }
            
        }

        public bool Borrar(string nombreNodo, string nombreObjeto, XElement borrarNodo = null, List<XElement> listaNodos = null)
        {

            AbrirConexion();
            try
            {
                IEnumerable<XElement> borrarObjeto = doc.Root.Element(nombreNodo).Descendants(nombreObjeto);

                if (listaNodos != null)
                {
                    foreach (XElement nodo in listaNodos)
                    {
                        borrarObjeto
                            .Where(n => n.Element("ID") == nodo.Element("ID"))
                            .Remove();
                    }
                }
                else
                {
                    borrarObjeto
                       .Where(n => n.Element("ID") == borrarNodo.Element("ID"))
                       .Remove();
                }

                return true;
            }   
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            finally
            {
                CerrarConexion();
            }

        }

        public bool Modificar(string nombreNodo, string nombreObjeto, XElement modificarNodo = null, List<XElement> listaNodos = null)
        {
            AbrirConexion();

            try
            {
                if (listaNodos != null)
                {
                    foreach (XElement nodo in listaNodos)
                    {
                        XElement modificarObjeto = doc.Root.Element(nombreNodo).Descendants(nombreObjeto)
                                            .Where(n => n.Element("ID").Value == nodo.Element("ID").Value)
                                            .FirstOrDefault();

                        foreach (XElement dato in modificarObjeto.Elements())
                        {
                            dato.Value = nodo.Element(dato.Name).Value;
                        }
                    }
                }
                else
                {
                    XElement modificarObjeto = doc.Root.Element(nombreNodo).Descendants(nombreObjeto)
                    .Where(n => n.Element("ID").Value == modificarNodo.Element("ID").Value)
                    .FirstOrDefault();

                    foreach (XElement dato in modificarObjeto.Elements())
                    {
                        dato.Value = modificarNodo.Element(dato.Name).Value;
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            finally
            {
                CerrarConexion();
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
