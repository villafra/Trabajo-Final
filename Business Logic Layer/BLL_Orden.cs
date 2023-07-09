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

        public object ListarEnEspera()
        {
            return MPP_Orden.DevolverInstancia().ListarEnEspera();
        }

        public bool ActualizarStatus(BE_Orden orden)
        {
            if (orden.Status == StatusOrden.En_Espera)
            {
                orden.Status = (StatusOrden)((int)orden.Status + orden.Pasos_Orden);
            }
            if (Enum.IsDefined(typeof(StatusOrden), (StatusOrden)((int)orden.Status + 1)))
            {
                orden.Status = (StatusOrden)((int)orden.Status + 1);
            }
            else return false;
            return Modificar(orden);
        }
        public int CantidadPasos(BE_Orden orden)
        {
            int pasos = 0;
            if (orden.ID_Pedido.ListadeBebida.Count == 0) pasos += 3;
            if (orden.ID_Pedido.ListadePlatos.Count == 0) pasos += 3;
            return pasos;      
        }
    }
}
