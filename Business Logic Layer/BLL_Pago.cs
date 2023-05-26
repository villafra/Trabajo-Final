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
    public class BLL_Pago : IGestionable<BE_Pago>
    {
        MPP_Pago oMPP_Pago;

        public BLL_Pago()
        {
            oMPP_Pago = new MPP_Pago();
        }

        public bool Baja(BE_Pago pago)
        {
            return oMPP_Pago.Baja(pago);
        }

        public bool Guardar(BE_Pago pago)
        {
            return oMPP_Pago.Guardar(pago);
        }

        public List<BE_Pago> Listar()
        {
            return oMPP_Pago.Listar();
        }

        public BE_Pago ListarObjeto(BE_Pago pago)
        {
            return oMPP_Pago.ListarObjeto(pago);
        }
    }
}
