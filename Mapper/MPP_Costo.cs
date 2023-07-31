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
    public class MPP_Costo : IGestionable<BE_Costo>
    {
        private static List<BE_TuplaXML> ListadoXML;
        private static MPP_Costo mapper = null;
        public static MPP_Costo DevolverInstancia()
        {
            if (mapper == null) mapper = new MPP_Costo();
            else
                ListadoXML = null;
            return mapper;
        }
        ~MPP_Costo()
        {
            mapper = null;
            ListadoXML = null;
        }
        public bool Baja(BE_Costo Costo)
        {
            ListadoXML = new List<BE_TuplaXML>();
            ListadoXML.Add(CrearCostoXML(Costo));
            return Xml_Database.DevolverInstancia().Baja(ListadoXML);
        }

        public bool Guardar(BE_Costo Costo)
        {
            ListadoXML = new List<BE_TuplaXML>();
            ListadoXML.Add(CrearCostoXML(Costo));
            return Xml_Database.DevolverInstancia().Escribir(ListadoXML);
        }

        public List<BE_Costo> Listar()
        {
            DataSet ds = new DataSet();
            ds = Xml_Database.DevolverInstancia().Listar();

            List<BE_Costo> listado = ds.Tables.Contains("Costo") ?
                (from cos in ds.Tables["Costo"].AsEnumerable()
                 select cos[7].ToString() == TipoMaterial.Ingrediente.ToString() ?
                     new BE_CostoIngrediente
                     {
                         Codigo = Convert.ToInt32(cos[0]),
                         DíaCosteo = Convert.ToDateTime(cos[1]),
                         TamañoLoteCosteo = Convert.ToDecimal(cos[2]),
                         MateriaPrima = Convert.ToDecimal(cos[3]),
                         HorasHombre = Convert.ToDecimal(cos[4]),
                         Energía = Convert.ToDecimal(cos[5]),
                         OtrosGastos = Convert.ToDecimal(cos[6]),
                         Tipo = (TipoMaterial)Enum.Parse(typeof(TipoMaterial), cos[7].ToString()),
                         Material = MPP_Ingrediente.DevolverInstancia().ListarObjeto(new BE_Ingrediente { Codigo = Convert.ToInt32(cos[8]) },ds),
                         Activo = Convert.ToBoolean(cos[9])
                     } : cos[7].ToString() == TipoMaterial.Plato.ToString() ?
                     (BE_Costo)new BE_CostoPlato
                     {
                         Codigo = Convert.ToInt32(cos[0]),
                         DíaCosteo = Convert.ToDateTime(cos[1]),
                         TamañoLoteCosteo = Convert.ToDecimal(cos[2]),
                         MateriaPrima = Convert.ToDecimal(cos[3]),
                         HorasHombre = Convert.ToDecimal(cos[4]),
                         Energía = Convert.ToDecimal(cos[5]),
                         OtrosGastos = Convert.ToDecimal(cos[6]),
                         Tipo = (TipoMaterial)Enum.Parse(typeof(TipoMaterial), cos[7].ToString()),
                         Material = MPP_Plato.DevolverInstancia().ListarObjeto(new BE_Plato { Codigo = Convert.ToInt32(cos[8]) },ds),
                         Activo = Convert.ToBoolean(cos[9])
                     } : new BE_CostoBebida
                     {
                         Codigo = Convert.ToInt32(cos[0]),
                         DíaCosteo = Convert.ToDateTime(cos[1]),
                         TamañoLoteCosteo = Convert.ToDecimal(cos[2]),
                         MateriaPrima = Convert.ToDecimal(cos[3]),
                         HorasHombre = Convert.ToDecimal(cos[4]),
                         Energía = Convert.ToDecimal(cos[5]),
                         OtrosGastos = Convert.ToDecimal(cos[6]),
                         Tipo = (TipoMaterial)Enum.Parse(typeof(TipoMaterial), cos[7].ToString()),
                         Material = MPP_Bebida.DevolverInstancia().ListarObjeto(new BE_Bebida { Codigo = Convert.ToInt32(cos[8]) },ds),
                         Activo = Convert.ToBoolean(cos[9])
                     }).ToList() : null;

            return listado;

        }

        public BE_Costo ListarObjeto(BE_Costo Costo, DataSet ds=null)
        {
            if (ds is null)
            {
                ds = new DataSet();
                ds = Xml_Database.DevolverInstancia().Listar();
            }
            BE_Costo ObjetoEncontrado = ds.Tables.Contains("Costo") ?
                (from cos in ds.Tables["Costo"].AsEnumerable()
                 where Convert.ToInt32(cos[0]) == Costo.Codigo
                 select cos[7].ToString() == TipoMaterial.Ingrediente.ToString() ?
                     new BE_CostoIngrediente
                     {
                         Codigo = Convert.ToInt32(cos[0]),
                         DíaCosteo = Convert.ToDateTime(cos[1]),
                         TamañoLoteCosteo = Convert.ToDecimal(cos[2]),
                         MateriaPrima = Convert.ToDecimal(cos[3]),
                         HorasHombre = Convert.ToDecimal(cos[4]),
                         Energía = Convert.ToDecimal(cos[5]),
                         OtrosGastos = Convert.ToDecimal(cos[6]),
                         Tipo = (TipoMaterial)Enum.Parse(typeof(TipoMaterial), cos[7].ToString()),
                         Material = MPP_Ingrediente.DevolverInstancia().ListarObjeto(new BE_Ingrediente { Codigo = Convert.ToInt32(cos[8]) },ds)
                     } : cos[7].ToString() == TipoMaterial.Plato.ToString() ?
                     (BE_Costo)new BE_CostoPlato
                     {
                         Codigo = Convert.ToInt32(cos[0]),
                         DíaCosteo = Convert.ToDateTime(cos[1]),
                         TamañoLoteCosteo = Convert.ToDecimal(cos[2]),
                         MateriaPrima = Convert.ToDecimal(cos[3]),
                         HorasHombre = Convert.ToDecimal(cos[4]),
                         Energía = Convert.ToDecimal(cos[5]),
                         OtrosGastos = Convert.ToDecimal(cos[6]),
                         Tipo = (TipoMaterial)Enum.Parse(typeof(TipoMaterial), cos[7].ToString()),
                         Material = MPP_Plato.DevolverInstancia().ListarObjeto(new BE_Plato { Codigo = Convert.ToInt32(cos[8]) },ds)
                     } : new BE_CostoBebida
                     {
                         Codigo = Convert.ToInt32(cos[0]),
                         DíaCosteo = Convert.ToDateTime(cos[1]),
                         TamañoLoteCosteo = Convert.ToDecimal(cos[2]),
                         MateriaPrima = Convert.ToDecimal(cos[3]),
                         HorasHombre = Convert.ToDecimal(cos[4]),
                         Energía = Convert.ToDecimal(cos[5]),
                         OtrosGastos = Convert.ToDecimal(cos[6]),
                         Tipo = (TipoMaterial)Enum.Parse(typeof(TipoMaterial), cos[7].ToString()),
                         Material = MPP_Bebida.DevolverInstancia().ListarObjeto(new BE_Bebida { Codigo = Convert.ToInt32(cos[8]) },ds)
                     }).FirstOrDefault() : null;
            return ObjetoEncontrado;
        }

        public decimal DevolverCosto(object tipo, decimal cantidad =1, DataSet ds = null)
        {
            if (ds is null)
            {
                ds = new DataSet();
                ds = Xml_Database.DevolverInstancia().Listar();
            }
            decimal costo;
            var objeto = ds.Tables.Contains("Costo") ?
                (from cos in ds.Tables["Costo"].AsEnumerable()
                 where (cos[7].ToString() == TipoMaterial.Ingrediente.ToString() && (tipo is BE_Ingrediente) && Convert.ToInt32(cos[8]) == ((BE_Ingrediente)tipo).Codigo)
                || (cos[7].ToString() == TipoMaterial.Plato.ToString() && (tipo is BE_Plato) && Convert.ToInt32(cos[8]) == ((BE_Plato)tipo).Codigo) && Convert.ToBoolean(cos[9])
                 orderby Convert.ToInt32(cos[0]) descending
                 select (cos[7].ToString() == TipoMaterial.Ingrediente.ToString() && Convert.ToInt32(cos[8]) == ((BE_Ingrediente)tipo).Codigo) ?
                     new BE_CostoIngrediente
                     {
                         Codigo = Convert.ToInt32(cos[0]),
                         DíaCosteo = Convert.ToDateTime(cos[1]),
                         TamañoLoteCosteo = Convert.ToDecimal(cos[2]),
                         MateriaPrima = Convert.ToDecimal(cos[3]),
                         HorasHombre = Convert.ToDecimal(cos[4]),
                         Energía = Convert.ToDecimal(cos[5]),
                         OtrosGastos = Convert.ToDecimal(cos[6]),
                         Tipo = (TipoMaterial)Enum.Parse(typeof(TipoMaterial), cos[7].ToString()),
                         Activo = Convert.ToBoolean(cos[9])
                     } : cos[7].ToString() == TipoMaterial.Plato.ToString() & Convert.ToInt32(cos[8]) == ((BE_Plato)tipo).Codigo ?
                     new BE_CostoPlato
                     {
                         Codigo = Convert.ToInt32(cos[0]),
                         DíaCosteo = Convert.ToDateTime(cos[1]),
                         TamañoLoteCosteo = Convert.ToDecimal(cos[2]),
                         MateriaPrima = Convert.ToDecimal(cos[3]),
                         HorasHombre = Convert.ToDecimal(cos[4]),
                         Energía = Convert.ToDecimal(cos[5]),
                         OtrosGastos = Convert.ToDecimal(cos[6]),
                         Tipo = (TipoMaterial)Enum.Parse(typeof(TipoMaterial), cos[7].ToString()),
                         Activo = Convert.ToBoolean(cos[9])
                     } : (BE_Costo)new BE_CostoBebida
                     {
                         Codigo = Convert.ToInt32(cos[0]),
                         DíaCosteo = Convert.ToDateTime(cos[1]),
                         TamañoLoteCosteo = Convert.ToDecimal(cos[2]),
                         MateriaPrima = Convert.ToDecimal(cos[3]),
                         HorasHombre = Convert.ToDecimal(cos[4]),
                         Energía = Convert.ToDecimal(cos[5]),
                         OtrosGastos = Convert.ToDecimal(cos[6]),
                         Tipo = (TipoMaterial)Enum.Parse(typeof(TipoMaterial), cos[7].ToString()),
                         Activo = Convert.ToBoolean(cos[9])
                     }).FirstOrDefault() : null;

            if (objeto != null)
            {
                if (objeto is BE_CostoIngrediente) costo = ((BE_CostoIngrediente)objeto).DevolverCosto(cantidad);
                else if (objeto is BE_CostoBebida) costo = ((BE_CostoBebida)objeto).DevolverCosto(cantidad);
                else costo = ((BE_CostoPlato)objeto).DevolverCosto(cantidad);
            }
            else
            {
                costo = 0;
            }
            return costo;
        }

        public bool Modificar(BE_Costo Costo)
        {
            ListadoXML = new List<BE_TuplaXML>();
            ListadoXML.Add(CrearCostoXML(Costo));
            return Xml_Database.DevolverInstancia().Modificar(ListadoXML);
        }
        private BE_TuplaXML CrearCostoXML(BE_Costo Costo)
        {
            BE_TuplaXML nuevaTupla = new BE_TuplaXML();
            nuevaTupla.NodoRoot = "Costos";
            nuevaTupla.NodoLeaf = "Costo";
            XElement nuevoCosto = new XElement("Costo",
                new XElement("ID", Cálculos.IDPadleft(Costo.Codigo)),
                new XElement("Fecha_Costeo", Costo.DíaCosteo.ToString("dd/MM/yyyy")),
                new XElement("Tamaño_Lote_Costeo", Costo.TamañoLoteCosteo.ToString()),
                new XElement("Materia_Prima", Costo.MateriaPrima.ToString()),
                new XElement("Horas_Hombre", Costo.HorasHombre.ToString()),
                new XElement("Energía", Costo.Energía.ToString()),
                new XElement("Otros_Gastos", Costo.OtrosGastos.ToString()),
                new XElement("Tipo_Material", Costo.Tipo.ToString()),
                new XElement("ID_Material", Costo is BE_CostoIngrediente ? ((BE_CostoIngrediente)Costo).Material.Codigo.ToString() : Costo is BE_CostoBebida ? ((BE_CostoBebida)Costo).Material.Codigo.ToString() : ((BE_CostoPlato)Costo).Material.Codigo.ToString()),
                new XElement("Activo", Costo.Activo.ToString())
                );
            nuevaTupla.Xelement = nuevoCosto;
            return nuevaTupla;
        }
    }
}
