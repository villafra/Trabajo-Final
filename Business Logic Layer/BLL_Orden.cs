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
    public class BLL_Orden : IGestionable<BE_Orden>
    {
        public bool Baja(BE_Orden orden)
        {
            return MPP_Orden.DevolverInstancia().Baja(orden);
        }

        public bool Guardar(BE_Orden orden)
        {
            return MPP_Orden.DevolverInstancia().Guardar(orden);
        }

        public List<BE_Orden> Listar()
        {
            return MPP_Orden.DevolverInstancia().Listar();
        }

        public BE_Orden ListarObjeto(BE_Orden orden, DataSet ds = null)
        {
            return MPP_Orden.DevolverInstancia().ListarObjeto(orden);
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

        public bool Modificar(BE_Orden orden)
        {
            return MPP_Orden.DevolverInstancia().Modificar(orden);
        }
    }
}
