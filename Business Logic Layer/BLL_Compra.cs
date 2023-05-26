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

        public bool recepcionarCompra()
        {
            throw new NotImplementedException();
        }

        public BE_Compra devolverCompra(long nroCompra)
        {
            throw new NotImplementedException();
        }
    }
}
