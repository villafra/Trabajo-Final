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
    public class BLL_Plato_Stock : IGestionable<BE_Plato_Stock>, IMovimentable<BE_Plato_Stock,BE_Compra>
    {
        public bool AgregarStock(BE_Plato_Stock material, BE_Compra compra)
        {
            return MPP_Plato_Stock.DevolverInstancia().AgregarStock(material, compra);
        }
        public void RestarStock(BE_Plato_Stock material)
        {
            material.Stock = material.Stock * -1;
        }
        public bool Baja(BE_Plato_Stock material)
        {
            return MPP_Plato_Stock.DevolverInstancia().Baja(material);
        }

        public DateTime DevolverFechaVencimiento(BE_Plato_Stock material)
        {
            return MPP_Plato_Stock.DevolverInstancia().DevolverFechaVencimiento(material);
        }

        public decimal DevolverStock(BE_Plato_Stock material, bool estelote)
        {
            throw new NotImplementedException();
        }

        public bool Guardar(BE_Plato_Stock material)
        {
            return MPP_Plato_Stock.DevolverInstancia().Guardar(material);
        }

        public List<BE_Plato_Stock> Listar()
        {
            List<BE_Plato_Stock> listado =  MPP_Plato_Stock.DevolverInstancia().Listar();
            foreach(BE_Plato_Stock item in listado)
            {
                item.FechaVencimiento = DevolverFechaVencimiento(item);
            }
            return listado;
        }

        public BE_Plato_Stock ListarObjeto(BE_Plato_Stock material, DataSet ds = null)
        {
            return MPP_Plato_Stock.DevolverInstancia().ListarObjeto(material);
        }
        public BE_Plato_Stock ListarXCompra(BE_Compra compra)
        {
            return MPP_Plato_Stock.DevolverInstancia().ListarXCompra(compra);
        }
        public List<BE_Plato_Stock> ListarConStock()
        {
            List<BE_Plato_Stock> listado = MPP_Plato_Stock.DevolverInstancia().ListarConStock();
            foreach (BE_Plato_Stock item in listado)
            {
                item.FechaVencimiento = DevolverFechaVencimiento(item);
            }
            return listado;
        }
        public BE_Plato_Stock BuscarXLote(BE_Compra compra, string lote)
        {
            return MPP_Plato_Stock.DevolverInstancia().BuscarXLote(compra, lote);
        }
        public bool Modificar(BE_Plato_Stock material)
        { 
            return MPP_Plato_Stock.DevolverInstancia().Modificar(material);
        }

        public bool Existe(BE_Plato_Stock plato)
        {
            return MPP_Plato_Stock.DevolverInstancia().Existe(plato);
        }
    }
}
