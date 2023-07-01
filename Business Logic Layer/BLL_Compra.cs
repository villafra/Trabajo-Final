using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_Entities;
using Abstraction_Layer;
using Mapper;

namespace Business_Logic_Layer
{
    public class BLL_Compra : IGestionable<BE_Compra>
    {
        MPP_Compra oMPP_Compra;

        public BLL_Compra()
        {
            oMPP_Compra = new MPP_Compra();
        }

        public bool Baja(BE_Compra compra)
        {
            return oMPP_Compra.Baja(compra);
        }

        public bool Guardar(BE_Compra compra)
        {
            return oMPP_Compra.Guardar(compra);
        }

        public List<BE_Compra> Listar()
        {
            return oMPP_Compra.Listar();
        }

        public BE_Compra ListarObjeto(BE_Compra compra)
        {
            return oMPP_Compra.ListarObjeto(compra);
        }

        public bool recepcionarCompra(long nroCompra)
        {
            throw new NotImplementedException();
        }

        public BE_Compra devolverCompra(long nroCompra)
        {
            throw new NotImplementedException();
        }

        public bool Modificar(BE_Compra compra)
        {
            return oMPP_Compra.Modificar(compra);
        }
        public decimal CalcularCostoNeto(BE_Compra compra)
        {
            decimal costo = new MPP_Costo().DevolverCosto(compra.ID_Ingrediente, compra.CantidadRecibida);
            return costo;
        }
        public decimal CalcularCostoTeorico(BE_Compra compra)
        {
            decimal costo = new MPP_Costo().DevolverCosto(compra.ID_Ingrediente, compra.Cantidad);
            return costo;
        }
    }
}
