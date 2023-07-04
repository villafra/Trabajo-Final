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
    public class MPP_BebidaReceta
    {
        private static List<BE_TuplaXML> ListadoXML;
        private static MPP_BebidaReceta mapper = null;
        public static MPP_BebidaReceta DevolverInstancia()
        {
            if (mapper == null) mapper = new MPP_BebidaReceta();
            else
                ListadoXML = null;
            return mapper;
        }
        ~MPP_BebidaReceta()
        {
            mapper = null;
            ListadoXML = null;
        }
        public bool Baja(List<BE_BebidaReceta> BebidaReceta)
        {
            ListadoXML = new List<BE_TuplaXML>();
            ListadoXML.AddRange(CrearListaBebidaIngrediente(BebidaReceta));
            return Xml_Database.DevolverInstancia().Borrar(ListadoXML);
        }

        public bool Guardar(List<BE_BebidaReceta> BebidaReceta)
        {
            ListadoXML = new List<BE_TuplaXML>();
            ListadoXML.AddRange(CrearListaBebidaIngrediente(BebidaReceta));
            return Xml_Database.DevolverInstancia().Escribir(ListadoXML);
        }

        public List<BE_BebidaReceta> Listar()
        {
            DataSet ds = new DataSet();
            ds = Xml_Database.DevolverInstancia().Listar();

            List<BE_BebidaReceta> listado = ds.Tables.Contains("Bebida-Ingrediente") != false ?
                (from bi in ds.Tables["Bebida-Ingrediente"].AsEnumerable()
                 select new BE_BebidaReceta
                 {
                     Codigo = Convert.ToInt32(bi[0]),
                     Bebida = (BE_Bebida_Preparada)MPP_Bebida.DevolverInstancia().ListarObjeto(new BE_Bebida_Preparada { Codigo = Convert.ToInt32(bi[1]) }, ds),
                     Ingrediente = MPP_Ingrediente.DevolverInstancia().ListarObjeto(new BE_Ingrediente { Codigo = Convert.ToInt32(bi[2]) }, ds),
                     Cantidad = Convert.ToDecimal(bi[3]),
                     Alternativa = bi[4].ToString(),
                     Activo = Convert.ToBoolean(bi[5])
                 }).ToList() : null;
            return listado;
        }

        public List<BE_BebidaReceta> ListarObjeto(BE_Bebida bebida, BE_BebidaReceta alternativa, DataSet ds=null)
        {
            if (ds is null)
            {
                ds = new DataSet();
                ds = Xml_Database.DevolverInstancia().Listar();
            }

            List<BE_BebidaReceta> ObjetoEncontrado = ds.Tables.Contains("Bebida-Ingrediente") != false ?
                (from bi in ds.Tables["Bebida-Ingrediente"].AsEnumerable()
                 where Convert.ToInt32(bi[1]) == bebida.Codigo && alternativa.Alternativa == bi[4].ToString()
                 select new BE_BebidaReceta
                 {
                     Codigo = Convert.ToInt32(bi[0]),
                     Bebida = (BE_Bebida_Preparada)MPP_Bebida.DevolverInstancia().ListarObjeto(new BE_Bebida_Preparada { Codigo = Convert.ToInt32(bi[1]) }, ds),
                     Ingrediente = MPP_Ingrediente.DevolverInstancia().ListarObjeto(new BE_Ingrediente { Codigo = Convert.ToInt32(bi[2]) }, ds),
                     Cantidad = Convert.ToDecimal(bi[3]),
                     Alternativa = bi[4].ToString(),
                     Activo = Convert.ToBoolean(bi[5])
                 }).OrderBy(x=> x.Ingrediente.Codigo).ToList() : null;
            return ObjetoEncontrado;
        }
        public List<BE_BebidaReceta> ListarAlternativasDataSource(BE_Bebida bebida)
        {
            DataSet ds = new DataSet();
            ds = Xml_Database.DevolverInstancia().Listar();

            List<BE_BebidaReceta> listado = ds.Tables.Contains("Bebida-Ingrediente") != false ?
                (from bi in ds.Tables["Bebida-Ingrediente"].AsEnumerable()
                 where Convert.ToInt32(bi[1]) == bebida.Codigo
                 select bi[4].ToString()).Distinct().Select(alternativa =>
                 new BE_BebidaReceta
                 {
                     Alternativa = alternativa
                 }).ToList() : null;
            return listado;
        }
        public BE_BebidaReceta ListarAlternativaVigente(BE_Bebida bebida)
        {
            DataSet ds = new DataSet();
            ds = Xml_Database.DevolverInstancia().Listar();

            List<BE_BebidaReceta> listado = ds.Tables.Contains("Bebida-Ingrediente") != false ?
                (from bi in ds.Tables["Bebida-Ingrediente"].AsEnumerable()
                 where Convert.ToInt32(bi[1]) == bebida.Codigo && Convert.ToBoolean(bi[5])
                 select new BE_BebidaReceta
                 {
                     Codigo = Convert.ToInt32(bi[0]),
                     Alternativa = bi[4].ToString(),
                 }).ToList() : null;
            BE_BebidaReceta vigente =  listado != null ? listado.Distinct().OrderByDescending(x=> x.Codigo).FirstOrDefault(): null;
            return vigente;
        }

        public bool Modificar(List<BE_BebidaReceta> BebidaReceta)
        {
            ListadoXML = new List<BE_TuplaXML>();
            ListadoXML.AddRange(CrearListaBebidaIngrediente(BebidaReceta));
            return Xml_Database.DevolverInstancia().Modificar(ListadoXML);
        }
        public List<BE_TuplaXML> CrearListaBebidaIngrediente(List<BE_BebidaReceta> bebidareceta)
        {
            List<BE_TuplaXML> listadeIngredientes = new List<BE_TuplaXML>();

            foreach (BE_BebidaReceta bebida in bebidareceta)
            {
                BE_TuplaXML nuevaTupla = new BE_TuplaXML();
                nuevaTupla.NodoRoot = "Bebidas-Ingredientes";
                nuevaTupla.NodoLeaf = "Bebida-Ingrediente";
                XElement nuevaBebidaIngrediente = new XElement("Bebida-Ingrediente",
                    new XElement("ID", Cálculos.IDPadleft(bebida.Codigo)),
                    new XElement("ID_Bebida", Cálculos.IDPadleft(bebida.Bebida.Codigo)),
                    new XElement("ID_Ingrediente", Cálculos.IDPadleft(bebida.Ingrediente.Codigo)),
                    new XElement("Cantidad", bebida.Cantidad.ToString()),
                    new XElement("Alternativa", bebida.Alternativa),
                    new XElement("Activo", bebida.Activo.ToString())
                    );
                nuevaTupla.Xelement = nuevaBebidaIngrediente;
                listadeIngredientes.Add(nuevaTupla);
            }
            return listadeIngredientes;
        }
    }
}
