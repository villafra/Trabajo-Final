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
        Xml_Database Acceso;
        List<BE_TuplaXML> ListadoXML;

        public bool Baja(BE_Costo Costo)
        {
            Acceso = new Xml_Database();
            ListadoXML = new List<BE_TuplaXML>();
            ListadoXML.Add(CrearCostoXML(Costo));
            return Acceso.Baja(ListadoXML);
        }

        public bool Guardar(BE_Costo Costo)
        {
            Acceso = new Xml_Database();
            ListadoXML = new List<BE_TuplaXML>();
            ListadoXML.Add(CrearCostoXML(Costo));
            return Acceso.Escribir(ListadoXML);
        }

        public List<BE_Costo> Listar()
        {
            Acceso = new Xml_Database();
            DataSet ds = new DataSet();
            ds = Acceso.Listar();

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
                         Material = new MPP_Ingrediente().ListarObjeto(new BE_Ingrediente { Codigo = Convert.ToInt32(cos[8]) })
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
                         Material = new MPP_Plato().ListarObjeto(new BE_Plato { Codigo = Convert.ToInt32(cos[8]) })
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
                         Material = new MPP_Bebida().ListarObjeto(new BE_Bebida { Codigo = Convert.ToInt32(cos[8]) })
                     }).ToList() : null;

            return listado;

        }

        public BE_Costo ListarObjeto(BE_Costo Costo)
        {
            Acceso = new Xml_Database();
            DataSet ds = new DataSet();
            ds = Acceso.Listar();

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
                         Material = new MPP_Ingrediente().ListarObjeto(new BE_Ingrediente { Codigo = Convert.ToInt32(cos[8]) })
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
                         Material = new MPP_Plato().ListarObjeto(new BE_Plato { Codigo = Convert.ToInt32(cos[8]) })
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
                         Material = new MPP_Bebida().ListarObjeto(new BE_Bebida { Codigo = Convert.ToInt32(cos[8]) })
                     }).FirstOrDefault() : null;
            return ObjetoEncontrado;
        }
        public decimal DevolverCosto(object tipo, decimal cantidad = 1)
        {
            List<BE_Costo> listado = Listar();
            BE_Costo cost;
            decimal costo;
            if (tipo is BE_Ingrediente)
            {
                cost = listado.FindLast(x => ((BE_CostoIngrediente)x).Material.Codigo == ((BE_Ingrediente)tipo).Codigo);
                costo = cost != null ? cost.DevolverCosto(cantidad) : 0; 
            }
            else if (tipo is BE_Plato)
            {
                cost = listado.FindLast(x => ((BE_CostoPlato)x).Material.Codigo == ((BE_Plato)tipo).Codigo);
                costo = cost != null ? cost.DevolverCosto(cantidad) : 0;
            }
            else
            {
                cost = listado.FindLast(x => ((BE_CostoBebida)x).Material.Codigo == ((BE_Bebida)tipo).Codigo);
                costo = cost != null ? cost.DevolverCosto(cantidad) : 0;
            }
        
            return costo;
        }

        public bool Modificar(BE_Costo Costo)
        {
            Acceso = new Xml_Database();
            ListadoXML = new List<BE_TuplaXML>();
            ListadoXML.Add(CrearCostoXML(Costo));
            return Acceso.Modificar(ListadoXML);
        }
        private BE_TuplaXML CrearCostoXML(BE_Costo Costo)
        {
            BE_TuplaXML nuevaTupla = new BE_TuplaXML();
            nuevaTupla.NodoRoot = "Costos";
            nuevaTupla.NodoLeaf = "Costo";
            XElement nuevoCosto = new XElement("Costo",
                new XElement("ID", Costo.Codigo.ToString()),
                new XElement("Fecha_Costeo", Costo.DíaCosteo.ToString("dd/MM/yyyy")),
                new XElement("Tamaño_Lote_Costeo", Costo.TamañoLoteCosteo.ToString()),
                new XElement("Materia_Prima", Costo.MateriaPrima.ToString()),
                new XElement("Horas_Hombre", Costo.HorasHombre.ToString()),
                new XElement("Energía", Costo.Energía.ToString()),
                new XElement("Otros_Gastos", Costo.OtrosGastos.ToString()),
                new XElement("Tipo_Material", Costo is BE_CostoIngrediente ? ((BE_CostoIngrediente)Costo).Tipo.ToString(): Costo is BE_CostoBebida ? ((BE_CostoBebida)Costo).Tipo.ToString(): ((BE_CostoPlato)Costo).Tipo.ToString()),
                new XElement("ID_Material", Costo is BE_CostoIngrediente ? ((BE_CostoIngrediente)Costo).Material.Codigo.ToString() : Costo is BE_CostoBebida ? ((BE_CostoBebida)Costo).Material.Codigo.ToString() : ((BE_CostoPlato)Costo).Material.Codigo.ToString())
                );
            nuevaTupla.Xelement = nuevoCosto;
            return nuevaTupla;
        }
    }
}
