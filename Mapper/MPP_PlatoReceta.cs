using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_Entities;
using Abstraction_Layer;
using Data_Access_Layer;
using System.Xml.Linq;
using System.Data;
using Automate_Layer;

namespace Mapper
{
    public class MPP_PlatoReceta
    {
        private static List<BE_TuplaXML> ListadoXML;
        private static MPP_PlatoReceta mapper = null;
        public static MPP_PlatoReceta DevolverInstancia()
        {
            if (mapper == null) mapper = new MPP_PlatoReceta();
            else
                ListadoXML = null;
            return mapper;
        }
        ~MPP_PlatoReceta()
        {
            mapper = null;
            ListadoXML = null;
        }
        public bool Baja(List<BE_PlatoReceta> PlatoReceta)
        {
            ListadoXML = new List<BE_TuplaXML>();
            ListadoXML.AddRange(CrearListaPlatoIngrediente(PlatoReceta));
            return Xml_Database.DevolverInstancia().Borrar(ListadoXML);
        }

        public bool Guardar(List<BE_PlatoReceta> PlatoReceta)
        {
            ListadoXML = new List<BE_TuplaXML>();
            ListadoXML.AddRange(CrearListaPlatoIngrediente(PlatoReceta));
            return Xml_Database.DevolverInstancia().Escribir(ListadoXML);
        }

        public List<BE_PlatoReceta> Listar()
        {
            DataSet ds = new DataSet();
            ds = Xml_Database.DevolverInstancia().Listar();

            List<BE_PlatoReceta> listado = ds.Tables.Contains("Plato-Ingrediente") != false ?
                (from bi in ds.Tables["Plato-Ingrediente"].AsEnumerable()
                 select new BE_PlatoReceta
                 {
                     Codigo = Convert.ToInt32(bi[0]),
                     Plato = MPP_Plato.DevolverInstancia().ListarObjeto(new BE_Plato { Codigo = Convert.ToInt32(bi[1]) }, ds),
                     Ingrediente = MPP_Ingrediente.DevolverInstancia().ListarObjeto(new BE_Ingrediente { Codigo = Convert.ToInt32(bi[2]) }, ds),
                     Cantidad = Convert.ToDecimal(bi[3]),
                     Alternativa = bi[4].ToString(),
                     Activo = Convert.ToBoolean(bi[5])
                 }).ToList() : null;
            return listado;
        }

        public List<BE_PlatoReceta> ListarObjeto(BE_Plato Plato, BE_PlatoReceta alternativa, DataSet ds=null)
        {
            if (ds is null)
            {
                ds = new DataSet();
                ds = Xml_Database.DevolverInstancia().Listar();
            }

            List<BE_PlatoReceta> ObjetoEncontrado = ds.Tables.Contains("Plato-Ingrediente") != false ?
                (from bi in ds.Tables["Plato-Ingrediente"].AsEnumerable()
                 where Convert.ToInt32(bi[1]) == Plato.Codigo && alternativa.Alternativa == bi[4].ToString()
                 select new BE_PlatoReceta
                 {
                     Codigo = Convert.ToInt32(bi[0]),
                     Plato = MPP_Plato.DevolverInstancia().ListarObjeto(new BE_Plato { Codigo = Convert.ToInt32(bi[1]) }, ds),
                     Ingrediente = MPP_Ingrediente.DevolverInstancia().ListarObjeto(new BE_Ingrediente { Codigo = Convert.ToInt32(bi[2]) }, ds),
                     Cantidad = Convert.ToDecimal(bi[3]),
                     Alternativa = bi[4].ToString(),
                     Activo = Convert.ToBoolean(bi[5])
                 }).OrderBy(x=> x.Ingrediente.Codigo).ToList() : null;
            return ObjetoEncontrado;
        }
        public List<BE_PlatoReceta> ListarAlternativasDataSource(BE_Plato Plato)
        {
            DataSet ds = new DataSet();
            ds = Xml_Database.DevolverInstancia().Listar();

            List<BE_PlatoReceta> listado = ds.Tables.Contains("Plato-Ingrediente") != false ?
                (from bi in ds.Tables["Plato-Ingrediente"].AsEnumerable()
                 where Convert.ToInt32(bi[1]) == Plato.Codigo
                 select bi[4].ToString()).Distinct().Select(alternativa =>
                 new BE_PlatoReceta
                 {
                     Alternativa = alternativa
                 }).ToList() : null;
            return listado;
        }
        public BE_PlatoReceta ListarAlternativaVigente(BE_Plato Plato, DataSet ds = null)
        {
            if (ds is null)
            {
                ds = new DataSet();
                ds = Xml_Database.DevolverInstancia().Listar();
            }

            List<BE_PlatoReceta> listado = ds.Tables.Contains("Plato-Ingrediente") != false ?
                (from bi in ds.Tables["Plato-Ingrediente"].AsEnumerable()
                 where Convert.ToInt32(bi[1]) == Plato.Codigo && Convert.ToBoolean(bi[5])
                 select new BE_PlatoReceta
                 {
                     Codigo = Convert.ToInt32(bi[0]),
                     Alternativa = bi[4].ToString(),
                 }).ToList() : null;
            BE_PlatoReceta vigente =  listado != null ? listado.Distinct().OrderByDescending(x=> x.Codigo).FirstOrDefault(): null;
            return vigente;
        }
        public List<BE_PlatoReceta> PlatoEnOrden(BE_Plato plato)
        {
            DataSet ds;
            ds = Xml_Database.DevolverInstancia().Listar();
            BE_PlatoReceta receta = ListarAlternativaVigente(plato, ds);
            List<BE_PlatoReceta> listado = ListarObjeto(plato, receta, ds);
            return listado;
        }
        public bool Modificar(List<BE_PlatoReceta> PlatoReceta)
        {
            ListadoXML = new List<BE_TuplaXML>();
            ListadoXML.AddRange(CrearListaPlatoIngrediente(PlatoReceta));
            return Xml_Database.DevolverInstancia().Modificar(ListadoXML);
        }
        public List<BE_TuplaXML> CrearListaPlatoIngrediente(List<BE_PlatoReceta> Platoreceta)
        {
            List<BE_TuplaXML> listadeIngredientes = new List<BE_TuplaXML>();

            foreach (BE_PlatoReceta Plato in Platoreceta)
            {
                BE_TuplaXML nuevaTupla = new BE_TuplaXML();
                nuevaTupla.NodoRoot = "Platos-Ingredientes";
                nuevaTupla.NodoLeaf = "Plato-Ingrediente";
                XElement nuevaPlatoIngrediente = new XElement("Plato-Ingrediente",
                    new XElement("ID", Cálculos.IDPadleft(Plato.Codigo)),
                    new XElement("ID_Plato", Cálculos.IDPadleft(Plato.Plato.Codigo)),
                    new XElement("ID_Ingrediente", Cálculos.IDPadleft(Plato.Ingrediente.Codigo)),
                    new XElement("Cantidad", Plato.Cantidad.ToString()),
                    new XElement("Alternativa", Plato.Alternativa),
                    new XElement("Activo", Plato.Activo.ToString())
                    );
                nuevaTupla.Xelement = nuevaPlatoIngrediente;
                listadeIngredientes.Add(nuevaTupla);
            }
            return listadeIngredientes;
        }
    }
}
