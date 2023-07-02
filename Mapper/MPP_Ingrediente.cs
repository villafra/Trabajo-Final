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
    public class MPP_Ingrediente:IGestionable<BE_Ingrediente>
    {
        private static List<BE_TuplaXML> ListadoXML;
        private static MPP_Ingrediente mapper = null;
        public static MPP_Ingrediente DevolverInstancia()
        {
            if (mapper == null) mapper = new MPP_Ingrediente();
            else
                ListadoXML = null;
            return mapper;
        }
        ~MPP_Ingrediente()
        {
            mapper = null;
            ListadoXML = null;
        }
        public bool Baja(BE_Ingrediente ingrediente)
        {
            ListadoXML = new List<BE_TuplaXML>();
            ListadoXML.Add(CrearIngredienteXML(ingrediente));
            return Xml_Database.DevolverInstancia().Baja(ListadoXML);
        }

        public bool Guardar(BE_Ingrediente ingrediente)
        {
            ListadoXML = new List<BE_TuplaXML>();
            ListadoXML.Add(CrearIngredienteXML(ingrediente));
            return Xml_Database.DevolverInstancia().Escribir(ListadoXML);
        }

        public List<BE_Ingrediente> Listar()
        {
            DataSet ds = new DataSet();
            ds = Xml_Database.DevolverInstancia().Listar();

            List<BE_Ingrediente> listaIngredientes = ds.Tables.Contains("Ingrediente") != false ?
                (from ing in ds.Tables["Ingrediente"].AsEnumerable()
                 select new BE_Ingrediente
                 {
                     Codigo = Convert.ToInt32(ing[0]),
                     Nombre = Convert.ToString(ing[1]),
                     Tipo = (TipoIng)Enum.Parse(typeof(TipoIng), Convert.ToString(ing[2])),
                     Refrigeracion = Convert.ToBoolean(ing[3]),
                     UnidadMedida = (UM)Enum.Parse(typeof(UM), Convert.ToString(ing[4])),
                     Activo = Convert.ToBoolean(ing[5]),
                     VidaUtil = Convert.ToInt32(ing[6]),
                     Status = (StatusIng)Enum.Parse(typeof(StatusIng), Convert.ToString(ing[7])),
                     GestionLote = Convert.ToBoolean(ing[8]),
                     CostoUnitario = MPP_Costo.DevolverInstancia().DevolverCosto(new BE_Ingrediente { Codigo = Convert.ToInt32(ing[0]), })

                 }).ToList() : null;
            return listaIngredientes;
            
        }


        public BE_Ingrediente ListarObjeto(BE_Ingrediente ingrediente, DataSet ds=null)
        {

            BE_Ingrediente ObjetoEncontrado = ds.Tables.Contains("Ingrediente") != false ?
                (from ing in ds.Tables["Ingrediente"].AsEnumerable()
                 where Convert.ToInt32(ing[0]) == ingrediente.Codigo
                 select new BE_Ingrediente
                 {
                     Codigo = Convert.ToInt32(ing[0]),
                     Nombre = Convert.ToString(ing[1]),
                     Tipo = (TipoIng)Enum.Parse(typeof(TipoIng), Convert.ToString(ing[2])),
                     Refrigeracion = Convert.ToBoolean(ing[3]),
                     UnidadMedida = (UM)Enum.Parse(typeof(UM), Convert.ToString(ing[4])),
                     Activo = Convert.ToBoolean(ing[5]),
                     VidaUtil = Convert.ToInt32(ing[6]),
                     Status = (StatusIng)Enum.Parse(typeof(StatusIng), Convert.ToString(ing[7])),
                     GestionLote = Convert.ToBoolean(ing[8]),
                     CostoUnitario = MPP_Costo.DevolverInstancia().DevolverCosto(new BE_Ingrediente { Codigo = Convert.ToInt32(ing[0]), })

                 }).FirstOrDefault() : null;
            return ObjetoEncontrado;
        }

        public List<BE_Ingrediente> Bebidas_Ingrediente(BE_Bebida_Preparada bebida)
        {
            DataSet ds = new DataSet();
            ds = Xml_Database.DevolverInstancia().Listar();

            List<BE_Ingrediente> listaIngredientes = ds.Tables.Contains("Ingrediente") &
                ds.Tables.Contains("Bebida-Ingrediente") != false ?
                (from obj in ds.Tables["Bebida-Ingrediente"].AsEnumerable()
                 join ing in ds.Tables["Ingrediente"].AsEnumerable()
                 on Convert.ToInt32(obj[1]) equals bebida.Codigo
                 select new BE_Ingrediente
                 {
                     Codigo = Convert.ToInt32(ing[0]),
                     Nombre = Convert.ToString(ing[1]),
                     Tipo = (TipoIng)Enum.Parse(typeof(TipoIng), Convert.ToString(ing[2])),
                     Refrigeracion = Convert.ToBoolean(ing[3]),
                     UnidadMedida = (UM)Enum.Parse(typeof(UM), Convert.ToString(ing[4])),
                     Activo = Convert.ToBoolean(ing[5]),
                     VidaUtil = Convert.ToInt32(ing[6]),
                     Status = (StatusIng)Enum.Parse(typeof(StatusIng), Convert.ToString(ing[7])),
                     GestionLote = Convert.ToBoolean(ing[8]),
                     CostoUnitario = MPP_Costo.DevolverInstancia().DevolverCosto(new BE_Ingrediente { Codigo = Convert.ToInt32(ing[0]), })

                 }).ToList() : null;
            return listaIngredientes;
        }
        public List<BE_Ingrediente> Platos_Ingrediente(BE_Plato plato, DataSet ds = null)
        {
            if (ds is null)
            {
                ds = new DataSet();
                ds = Xml_Database.DevolverInstancia().Listar();
            }

            List<BE_Ingrediente> listaIngredientes = ds.Tables.Contains("Ingrediente") &
                ds.Tables.Contains("Plato-Ingrediente") != false ?
                (from obj in ds.Tables["Plato-Ingrediente"].AsEnumerable()
                 join ing in ds.Tables["Ingrediente"].AsEnumerable()
                 on Convert.ToInt32(obj[1]) equals plato.Codigo
                 select new BE_Ingrediente
                 {
                     Codigo = Convert.ToInt32(ing[0]),
                     Nombre = Convert.ToString(ing[1]),
                     Tipo = (TipoIng)Enum.Parse(typeof(TipoIng), Convert.ToString(ing[2])),
                     Refrigeracion = Convert.ToBoolean(ing[3]),
                     UnidadMedida = (UM)Enum.Parse(typeof(UM), Convert.ToString(ing[4])),
                     Activo = Convert.ToBoolean(ing[5]),
                     VidaUtil = Convert.ToInt32(ing[6]),
                     Status = (StatusIng)Enum.Parse(typeof(StatusIng), Convert.ToString(ing[7])),
                     GestionLote = Convert.ToBoolean(ing[8]),
                     CostoUnitario = MPP_Costo.DevolverInstancia().DevolverCosto(new BE_Ingrediente { Codigo = Convert.ToInt32(ing[0]), })

                 }).ToList() : null;
            return listaIngredientes;
        }

        public bool Modificar(BE_Ingrediente ingrediente)
        {
            ListadoXML = new List<BE_TuplaXML>();
            ListadoXML.Add(CrearIngredienteXML(ingrediente));
            return Xml_Database.DevolverInstancia().Modificar(ListadoXML);
        }

        private BE_TuplaXML CrearIngredienteXML(BE_Ingrediente ingrediente)
        {
            BE_TuplaXML nuevaTupla = new BE_TuplaXML();
            nuevaTupla.NodoRoot = "Ingredientes";
            nuevaTupla.NodoLeaf = "Ingrediente";
            XElement nuevoIngrediente = new XElement("Ingrediente",
                new XElement("ID",Cálculos.IDPadleft(ingrediente.Codigo)),
                new XElement("Nombre",ingrediente.Nombre),
                new XElement("Tipo",ingrediente.Tipo),
                new XElement("Refrigeración",ingrediente.Refrigeracion.ToString()),
                new XElement("Unidad_Medida", ingrediente.UnidadMedida),
                new XElement("Activo", ingrediente.Activo.ToString()),
                new XElement("Vida_Util", ingrediente.VidaUtil.ToString()),
                new XElement("Status", ingrediente.Status),
                new XElement("Gestion_Lote", ingrediente.GestionLote.ToString())
                );
            nuevaTupla.Xelement = nuevoIngrediente;
            return nuevaTupla;
        }
    }
}
