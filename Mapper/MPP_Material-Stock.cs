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
    public class MPP_Material_Stock : IGestionable<BE_Material_Stock>, IMovimentable<BE_Material_Stock, BE_Compra>
    {
        private static List<BE_TuplaXML> ListadoXML;
        private static MPP_Material_Stock mapper = null;
        public static MPP_Material_Stock DevolverInstancia()
        {
            if (mapper == null) mapper = new MPP_Material_Stock();
            else ListadoXML = null;
            return mapper;
        }
        ~MPP_Material_Stock()
        {
            mapper = null;
            ListadoXML = null;
        }
        public bool AgregarStock(BE_Material_Stock material, BE_Compra compra)
        {
            ListadoXML = new List<BE_TuplaXML>();
            if (Xml_Database.DevolverInstancia().ExisteMatLot(CrearMaterial_StockXML(material)))
            {
                return ModificarMatLot(material, compra);
            }
            else
            {
                return Guardar(material,compra);
            }
        }
        
        public bool Baja(BE_Material_Stock material)
        {
            ListadoXML = new List<BE_TuplaXML>();
            ListadoXML.Add(CrearMaterial_StockXML(material));
            return Xml_Database.DevolverInstancia().Baja(ListadoXML);
        }

        public DateTime DevolverFechaVencimiento(BE_Material_Stock material)
        {
            return material.FechaCreacion.Value.AddDays(material.Material.VidaUtil);
        }

        public decimal DevolverStock(BE_Material_Stock material, bool estelote)
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

        public bool Guardar(BE_Material_Stock material)
        {
            ListadoXML = new List<BE_TuplaXML>();
            ListadoXML.Add(CrearMaterial_StockXML(material));
            return Xml_Database.DevolverInstancia().Escribir(ListadoXML);
        }
        public bool Guardar(BE_Material_Stock material, BE_Compra compra)
        {
            ListadoXML = new List<BE_TuplaXML>();
            ListadoXML.Add(CrearMaterial_StockXML(material));
            ListadoXML.Add(CrearMaterialCompraXML(material, compra));
            return Xml_Database.DevolverInstancia().Escribir(ListadoXML);
        }

        public List<BE_Material_Stock> Listar()
        {
            DataSet ds = new DataSet();
            ds = Xml_Database.DevolverInstancia().Listar();

            List<BE_Material_Stock> listaMateriales = ds.Tables.Contains("Material-Stock") != false ?
                (from mat in ds.Tables["Material-Stock"].AsEnumerable()
                 select new BE_Material_Stock
                 {
                     Codigo = Convert.ToInt32(mat[0]),
                     Material = MPP_Ingrediente.DevolverInstancia().ListarObjeto(new BE_Ingrediente { Codigo = Convert.ToInt32(mat[1])},ds),
                     Stock = Convert.ToDecimal(mat[2]),
                     FechaCreacion = Convert.ToDateTime(mat[3]),
                     Lote = Convert.ToString(mat[4])
                 }).ToList() : null;

            return listaMateriales;
        }

        public BE_Material_Stock ListarObjeto(BE_Material_Stock material,DataSet ds=null)
        {
            if (ds is null)
            {
                ds = new DataSet();
                ds = Xml_Database.DevolverInstancia().Listar();
            }
   
            BE_Material_Stock oBE_Material_Stock = ds.Tables.Contains("Material-Stock") != false ?
                (from mat in ds.Tables["Material-Stock"].AsEnumerable()
                 where Convert.ToInt32(mat[0]) == material.Codigo && mat[5].ToString() == material.Lote
                 select new BE_Material_Stock
                 {
                     Codigo = Convert.ToInt32(mat[0]),
                     Material = MPP_Ingrediente.DevolverInstancia().ListarObjeto(new BE_Ingrediente { Codigo = Convert.ToInt32(mat[1]) },ds),
                     Stock = Convert.ToDecimal(mat[2]),
                     FechaCreacion = Convert.ToDateTime(mat[3]),
                     Lote = Convert.ToString(mat[4])
                 }).FirstOrDefault() : null;
            oBE_Material_Stock.FechaVencimiento = DevolverFechaVencimiento(oBE_Material_Stock);
            return oBE_Material_Stock;
        }

        public BE_Material_Stock ListarXCompra(BE_Compra compra, DataSet ds=null)
        {
            if (ds is null)
            {
                ds = new DataSet();
                ds = Xml_Database.DevolverInstancia().Listar();
            }

            BE_Material_Stock Material_Stock = ds.Tables.Contains("Material-Stock") != false ?
                (from mat in ds.Tables["Material-Stock"].AsEnumerable()
                 join ms in ds.Tables["Material-Compra"].AsEnumerable()
                 on compra.Codigo equals Convert.ToInt32(ms[1])
                 join com in ds.Tables["Compra"].AsEnumerable()
                 on compra.Codigo equals Convert.ToInt32(com[0])
                 select new BE_Material_Stock
                 {
                     Codigo = Convert.ToInt32(mat[0]),
                     Material = MPP_Ingrediente.DevolverInstancia().ListarObjeto(new BE_Ingrediente { Codigo = Convert.ToInt32(mat[1]) },ds),
                     Stock = Convert.ToDecimal(mat[2]),
                     FechaCreacion = Convert.ToDateTime(mat[3]),
                     Lote = Convert.ToString(mat[4])
                 }).FirstOrDefault() : null;
            Material_Stock.FechaVencimiento = DevolverFechaVencimiento(Material_Stock);
            return Material_Stock;
        }
        public List<BE_Material_Stock> ListarConStock()
        {
            DataSet ds = new DataSet();
            ds = Xml_Database.DevolverInstancia().Listar();

            List<BE_Material_Stock> listaIngredientes = ds.Tables.Contains("Ingrediente") != false ?
                (from mat in ds.Tables["Material-Stock"].AsEnumerable()
                 join ing in ds.Tables["Ingrediente"].AsEnumerable()
                 on Convert.ToInt32(mat[1]) equals Convert.ToInt32(ing[0])
                 where Convert.ToDecimal(mat[2]) > 0
                 select new BE_Material_Stock
                 {
                     Codigo = Convert.ToInt32(mat[0]),
                     Material = MPP_Ingrediente.DevolverInstancia().ListarObjeto(new BE_Ingrediente { Codigo = Convert.ToInt32(mat[1]) },ds),
                     Stock = Convert.ToDecimal(mat[2]),
                     FechaCreacion = Convert.ToDateTime(mat[3]),
                     Lote = Convert.ToString(mat[4])

                 }).Where(x => x.Material.Activo).ToList() : null;
            return listaIngredientes;
        }
        public List<BE_Material_Stock> ListarConStock(BE_Ingrediente ingrediente)
        {
            DataSet ds = new DataSet();
            ds = Xml_Database.DevolverInstancia().Listar();

            List<BE_Material_Stock> listaIngredientes = ds.Tables.Contains("Ingrediente") != false ?
                (from mat in ds.Tables["Material-Stock"].AsEnumerable()
                 join ing in ds.Tables["Ingrediente"].AsEnumerable()
                 on Convert.ToInt32(mat[1]) equals Convert.ToInt32(ing[0])
                 where Convert.ToInt32(ing[0]) == ingrediente.Codigo &&
                 Convert.ToDecimal(mat[2]) > 0
                 select new BE_Material_Stock
                 {
                     Codigo = Convert.ToInt32(mat[0]),
                     Material = MPP_Ingrediente.DevolverInstancia().ListarObjeto(new BE_Ingrediente { Codigo = Convert.ToInt32(mat[1]) }, ds),
                     Stock = Convert.ToDecimal(mat[2]),
                     FechaCreacion = Convert.ToDateTime(mat[3]),
                     Lote = Convert.ToString(mat[4])

                 }).ToList() : null;
            return listaIngredientes;
        }
        public BE_Material_Stock BuscarXLote(BE_Compra compra, string lote,DataSet ds=null)
        {
            if (ds is null)
            {
                ds = new DataSet();
                ds = Xml_Database.DevolverInstancia().Listar();
            }

            BE_Material_Stock oBE_Material_Stock = ds.Tables.Contains("Material-Stock") != false ?
                (from mat in ds.Tables["Material-Stock"].AsEnumerable()
                 where Convert.ToInt32(mat[1]) == ((BE_CompraIngrediente)compra).ID_Material.Codigo && mat[4].ToString() == lote
                 select new BE_Material_Stock
                 {
                     Codigo = Convert.ToInt32(mat[0]),
                     Material = MPP_Ingrediente.DevolverInstancia().ListarObjeto(new BE_Ingrediente { Codigo = Convert.ToInt32(mat[1]) },ds),
                     Stock = Convert.ToDecimal(mat[2]),
                     FechaCreacion = Convert.ToDateTime(mat[3]),
                     Lote = Convert.ToString(mat[4]),
                 }).FirstOrDefault() : null;
            oBE_Material_Stock.FechaVencimiento = DevolverFechaVencimiento(oBE_Material_Stock);
            return oBE_Material_Stock;
        }
        public bool Modificar(BE_Material_Stock material)
        {
            ListadoXML = new List<BE_TuplaXML>();
            ListadoXML.Add(CrearMaterial_StockXML(material));
            return Xml_Database.DevolverInstancia().Modificar(ListadoXML);
        }
        public bool Modificar(List<BE_Material_Stock> material)
        {
            ListadoXML = new List<BE_TuplaXML>();
            foreach(BE_Material_Stock mat in material)
            {
            ListadoXML.Add(CrearMaterial_StockXML(mat));
            }
            return Xml_Database.DevolverInstancia().Modificar(ListadoXML);
        }

        public bool ModificarMatLot(BE_Material_Stock material, BE_Compra compra)
        {
            ListadoXML = new List<BE_TuplaXML>();
            if (compra.Status != StausComp.Devolucion)
            {
                ListadoXML.Add(CrearMaterialCompraXML(material, compra));
                Xml_Database.DevolverInstancia().Escribir(ListadoXML);
                ListadoXML.Clear();
            }
            ListadoXML.Add(CrearMaterial_StockXML(material));
            return Xml_Database.DevolverInstancia().ModificarMatLot(ListadoXML);
        }

        private BE_TuplaXML CrearMaterial_StockXML(BE_Material_Stock material)
        {
            BE_TuplaXML nuevaTupla = new BE_TuplaXML();
            nuevaTupla.NodoRoot = "Materiales-Stock";
            nuevaTupla.NodoLeaf = "Material-Stock";
            XElement nuevoMaterial = new XElement("Material-Stock",
                new XElement("ID", Cálculos.IDPadleft(material.Codigo)),
                new XElement("ID_Ingrediente", material.Material.Codigo.ToString()),
                new XElement("Stock", material.Stock.ToString()),
                new XElement("Fecha_Creacion", material.FechaCreacion.Value.ToString("dd/MM/yyyy")),
                new XElement("Lote", material.Lote)
                );
            nuevaTupla.Xelement = nuevoMaterial;
            return nuevaTupla;
        }

        private BE_TuplaXML CrearMaterialCompraXML(BE_Material_Stock material, BE_Compra compra)
        {
            BE_TuplaXML nuevaTupla = new BE_TuplaXML();
            nuevaTupla.NodoRoot = "Materiales-Compras";
            nuevaTupla.NodoLeaf = "Material-Compra";
            XElement nuevoMaterialCompra = new XElement("Material-Compra",
                new XElement("ID_Material-Stock", material.Codigo.ToString()),
                new XElement("ID_Compra", Cálculos.IDPadleft(compra.Codigo))
                );
            nuevaTupla.Xelement = nuevoMaterialCompra;
            return nuevaTupla;
        }
    }
}
