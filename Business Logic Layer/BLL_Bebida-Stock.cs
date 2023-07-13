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
    public class BLL_Bebida_Stock : IGestionable<BE_Bebida_Stock>, IMovimentable<BE_Bebida_Stock,BE_Compra>
    {
        public bool AgregarStock(BE_Bebida_Stock material, BE_Compra compra)
        {
            return MPP_Bebida_Stock.DevolverInstancia().AgregarStock(material, compra);
        }
        public void RestarStock(BE_Bebida_Stock material)
        {
            material.Stock = material.Stock * -1;
        }
        public bool Baja(BE_Bebida_Stock material)
        {
            return MPP_Bebida_Stock.DevolverInstancia().Baja(material);
        }

        public DateTime DevolverFechaVencimiento(BE_Bebida_Stock material)
        {
            throw new NotImplementedException();
        }

        public decimal DevolverStock(BE_Bebida_Stock material, bool estelote)
        {
            throw new NotImplementedException();
        }

        public bool Guardar(BE_Bebida_Stock material)
        {
            return MPP_Bebida_Stock.DevolverInstancia().Guardar(material);
        }

        public List<BE_Bebida_Stock> Listar()
        {
            return MPP_Bebida_Stock.DevolverInstancia().Listar();
        }

        public BE_Bebida_Stock ListarObjeto(BE_Bebida_Stock material, DataSet ds = null)
        {
            return MPP_Bebida_Stock.DevolverInstancia().ListarObjeto(material);
        }
        public BE_Bebida_Stock ListarXCompra(BE_Compra compra)
        {
            return MPP_Bebida_Stock.DevolverInstancia().ListarXCompra(compra);
        }
        public List<BE_Bebida_Stock> ListarConStock()
        {
            return MPP_Bebida_Stock.DevolverInstancia().ListarConStock();
        }
        public BE_Bebida_Stock BuscarXLote(BE_Compra compra, string lote)
        {
            return MPP_Bebida_Stock.DevolverInstancia().BuscarXLote(compra, lote);
        }
        public List<BE_Bebida_Stock> BuscarStock(BE_Bebida bebida)
        {
            return MPP_Bebida_Stock.DevolverInstancia().BuscarStock(bebida);
        }
        public bool Modificar(BE_Bebida_Stock material)
        { 
            return MPP_Bebida_Stock.DevolverInstancia().Modificar(material);
        }
        public bool Modificar(List<BE_Bebida_Stock> material)
        {
            return MPP_Bebida_Stock.DevolverInstancia().Modificar(material);
        }
        public bool Existe(BE_Bebida_Stock bebida)
        {
            return MPP_Bebida_Stock.DevolverInstancia().Existe(bebida);
        }
        public bool Consumir(List<BE_Bebida_Stock> bebidas, decimal cantidad)
        {
            foreach (BE_Bebida_Stock bebida in bebidas)
            {
                if (cantidad <= 0) break;
                if (bebida.Stock >= cantidad)
                {
                    bebida.Stock -= cantidad;
                    cantidad = 0;
                }
                else
                {
                    cantidad -= bebida.Stock;
                    bebida.Stock = 0;
                }
            }
            return Modificar(bebidas);
        }
    }
}
