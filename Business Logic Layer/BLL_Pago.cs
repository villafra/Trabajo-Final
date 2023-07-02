using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_Entities;
using Abstraction_Layer;
using Mapper;
using System.Data;

namespace Business_Logic_Layer
{
    public class BLL_Pago : IGestionable<BE_Pago>
    {
 
        public bool Baja(BE_Pago pago)
        {
            return MPP_Pago.DevolverInstancia().Baja(pago);
        }

        public bool Guardar(BE_Pago pago)
        {
            return MPP_Pago.DevolverInstancia().Guardar(pago);
        }

        public List<BE_Pago> Listar()
        {
            return MPP_Pago.DevolverInstancia().Listar();
        }

        public BE_Pago ListarObjeto(BE_Pago pago, DataSet ds = null)
        {
            return MPP_Pago.DevolverInstancia().ListarObjeto(pago);
        }

        public bool Modificar(BE_Pago pago)
        {
            return MPP_Pago.DevolverInstancia().Modificar(pago);
        }
    }
}
