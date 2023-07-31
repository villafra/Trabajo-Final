using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraction_Layer;
using Business_Entities;
using Mapper;

namespace Business_Logic_Layer
{
    public class BLL_Material_Stock : IGestionable<BE_Material_Stock>, IMovimentable<BE_Material_Stock,BE_Compra>
    {
        public bool AgregarStock(BE_Material_Stock material, BE_Compra compra)
        {
            return MPP_Material_Stock.DevolverInstancia().AgregarStock(material, compra);
        }
        public void RestarStock(BE_Material_Stock material)
        {
            material.Stock = material.Stock * -1;
        }
        public bool Baja(BE_Material_Stock material)
        {
            return MPP_Material_Stock.DevolverInstancia().Baja(material);
        }

        public DateTime DevolverFechaVencimiento(BE_Material_Stock material)
        {
            return MPP_Material_Stock.DevolverInstancia().DevolverFechaVencimiento(material);
        }

        public decimal DevolverStock(BE_Material_Stock material, bool estelote)
        {
            throw new NotImplementedException();
        }

        public bool Guardar(BE_Material_Stock material)
        {
            return MPP_Material_Stock.DevolverInstancia().Guardar(material);
        }

        public List<BE_Material_Stock> Listar()
        {
            List<BE_Material_Stock> listado = MPP_Material_Stock.DevolverInstancia().Listar();
            foreach (BE_Material_Stock item in listado)
            {
                item.FechaVencimiento = DevolverFechaVencimiento(item);
            }
            return listado;
        }

        public BE_Material_Stock ListarObjeto(BE_Material_Stock material, DataSet ds = null)
        {
            return MPP_Material_Stock.DevolverInstancia().ListarObjeto(material);
        }
        public BE_Material_Stock ListarXCompra(BE_Compra compra)
        {
            return MPP_Material_Stock.DevolverInstancia().ListarXCompra(compra);
        }
        public List<BE_Material_Stock> ListarConStock()
        {
            List<BE_Material_Stock> listado = MPP_Material_Stock.DevolverInstancia().ListarConStock();
            foreach (BE_Material_Stock item in listado)
            {
                item.FechaVencimiento = DevolverFechaVencimiento(item);
            }
            return listado;
        }
        public BE_Material_Stock BuscarXLote(BE_Compra compra, string lote)
        {
            return MPP_Material_Stock.DevolverInstancia().BuscarXLote(compra, lote);
        }
        public bool Modificar(BE_Material_Stock material)
        { 
            return MPP_Material_Stock.DevolverInstancia().Modificar(material);
        }
    }
}
