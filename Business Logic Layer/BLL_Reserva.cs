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
    public class BLL_Reserva : IGestionable<BE_Reserva>
    {
        public bool Baja(BE_Reserva reserva)
        {
            return MPP_Reserva.DevolverInstancia().Baja(reserva);
        }

        public bool Guardar(BE_Reserva reserva)
        {
            return MPP_Reserva.DevolverInstancia().Guardar(reserva);
        }

        public List<BE_Reserva> Listar()
        {
            return MPP_Reserva.DevolverInstancia().Listar();
        }

        public BE_Reserva ListarObjeto(BE_Reserva reserva, DataSet ds = null)
        {
            return MPP_Reserva.DevolverInstancia().ListarObjeto(reserva);
        }

        public bool modificarReserva()
        {
            throw new NotImplementedException();
        }

        public bool cancelarReserva()
        {
            throw new NotImplementedException();
        }

        public void verificarDisponibilidad()
        {
            throw new NotImplementedException();
        }

        public void notificarReserva()
        {
            throw new NotImplementedException();
        }

        public void autogenerarPedido(BE_Pedido pedido)
        {
            throw new NotImplementedException();
        }

        public bool Modificar(BE_Reserva reserva)
        {
            return MPP_Reserva.DevolverInstancia().Modificar(reserva);
        }
    }
}
