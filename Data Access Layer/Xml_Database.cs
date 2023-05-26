using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Data_Access_Layer
{
    public class Xml_Database
    {
        XmlDocument doc = new XmlDocument();

        private void AbrirConexion()
        {
            doc.Load("Restaurant.xml");
        }

        private void CerrarConexion()
        {
            doc.Save("Restaurant.xml");
            doc = null;
            GC.Collect();
        }
        public bool Escribir(string nombreNodo, XmlElement nuevoNodo = null, List<XmlElement> listaNodos = null)
        {
            AbrirConexion();
            try
            {
                XmlElement nodoRaiz = doc.DocumentElement;
                XmlElement buscarNodo = nodoRaiz.SelectSingleNode(nombreNodo) as XmlElement;
                if (listaNodos.Count > 0)
                {
                    foreach (XmlElement nodo in listaNodos)
                    {
                        buscarNodo.AppendChild(nodo);
                    }
                }
                else
                {
                    buscarNodo.AppendChild(nuevoNodo);
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
    }
}
