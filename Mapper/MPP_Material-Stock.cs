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
        Xml_Database Acceso;
        List<BE_TuplaXML> ListadoXML;

        public MPP_Material_Stock()
        {
            ListadoXML = new List<BE_TuplaXML>();
        }

        public bool AgregarStock(BE_Material_Stock material, BE_Compra compra)
        {
            Acceso = new Xml_Database();
            if (Acceso.ExisteMatLot(CrearMaterial_StockXML(material)))
            {
                return ModificarMatLot(material);
            }
            else
            {
                return Guardar(material,compra);
            }
        }
        
        public bool Baja(BE_Material_Stock material)
        {
            Acceso = new Xml_Database();
            ListadoXML.Add(CrearMaterial_StockXML(material));
            return Acceso.Baja(ListadoXML);
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
            Acceso = new Xml_Database();
            ListadoXML.Add(CrearMaterial_StockXML(material));
            return Acceso.Escribir(ListadoXML);
        }
        public bool Guardar(BE_Material_Stock material, BE_Compra compra)
        {
            Acceso = new Xml_Database();
            ListadoXML.Add(CrearMaterial_StockXML(material));
            ListadoXML.Add(CrearMaterialCompraXML(material, compra));
            return Acceso.Escribir(ListadoXML);
        }

        public List<BE_Material_Stock> Listar()
        {
            Acceso = new Xml_Database();
            DataSet ds = new DataSet();
            ds = Acceso.Listar();

            List<BE_Material_Stock> listaMateriales = ds.Tables.Contains("Material-Stock") != false ? (from mat in ds.Tables["Material-Stock"].AsEnumerable()
                                                                                                       select new BE_Material_Stock
                                                                                                       {
                                                                                                           Codigo = Convert.ToInt32(mat[0]),
                                                                                                           Material = ds.Tables.Contains("Ingrediente") != false ? (from ing in ds.Tables["Ingrediente"].AsEnumerable()
                                                                                                                                                                    where Convert.ToInt32(ing[0]) == Convert.ToInt32(mat[1])
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
                                                                                                                                                                        CostoUnitario = Convert.ToDecimal(ing[8])

                                                                                                                                                                    }).FirstOrDefault() : null,
                                                                                                           Stock = Convert.ToDecimal(mat[2]),
                                                                                                           FechaCreacion = Convert.ToDateTime(mat[3]),
                                                                                                           Lote = Convert.ToString(mat[4])

                                                                                                       }).ToList() : null;

            return listaMateriales;
        }

        public BE_Material_Stock ListarObjeto(BE_Material_Stock material)
        {
            Acceso = new Xml_Database();
            DataSet ds = new DataSet();
            ds = Acceso.Listar();

            BE_Material_Stock oBE_Material_Stock = ds.Tables.Contains("Material-Stock") != false ? (from mat in ds.Tables["Material-Stock"].AsEnumerable()
                                                                                                    where Convert.ToInt32(mat[0]) == material.Codigo && mat[5].ToString() == material.Lote
                                                                                                    select new BE_Material_Stock
                                                                                                    {
                                                                                                        Codigo = Convert.ToInt32(mat[0]),
                                                                                                        Material = ds.Tables.Contains("Ingrediente") != false ? (from ing in ds.Tables["Ingrediente"].AsEnumerable()
                                                                                                                                                                 where Convert.ToInt32(ing[0]) == Convert.ToInt32(mat[1])
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
                                                                                                                                                                     CostoUnitario = Convert.ToDecimal(ing[8])

                                                                                                                                                                 }).FirstOrDefault() : null,
                                                                                                        Stock = Convert.ToDecimal(mat[2]),
                                                                                                        FechaCreacion = Convert.ToDateTime(mat[3]),
                                                                                                        Lote = Convert.ToString(mat[4]),
                                                                                                    }).FirstOrDefault() : null;

            return oBE_Material_Stock;
        }

        public BE_Material_Stock ListarXCompra(BE_Compra compra)
        {
            Acceso = new Xml_Database();
            DataSet ds = new DataSet();
            ds = Acceso.Listar();

            BE_Material_Stock Material_Stock = ds.Tables.Contains("Material-Stock") != false ? (from mat in ds.Tables["Material-Stock"].AsEnumerable()
                                                                                                join ms in ds.Tables["Material-Compra"].AsEnumerable()
                                                                                                on compra.Codigo equals Convert.ToInt32(ms[1])
                                                                                                join com in ds.Tables["Compra"].AsEnumerable()
                                                                                                on compra.Codigo equals Convert.ToInt32(com[0])
                                                                                                select new BE_Material_Stock
                                                                                                {
                                                                                                    Codigo = Convert.ToInt32(mat[0]),
                                                                                                    Material = ds.Tables.Contains("Ingrediente") != false ? (from ing in ds.Tables["Ingrediente"].AsEnumerable()
                                                                                                                                                             where Convert.ToInt32(ing[0]) == Convert.ToInt32(mat[1])
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
                                                                                                                                                                 CostoUnitario = Convert.ToDecimal(ing[8])

                                                                                                                                                             }).FirstOrDefault() : null,
                                                                                                    Stock = Convert.ToDecimal(mat[2]),
                                                                                                    FechaCreacion = Convert.ToDateTime(mat[3]),
                                                                                                    Lote = Convert.ToString(mat[4])
                                                                                                }).FirstOrDefault() : null;
            return Material_Stock;
        }

        public bool Modificar(BE_Material_Stock material)
        {
            Acceso = new Xml_Database();
            ListadoXML.Add(CrearMaterial_StockXML(material));
            return Acceso.Modificar(ListadoXML);
        }
        public bool ModificarMatLot(BE_Material_Stock material)
        {
            Acceso = new Xml_Database();
            ListadoXML.Add(CrearMaterial_StockXML(material));
            return Acceso.ModificarMatLot(ListadoXML);
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
