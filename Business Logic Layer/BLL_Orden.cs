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
    public class BLL_Orden : IGestionable<BE_Orden>
    {
        MPP_Orden oMPP_Orden;

        public BLL_Orden()
        {
            oMPP_Orden = new MPP_Orden();
        }

        public bool Baja(BE_Orden orden)
        {
            return oMPP_Orden.Baja(orden);
        }

        public bool Guardar(BE_Orden orden)
        {
            return oMPP_Orden.Guardar(orden);
        }

        public List<BE_Orden> Listar()
        {
            return oMPP_Orden.Listar();
        }

        public BE_Orden ListarObjeto(BE_Orden orden)
        {
            return oMPP_Orden.ListarObjeto(orden);
        }

        public void dividirPasos()
        {
            throw new NotImplementedException();
        }

        public bool actualizarStatus()
        {
            throw new NotImplementedException();
        }

        public bool entregarOrden()
        {
            throw new NotImplementedException();
        }

        public DateTime obtenerTiempoPedido()
        {
            throw new NotImplementedException();
        }

        public void obtenerItemsPedido()
        {
            throw new NotImplementedException();
        }
    }
}
