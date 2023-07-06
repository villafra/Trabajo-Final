using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_Entities;
using Abstraction_Layer;
using Data_Access_Layer;
using System.Data;
using System.Xml.Linq;
using Automate_Layer;

namespace Mapper
{
    public class MPP_Plato : IGestionable<BE_Plato>
    {
        private static List<BE_TuplaXML> ListadoXML;
        private static MPP_Plato mapper = null;
        public static MPP_Plato DevolverInstancia()
        {
            if (mapper == null) mapper = new MPP_Plato();
            else
                ListadoXML = null;
            return mapper;
        }
        ~MPP_Plato()
        {
            mapper = null;
            ListadoXML = null;
        }

        public bool Baja(BE_Plato plato)
        {
            ListadoXML = new List<BE_TuplaXML>();
            ListadoXML.Add(CrearPlatoXML(plato));
            return Xml_Database.DevolverInstancia().Borrar(ListadoXML);
        }

        public bool Guardar(BE_Plato plato)
        {
            ListadoXML = new List<BE_TuplaXML>();
            ListadoXML.Add(CrearPlatoXML(plato));
            return Xml_Database.DevolverInstancia().Escribir(ListadoXML);
        }

        public List<BE_Plato> Listar()
        {
            DataSet ds = new DataSet();
            ds = Xml_Database.DevolverInstancia().Listar();

            List<BE_Plato> listaPlatos = ds.Tables.Contains("Plato") != false ?
                (from platos in ds.Tables["Plato"].AsEnumerable()
                 select new BE_Plato
                 {
                     Codigo = Convert.ToInt32(platos[0]),
                     Nombre = Convert.ToString(platos[1]),
                     Tipo = (Tipo_Plato)Enum.Parse(typeof(Tipo_Plato), Convert.ToString(platos[2])),
                     Clase = (Clasificación)Enum.Parse(typeof(Clasificación), Convert.ToString(platos[3])),
                     Presentación = Convert.ToDecimal(platos[4]),
                     CostoUnitario = Convert.ToDecimal(platos[5]),
                     Activo = Convert.ToBoolean(platos[6]),
                     ListaIngredientes = MPP_Ingrediente.DevolverInstancia().Platos_Ingrediente(new BE_Plato { Codigo = Convert.ToInt32(platos[0]) }, ds)
                 }).ToList() : null;
            return listaPlatos;
        }

        public BE_Plato ListarObjeto(BE_Plato plato, DataSet ds = null)
        {
            if (ds is null)
            {
                ds = new DataSet();
                ds = Xml_Database.DevolverInstancia().Listar();
            }

            BE_Plato ObjetoEncontrado = ds.Tables.Contains("Plato") != false ?
                (from platos in ds.Tables["Plato"].AsEnumerable()
                 where Convert.ToInt32(platos[0]) == plato.Codigo
                 select new BE_Plato
                 {
                     Codigo = Convert.ToInt32(platos[0]),
                     Nombre = Convert.ToString(platos[1]),
                     Tipo = (Tipo_Plato)Enum.Parse(typeof(Tipo_Plato), Convert.ToString(platos[2])),
                     Clase = (Clasificación)Enum.Parse(typeof(Clasificación), Convert.ToString(platos[3])),
                     Presentación = Convert.ToDecimal(platos[4]),
                     CostoUnitario = Convert.ToDecimal(platos[5]),
                     Activo = Convert.ToBoolean(platos[6]),
                     ListaIngredientes = MPP_Ingrediente.DevolverInstancia().Platos_Ingrediente(new BE_Plato { Codigo = Convert.ToInt32(platos[0]) }, ds)
                 }).FirstOrDefault() : null;
            return ObjetoEncontrado;
        }

        public List<BE_Plato> Platos_Pedidos (BE_Pedido pedido, DataSet ds = null)
        {
            if (ds is null)
            {
                ds = new DataSet();
                ds = Xml_Database.DevolverInstancia().Listar();
            }

            List<BE_Plato> listaPlatos = ds.Tables.Contains("Plato") != false ?
                    (from obj in ds.Tables["Plato-Pedido"].AsEnumerable()
                     join platos in ds.Tables["Plato"].AsEnumerable()
                     on Convert.ToInt32(obj[1]) equals pedido.Codigo
                     select new BE_Plato
                     {
                         Codigo = Convert.ToInt32(platos[0]),
                         Nombre = Convert.ToString(platos[1]),
                         Tipo = (Tipo_Plato)Enum.Parse(typeof(Tipo_Plato), Convert.ToString(platos[2])),
                         Clase = (Clasificación)Enum.Parse(typeof(Clasificación), Convert.ToString(platos[3])),
                         Presentación = Convert.ToDecimal(platos[4]),
                         CostoUnitario = Convert.ToDecimal(platos[5]),
                         Activo = Convert.ToBoolean(platos[6]),
                         ListaIngredientes = MPP_Ingrediente.DevolverInstancia().Platos_Ingrediente(new BE_Plato { Codigo = Convert.ToInt32(platos[0]) },ds)
                     }).ToList() : null;
            return listaPlatos;
        }

        private BE_TuplaXML CrearPlatoXML(BE_Plato plato)
        {
            BE_TuplaXML nuevaTupla = new BE_TuplaXML();
            nuevaTupla.NodoRoot = "Platos";
            nuevaTupla.NodoLeaf = "Plato";
            XElement nuevoPlato = new XElement("Plato",
                new XElement("ID",  Cálculos.IDPadleft(plato.Codigo)),
                new XElement("Nombre", plato.Nombre.ToString()),
                new XElement("Tipo", plato.Tipo.ToString()),
                new XElement("Clase", plato.Clase.ToString()),
                new XElement("Presentación", plato.Presentación.ToString()),
                new XElement("Costo_Unitario", plato.CostoUnitario.ToString()),
                new XElement("Activo",plato.Activo.ToString())
                );
            nuevaTupla.Xelement = nuevoPlato;
            return nuevaTupla;
        }
        private List<BE_TuplaXML> CrearIngredientePlatoXML(BE_Plato plato)
        {
            List<BE_TuplaXML> ListadeIngredientes = new List<BE_TuplaXML>();
            foreach(BE_Ingrediente ing in plato.ListaIngredientes)
            {
                BE_TuplaXML nuevaTupla = new BE_TuplaXML();
                nuevaTupla.NodoRoot = "Ingredientes-Platos";
                nuevaTupla.NodoLeaf = "Ingrediente-Plato";
                XElement nuevoIngPlato = new XElement("Ingrediente-Plato",
                new XElement("ID Plato", Cálculos.IDPadleft(plato.Codigo)),
                new XElement("ID Ingrediente", Cálculos.IDPadleft(ing.Codigo))
                );
                nuevaTupla.Xelement = nuevoIngPlato;
                ListadeIngredientes.Add(nuevaTupla);
            }
            return ListadeIngredientes;
        }

        public bool Modificar(BE_Plato plato)
        {
            ListadoXML = new List<BE_TuplaXML>();
            ListadoXML.Add(CrearPlatoXML(plato));
            return Xml_Database.DevolverInstancia().Modificar(ListadoXML);
        }
    }
}
