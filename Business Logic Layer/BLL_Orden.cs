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

        public bool Modificar(BE_Orden orden)
        {
            return MPP_Orden.DevolverInstancia().Modificar(orden);
        }

        public object ListarEnEntrega()
        {
            return MPP_Orden.DevolverInstancia().ListarEnEntrega();
        }

        public object ListarEnEsperaPlatos()
        {
            return MPP_Orden.DevolverInstancia().ListarEnEsperaPlatos();
        }

        public object ListarEnEsperaBebidas()
        {
            return MPP_Orden.DevolverInstancia().ListarEnEsperaBebidas();
        }
        public void VerEnEspera (BE_Orden orden)
        {
            if (orden.ID_Pedido.ListadeBebida.Count == 0)
                orden.Status = StatusOrden.En_Espera_Platos;
        }

    }
}
