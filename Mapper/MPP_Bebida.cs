using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_Entities;
using Abstraction_Layer;
using Data_Access_Layer;
using System.Xml.Linq;

namespace Mapper
{
    public class MPP_Bebida:IGestionable<BE_Bebida>
    {
        Xml_Database Acceso;
        List<BE_TuplaXML> ListadoXML;

        public MPP_Bebida()
        {
            ListadoXML = new List<BE_TuplaXML>();
        }

        public bool Baja(BE_Bebida bebida)
        {
            Acceso = new Xml_Database();

            return Acceso.Borrar(ListadoXML);
        }

        public bool Guardar(BE_Bebida bebida)
        {
            Acceso = new Xml_Database();

            return Acceso.Escribir(ListadoXML);
        }

        public List<BE_Bebida> Listar()
        {
            throw new NotImplementedException();
        }

        public BE_Bebida ListarObjeto(BE_Bebida bebida)
        {
            throw new NotImplementedException();
        }

        public bool Modificar(BE_Bebida bebida)
        {
            Acceso = new Xml_Database();

            return Acceso.Modificar(ListadoXML);
        }

        public BE_TuplaXML CrearBebidaXML(BE_Bebida bebida)
        {
            BE_TuplaXML nuevaTupla = new BE_TuplaXML();
            nuevaTupla.NodoRoot = "Bebidas";
            nuevaTupla.NodoLeaf = "Bebida";
            XElement nuevaBebida = new XElement("Bebida",
                new XElement("ID", bebida.Codigo.ToString()),
                new XElement("Nombre", bebida.Nombre),
                new XElement("Tipo", bebida.Tipo),
                new XElement("Presentación", bebida.Presentacion.ToString()),
                new XElement("Stock", bebida.Stock.ToString()),
                new XElement("Costo Unitario", bebida.CostoUnitario.ToString()),
                new XElement("Unidad de Medida", bebida.UnidadMedida),
                new XElement("Vida Util", bebida.VidaUtil.ToString())
                );
            nuevaTupla.Xelement = nuevaBebida;
            return nuevaTupla;
        }
        public BE_TuplaXML CrearBebidaXML(BE_Bebida_Alcoholica bebida)
        {
            BE_TuplaXML nuevaTupla = new BE_TuplaXML();
            nuevaTupla.NodoRoot = "Bebidas";
            nuevaTupla.NodoLeaf = "Bebida Alcoholica";
            XElement nuevaBebida = new XElement("Bebida Alcoholica",
                new XElement("ID", bebida.Codigo.ToString()),
                new XElement("Nombre", bebida.Nombre),
                new XElement("Tipo", bebida.Tipo),
                new XElement("Presentación", bebida.Presentacion.ToString()),
                new XElement("Stock", bebida.Stock.ToString()),
                new XElement("Costo Unitario", bebida.CostoUnitario.ToString()),
                new XElement("Unidad de Medida", bebida.UnidadMedida),
                new XElement("Vida Util", bebida.VidaUtil.ToString()),
                new XElement("ABV", bebida.ABV.ToString())
                );
            nuevaTupla.Xelement = nuevaBebida;
            return nuevaTupla;
        }
        public BE_TuplaXML CrearBebidaXML(BE_Bebida_Preparada bebida)
        {
            BE_TuplaXML nuevaTupla = new BE_TuplaXML();
            nuevaTupla.NodoRoot = "Bebidas";
            nuevaTupla.NodoLeaf = "Bebida Preparada";
            XElement nuevaBebida = new XElement("Bebida Preparada",
                new XElement("ID", bebida.Codigo.ToString()),
                new XElement("Nombre", bebida.Nombre),
                new XElement("Tipo", bebida.Tipo),
                new XElement("Presentación", bebida.Presentacion.ToString()),
                new XElement("Stock", bebida.Stock.ToString()),
                new XElement("Costo Unitario", bebida.CostoUnitario.ToString()),
                new XElement("Unidad de Medida", bebida.UnidadMedida),
                new XElement("Vida Util", bebida.VidaUtil.ToString()),
                new XElement("ABV", bebida.ABV.ToString())
                );
            nuevaTupla.Xelement = nuevaBebida;
            return nuevaTupla;
        }

        public List<BE_TuplaXML> CrearListaBebidaIngrediente(BE_Bebida_Preparada bebida)
        {
            List<BE_TuplaXML> listadeIngredientes = new List<BE_TuplaXML>();
            foreach (BE_Ingrediente ingrediente in bebida.ListaIngredientes)
            {
                BE_TuplaXML nuevaTupla = new BE_TuplaXML();
                nuevaTupla.NodoRoot = "Bebidas-Ingredientes";
                nuevaTupla.NodoLeaf = "Bebida-Ingrediente";
                XElement nuevaBebidaIngrediente = new XElement("Bebida-Ingrediente",
                    new XElement("ID Bebida",bebida.Codigo.ToString()),
                    new XElement("ID Ingrediente", ingrediente.Codigo.ToString())
                    );
                nuevaTupla.Xelement = nuevaBebidaIngrediente;
                listadeIngredientes.Add(nuevaTupla);
            }
            return listadeIngredientes;
        }
    }
}
