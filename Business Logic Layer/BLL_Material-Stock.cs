using System;
using System.Collections.Generic;
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
        MPP_Material_Stock oMPP_Material_Stock;

        public BLL_Material_Stock()
        {
            oMPP_Material_Stock = new MPP_Material_Stock();
        }

        public bool AgregarStock(BE_Material_Stock material, BE_Compra compra)
        {
            return oMPP_Material_Stock.AgregarStock(material, compra);
        }
        public void RestarStock(BE_Material_Stock material)
        {
            material.Stock = material.Stock * -1;
        }
        public bool Baja(BE_Material_Stock material)
        {
            return oMPP_Material_Stock.Baja(material);
        }

        public DateTime DevolverFechaVencimiento(BE_Material_Stock material)
        {
            throw new NotImplementedException();
        }

        public decimal DevolverStock(BE_Material_Stock material, bool estelote)
        {
            throw new NotImplementedException();
        }

        public bool Guardar(BE_Material_Stock material)
        {
            return oMPP_Material_Stock.Guardar(material);
        }

        public List<BE_Material_Stock> Listar()
        {
            return oMPP_Material_Stock.Listar();
        }

        public BE_Material_Stock ListarObjeto(BE_Material_Stock material)
        {
            return oMPP_Material_Stock.ListarObjeto(material);
        }
        public BE_Material_Stock ListarXCompra(BE_Compra compra)
        {
            return oMPP_Material_Stock.ListarXCompra(compra);
        }
        public List<BE_Material_Stock> ListarConStock()
        {
            return oMPP_Material_Stock.ListarConStock();
        }
        public BE_Material_Stock BuscarXLote(BE_Compra compra, string lote)
        {
            return oMPP_Material_Stock.BuscarXLote(compra, lote);
        }
        public bool Modificar(BE_Material_Stock material)
        { 
            return oMPP_Material_Stock.Modificar(material);
        }
    }
}
