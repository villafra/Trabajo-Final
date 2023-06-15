using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Automate_Layer
{
    public static class XMLceador
    {
        public static XElement XMLcear(Object clase, int index)
        {
            Type tipo = clase.GetType();
            PropertyInfo[] propiedades = tipo.GetProperties();
            XElement nuevoXElement = new XElement(tipo.Name);
            foreach (PropertyInfo propiedad in propiedades)
            {
                XElement element = new XElement(propiedad.Name, propiedad.GetValue(clase));
                nuevoXElement.Add(element);
            }
            return nuevoXElement;
            
        }

        public static T desXMLcear<T>(XElement elemento, string objeto) where T: new ()
        {
            T objbase = new T();
            Type tipo = typeof(T);
            PropertyInfo[] propiedades = tipo.GetProperties();
            foreach (PropertyInfo propiedad in propiedades)
            {
                XElement nuevo = elemento.Element(propiedad.Name);
                if (elemento != null)
                {
                    object valor = Convert.ChangeType(elemento.Value, propiedad.PropertyType);
                    propiedad.SetValue(objeto, valor);
                }
            }

            return objbase;
        }
    }
}
