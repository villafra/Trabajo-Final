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
    public class BLL_Reserva : IGestionable<BE_Reserva>
    {
        MPP_Reserva oMPP_Reserva;

        public BLL_Reserva()
        {
            oMPP_Reserva = new MPP_Reserva();
        }

        public bool Baja(BE_Reserva reserva)
        {
            return oMPP_Reserva.Baja(reserva);
        }

        public bool Guardar(BE_Reserva reserva)
        {
            return oMPP_Reserva.Guardar(reserva);
        }

        public List<BE_Reserva> Listar()
        {
            return oMPP_Reserva.Listar();
        }

        public BE_Reserva ListarObjeto(BE_Reserva reserva)
        {
            return oMPP_Reserva.ListarObjeto(reserva);
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
            return oMPP_Reserva.Modificar(reserva);
        }
    }
}
