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
    public class MPP_Bebida_Stock : IGestionable<BE_Bebida_Stock>, IMovimentable<BE_Bebida_Stock, BE_Compra>
    {
        private static List<BE_TuplaXML> ListadoXML;
        private static MPP_Bebida_Stock mapper = null;
        public static MPP_Bebida_Stock DevolverInstancia()
        {
            if (mapper == null) mapper = new MPP_Bebida_Stock();
            else ListadoXML = null;
            return mapper;
        }
        ~MPP_Bebida_Stock()
        {
            mapper = null;
            ListadoXML = null;
        }
        public bool AgregarStock(BE_Bebida_Stock material, BE_Compra compra)
        {
            ListadoXML = new List<BE_TuplaXML>();
            if (Xml_Database.DevolverInstancia().ExisteMatLot(CrearBebida_StockXML(material)))
            {
                return ModificarMatLot(material, compra);
            }
            else
            {
                return Guardar(material,compra);
            }
        }
        
        public bool Baja(BE_Bebida_Stock material)
        {
            ListadoXML = new List<BE_TuplaXML>();
            ListadoXML.Add(CrearBebida_StockXML(material));
            return Xml_Database.DevolverInstancia().Baja(ListadoXML);
        }

        public DateTime DevolverFechaVencimiento(BE_Bebida_Stock material)
        {
            return material.FechaCreacion.Value.AddDays(material.Material.VidaUtil);
        }

        public decimal DevolverStock(BE_Bebida_Stock material, bool estelote)
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

        public bool Guardar(BE_Bebida_Stock material)
        {
            ListadoXML = new List<BE_TuplaXML>();
            ListadoXML.Add(CrearBebida_StockXML(material));
            return Xml_Database.DevolverInstancia().Escribir(ListadoXML);
        }
        public bool Guardar(BE_Bebida_Stock material, BE_Compra compra)
        {
            ListadoXML = new List<BE_TuplaXML>();
            ListadoXML.Add(CrearBebida_StockXML(material));
            ListadoXML.Add(CrearMaterialCompraXML(material, compra));
            return Xml_Database.DevolverInstancia().Escribir(ListadoXML);
        }

        public List<BE_Bebida_Stock> Listar()
        {
            DataSet ds = new DataSet();
            ds = Xml_Database.DevolverInstancia().Listar();

            List<BE_Bebida_Stock> listaMateriales = ds.Tables.Contains("Bebida-Stock") != false ?
                (from mat in ds.Tables["Bebida-Stock"].AsEnumerable()
                 select new BE_Bebida_Stock
                 {
                     Codigo = Convert.ToInt32(mat[0]),
                     Material = MPP_Bebida.DevolverInstancia().ListarObjeto(new BE_Bebida { Codigo = Convert.ToInt32(mat[1])},ds),
                     Stock = Convert.ToDecimal(mat[2]),
                     FechaCreacion = Convert.ToDateTime(mat[3]),
                     Lote = Convert.ToString(mat[4])

                 }).ToList() : null;

            return listaMateriales;
        }

        public BE_Bebida_Stock ListarObjeto(BE_Bebida_Stock material,DataSet ds=null)
        {
            if (ds is null)
            {
                ds = new DataSet();
                ds = Xml_Database.DevolverInstancia().Listar();
            }
   
            BE_Bebida_Stock oBE_Bebida_Stock = ds.Tables.Contains("Bebida-Stock") != false ?
                (from mat in ds.Tables["Bebida-Stock"].AsEnumerable()
                 where Convert.ToInt32(mat[0]) == material.Codigo && mat[5].ToString() == material.Lote
                 select new BE_Bebida_Stock
                 {
                     Codigo = Convert.ToInt32(mat[0]),
                     Material = MPP_Bebida.DevolverInstancia().ListarObjeto(new BE_Bebida { Codigo = Convert.ToInt32(mat[1]) },ds),
                     Stock = Convert.ToDecimal(mat[2]),
                     FechaCreacion = Convert.ToDateTime(mat[3]),
                     Lote = Convert.ToString(mat[4]),
                 }).FirstOrDefault() : null;

            return oBE_Bebida_Stock;
        }

        public BE_Bebida_Stock ListarXCompra(BE_Compra compra, DataSet ds=null)
        {
            if (ds is null)
            {
                ds = new DataSet();
                ds = Xml_Database.DevolverInstancia().Listar();
            }

            BE_Bebida_Stock Bebida_Stock = ds.Tables.Contains("Bebida-Stock") != false ?
                (from mat in ds.Tables["Bebida-Stock"].AsEnumerable()
                 join ms in ds.Tables["Bebida-Compra"].AsEnumerable()
                 on compra.Codigo equals Convert.ToInt32(ms[1])
                 join com in ds.Tables["Compra"].AsEnumerable()
                 on compra.Codigo equals Convert.ToInt32(com[0])
                 select new BE_Bebida_Stock
                 {
                     Codigo = Convert.ToInt32(mat[0]),
                     Material = MPP_Bebida.DevolverInstancia().ListarObjeto(new BE_Bebida { Codigo = Convert.ToInt32(mat[1]) },ds),
                     Stock = Convert.ToDecimal(mat[2]),
                     FechaCreacion = Convert.ToDateTime(mat[3]),
                     Lote = Convert.ToString(mat[4])
                 }).FirstOrDefault() : null;
            return Bebida_Stock;
        }
        public List<BE_Bebida_Stock> ListarConStock()
        {
            DataSet ds = new DataSet();
            ds = Xml_Database.DevolverInstancia().Listar();

            List<BE_Bebida_Stock> listaBebidas = ds.Tables.Contains("Bebida") != false 
                && ds.Tables.Contains("Bebida-Stock") ?
                (from mat in ds.Tables["Bebida-Stock"].AsEnumerable()
                 join ing in ds.Tables["Bebida"].AsEnumerable()
                 on Convert.ToInt32(mat[1]) equals Convert.ToInt32(ing[0])
                 where Convert.ToDecimal(mat[2]) > 0
                 select new BE_Bebida_Stock
                 {
                     Codigo = Convert.ToInt32(mat[0]),
                     Material = MPP_Bebida.DevolverInstancia().ListarObjeto(new BE_Bebida { Codigo = Convert.ToInt32(mat[1]) },ds),
                     Stock = Convert.ToDecimal(mat[2]),
                     FechaCreacion = Convert.ToDateTime(mat[3]),
                     Lote = Convert.ToString(mat[4])

                 }).ToList() : null;
            return listaBebidas;
        }
        public BE_Bebida_Stock BuscarXLote(BE_Compra compra, string lote,DataSet ds=null)
        {
            if (ds is null)
            {
                ds = new DataSet();
                ds = Xml_Database.DevolverInstancia().Listar();
            }

            BE_Bebida_Stock oBE_Bebida_Stock = ds.Tables.Contains("Bebida-Stock") != false ?
                (from mat in ds.Tables["Bebida-Stock"].AsEnumerable()
                 where Convert.ToInt32(mat[1]) == ((BE_CompraBebida)compra).ID_Material.Codigo && mat[4].ToString() == lote
                 select new BE_Bebida_Stock
                 {
                     Codigo = Convert.ToInt32(mat[0]),
                     Material = MPP_Bebida.DevolverInstancia().ListarObjeto(new BE_Bebida { Codigo = Convert.ToInt32(mat[1]) },ds),
                     Stock = Convert.ToDecimal(mat[2]),
                     FechaCreacion = Convert.ToDateTime(mat[3]),
                     Lote = Convert.ToString(mat[4]),
                 }).FirstOrDefault() : null;

            return oBE_Bebida_Stock;
        }
        public bool Modificar(BE_Bebida_Stock material)
        {
            ListadoXML = new List<BE_TuplaXML>();
            ListadoXML.Add(CrearBebida_StockXML(material));
            return Xml_Database.DevolverInstancia().Modificar(ListadoXML);
        }
        public bool ModificarMatLot(BE_Bebida_Stock material, BE_Compra compra)
        {
            ListadoXML = new List<BE_TuplaXML>();
            if (compra.Status != StausComp.Devolucion)
            {
                ListadoXML.Add(CrearMaterialCompraXML(material, compra));
                Xml_Database.DevolverInstancia().Escribir(ListadoXML);
                ListadoXML.Clear();
            }
            ListadoXML.Add(CrearBebida_StockXML(material));
            return Xml_Database.DevolverInstancia().ModificarMatLot(ListadoXML);
        }

        private BE_TuplaXML CrearBebida_StockXML(BE_Bebida_Stock material)
        {
            BE_TuplaXML nuevaTupla = new BE_TuplaXML();
            nuevaTupla.NodoRoot = "Bebidas-Stock";
            nuevaTupla.NodoLeaf = "Bebida-Stock";
            XElement nuevoMaterial = new XElement("Bebida-Stock",
                new XElement("ID", Cálculos.IDPadleft(material.Codigo)),
                new XElement("ID_Ingrediente", material.Material.Codigo.ToString()),
                new XElement("Stock", material.Stock.ToString()),
                new XElement("Fecha_Creacion", material.FechaCreacion.Value.ToString("dd/MM/yyyy")),
                new XElement("Lote", material.Lote)
                );
            nuevaTupla.Xelement = nuevoMaterial;
            return nuevaTupla;
        }

        private BE_TuplaXML CrearMaterialCompraXML(BE_Bebida_Stock material, BE_Compra compra)
        {
            BE_TuplaXML nuevaTupla = new BE_TuplaXML();
            nuevaTupla.NodoRoot = "Bebidas-Compras";
            nuevaTupla.NodoLeaf = "Bebida-Compra";
            XElement nuevoMaterialCompra = new XElement("Bebida-Compra",
                new XElement("ID_Bebida-Stock", material.Codigo.ToString()),
                new XElement("ID_Compra", Cálculos.IDPadleft(compra.Codigo))
                );
            nuevaTupla.Xelement = nuevoMaterialCompra;
            return nuevaTupla;
        }
    }
}
