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
    public class MPP_Plato_Stock : IGestionable<BE_Plato_Stock>, IMovimentable<BE_Plato_Stock, BE_Compra>
    {
        private static List<BE_TuplaXML> ListadoXML;
        private static MPP_Plato_Stock mapper = null;
        public static MPP_Plato_Stock DevolverInstancia()
        {
            if (mapper == null) mapper = new MPP_Plato_Stock();
            else ListadoXML = null;
            return mapper;
        }
        ~MPP_Plato_Stock()
        {
            mapper = null;
            ListadoXML = null;
        }
        public bool AgregarStock(BE_Plato_Stock material, BE_Compra compra)
        {
            ListadoXML = new List<BE_TuplaXML>();
            if (Xml_Database.DevolverInstancia().ExisteMatLot(CrearPlato_StockXML(material)))
            {
                return ModificarMatLot(material, compra);
            }
            else
            {
                return Guardar(material,compra);
            }
        }
        
        public bool Baja(BE_Plato_Stock material)
        {
            ListadoXML = new List<BE_TuplaXML>();
            ListadoXML.Add(CrearPlato_StockXML(material));
            return Xml_Database.DevolverInstancia().Baja(ListadoXML);
        }

        public DateTime DevolverFechaVencimiento(BE_Plato_Stock material)
        {
            throw new NotImplementedException(); 
        }

        public decimal DevolverStock(BE_Plato_Stock material, bool estelote)
        {
            if (estelote)
            {
                return ListarObjeto(material).Stock;
            }
            else
            {
                return Listar().Where(x => x.Material.Codigo == material.Material.Codigo).Sum(x => x.Stock);
            }
        }

        public bool Guardar(BE_Plato_Stock material)
        {
            ListadoXML = new List<BE_TuplaXML>();
            ListadoXML.Add(CrearPlato_StockXML(material));
            return Xml_Database.DevolverInstancia().Escribir(ListadoXML);
        }
        public bool Guardar(BE_Plato_Stock material, BE_Compra compra)
        {
            ListadoXML = new List<BE_TuplaXML>();
            ListadoXML.Add(CrearPlato_StockXML(material));
            ListadoXML.Add(CrearMaterialCompraXML(material, compra));
            return Xml_Database.DevolverInstancia().Escribir(ListadoXML);
        }

        public bool Existe(BE_Plato_Stock plato)
        {
            return Xml_Database.DevolverInstancia().Existe(CrearPlato_StockXML(plato), "ID_Ingrediente");
        }

        public List<BE_Plato_Stock> Listar()
        {
            DataSet ds = new DataSet();
            ds = Xml_Database.DevolverInstancia().Listar();

            List<BE_Plato_Stock> listaMateriales = ds.Tables.Contains("Plato-Stock") != false ?
                (from mat in ds.Tables["Plato-Stock"].AsEnumerable()
                 select new BE_Plato_Stock
                 {
                     Codigo = Convert.ToInt32(mat[0]),
                     Material = MPP_Plato.DevolverInstancia().ListarObjeto(new BE_Plato { Codigo = Convert.ToInt32(mat[1])},ds),
                     Stock = Convert.ToDecimal(mat[2]),
                     FechaCreacion = Convert.ToDateTime(mat[3]),
                     Lote = Convert.ToString(mat[4])

                 }).ToList() : null;

            return listaMateriales;
        }

        public BE_Plato_Stock ListarObjeto(BE_Plato_Stock material,DataSet ds=null)
        {
            if (ds is null)
            {
                ds = new DataSet();
                ds = Xml_Database.DevolverInstancia().Listar();
            }
   
            BE_Plato_Stock oBE_Plato_Stock = ds.Tables.Contains("Plato-Stock") != false ?
                (from mat in ds.Tables["Plato-Stock"].AsEnumerable()
                 where Convert.ToInt32(mat[0]) == material.Codigo && mat[5].ToString() == material.Lote
                 select new BE_Plato_Stock
                 {
                     Codigo = Convert.ToInt32(mat[0]),
                     Material = MPP_Plato.DevolverInstancia().ListarObjeto(new BE_Plato { Codigo = Convert.ToInt32(mat[1]) },ds),
                     Stock = Convert.ToDecimal(mat[2]),
                     FechaCreacion = Convert.ToDateTime(mat[3]),
                     Lote = Convert.ToString(mat[4]),
                 }).FirstOrDefault() : null;

            return oBE_Plato_Stock;
        }

        public BE_Plato_Stock ListarXCompra(BE_Compra compra, DataSet ds=null)
        {
            if (ds is null)
            {
                ds = new DataSet();
                ds = Xml_Database.DevolverInstancia().Listar();
            }

            BE_Plato_Stock Plato_Stock = ds.Tables.Contains("Plato-Stock") != false ?
                (from mat in ds.Tables["Plato-Stock"].AsEnumerable()
                 join ms in ds.Tables["Plato-Compra"].AsEnumerable()
                 on compra.Codigo equals Convert.ToInt32(ms[1])
                 join com in ds.Tables["Compra"].AsEnumerable()
                 on compra.Codigo equals Convert.ToInt32(com[0])
                 select new BE_Plato_Stock
                 {
                     Codigo = Convert.ToInt32(mat[0]),
                     Material = MPP_Plato.DevolverInstancia().ListarObjeto(new BE_Plato { Codigo = Convert.ToInt32(mat[1]) },ds),
                     Stock = Convert.ToDecimal(mat[2]),
                     FechaCreacion = Convert.ToDateTime(mat[3]),
                     Lote = Convert.ToString(mat[4])
                 }).FirstOrDefault() : null;
            return Plato_Stock;
        }
        public List<BE_Plato_Stock> ListarConStock()
        {
            DataSet ds = new DataSet();
            ds = Xml_Database.DevolverInstancia().Listar();

            List<BE_Plato_Stock> listaIngredientes = ds.Tables.Contains("Plato") != false && ds.Tables.Contains("Plato-Stock") != false ?
                (from mat in ds.Tables["Plato-Stock"].AsEnumerable()
                 join ing in ds.Tables["Bebida"].AsEnumerable()
                 on Convert.ToInt32(mat[1]) equals Convert.ToInt32(ing[0])
                 where Convert.ToDecimal(mat[2]) > 0
                 select new BE_Plato_Stock
                 {
                     Codigo = Convert.ToInt32(mat[0]),
                     Material = MPP_Plato.DevolverInstancia().ListarObjeto(new BE_Plato { Codigo = Convert.ToInt32(mat[1]) },ds),
                     Stock = Convert.ToDecimal(mat[2]),
                     FechaCreacion = Convert.ToDateTime(mat[3]),
                     Lote = Convert.ToString(mat[4])

                 }).Where(x=> x.Material.Activo).ToList() : null;
            return listaIngredientes;
        }
        public List<BE_Plato_Stock> ListarParaVenta()
        {
            DataSet ds = new DataSet();
            ds = Xml_Database.DevolverInstancia().Listar();

            List<BE_Plato_Stock> listaPlatos = ds.Tables.Contains("Plato") != false && ds.Tables.Contains("Plato-Stock") != false ?
                (from mat in ds.Tables["Plato-Stock"].AsEnumerable()
                 join ing in ds.Tables["Bebida"].AsEnumerable()
                 on Convert.ToInt32(mat[1]) equals Convert.ToInt32(ing[0])
                 where Convert.ToDecimal(mat[2]) > 0
                 select new BE_Plato_Stock
                 {
                     Codigo = Convert.ToInt32(mat[0]),
                     Material = MPP_Plato.DevolverInstancia().ListarObjeto(new BE_Plato { Codigo = Convert.ToInt32(mat[1]) }, ds),
                     Stock = Convert.ToDecimal(mat[2]),
                     FechaCreacion = Convert.ToDateTime(mat[3]),
                     Lote = Convert.ToString(mat[4])

                 }).Where(x => x.Material.Activo).GroupBy(x => x.Material.Codigo).Select(y => y.First()).ToList() : null;
            return listaPlatos;
        }
        public BE_Plato_Stock BuscarXLote(BE_Compra compra, string lote,DataSet ds=null)
        {
            if (ds is null)
            {
                ds = new DataSet();
                ds = Xml_Database.DevolverInstancia().Listar();
            }

            BE_Plato_Stock oBE_Plato_Stock = ds.Tables.Contains("Plato-Stock") != false ?
                (from mat in ds.Tables["Plato-Stock"].AsEnumerable()
                 where Convert.ToInt32(mat[1]) == ((BE_CompraIngrediente)compra).ID_Material.Codigo && mat[4].ToString() == lote
                 select new BE_Plato_Stock
                 {
                     Codigo = Convert.ToInt32(mat[0]),
                     Material = MPP_Plato.DevolverInstancia().ListarObjeto(new BE_Plato { Codigo = Convert.ToInt32(mat[1]) },ds),
                     Stock = Convert.ToDecimal(mat[2]),
                     FechaCreacion = Convert.ToDateTime(mat[3]),
                     Lote = Convert.ToString(mat[4]),
                 }).FirstOrDefault() : null;

            return oBE_Plato_Stock;
        }
        public bool Modificar(BE_Plato_Stock material)
        {
            ListadoXML = new List<BE_TuplaXML>();
            ListadoXML.Add(CrearPlato_StockXML(material));
            return Xml_Database.DevolverInstancia().Modificar(ListadoXML);
        }
        public bool ModificarMatLot(BE_Plato_Stock material, BE_Compra compra)
        {
            ListadoXML = new List<BE_TuplaXML>();
            if (compra.Status != StausComp.Devolucion)
            {
                ListadoXML.Add(CrearMaterialCompraXML(material, compra));
                Xml_Database.DevolverInstancia().Escribir(ListadoXML);
                ListadoXML.Clear();
            }
            ListadoXML.Add(CrearPlato_StockXML(material));
            return Xml_Database.DevolverInstancia().ModificarMatLot(ListadoXML);
        }

        private BE_TuplaXML CrearPlato_StockXML(BE_Plato_Stock material)
        {
            BE_TuplaXML nuevaTupla = new BE_TuplaXML();
            nuevaTupla.NodoRoot = "Platos-Stock";
            nuevaTupla.NodoLeaf = "Plato-Stock";
            XElement nuevoMaterial = new XElement("Plato-Stock",
                new XElement("ID", Cálculos.IDPadleft(material.Codigo)),
                new XElement("ID_Ingrediente", material.Material.Codigo.ToString()),
                new XElement("Stock", material.Stock.ToString()),
                new XElement("Fecha_Creacion", material.FechaCreacion.Value.ToString("dd/MM/yyyy")),
                new XElement("Lote", material.Lote)
                );
            nuevaTupla.Xelement = nuevoMaterial;
            return nuevaTupla;
        }

        private BE_TuplaXML CrearMaterialCompraXML(BE_Plato_Stock material, BE_Compra compra)
        {
            BE_TuplaXML nuevaTupla = new BE_TuplaXML();
            nuevaTupla.NodoRoot = "Platos-Compras";
            nuevaTupla.NodoLeaf = "Plato-Compra";
            XElement nuevoMaterialCompra = new XElement("Plato-Compra",
                new XElement("ID_Plato-Stock", material.Codigo.ToString()),
                new XElement("ID_Compra", Cálculos.IDPadleft(compra.Codigo))
                );
            nuevaTupla.Xelement = nuevoMaterialCompra;
            return nuevaTupla;
        }
    }
}
