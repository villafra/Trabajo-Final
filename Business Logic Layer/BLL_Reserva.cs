using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraction_Layer;
using Business_Entities;

namespace Business_Logic_Layer
{
    public class BLL_Reserva : IGestionable<BE_Reserva>
    {
        public bool Baja(BE_Reserva Objeto)
        {
            throw new NotImplementedException();
        }

        public bool Guardar(BE_Reserva Objeto)
        {
            throw new NotImplementedException();
        }

        public List<BE_Reserva> Listar()
        {
            throw new NotImplementedException();
        }

        public BE_Reserva ListarObjeto(BE_Reserva Objeto)
        {
            throw new NotImplementedException();
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
    }
}
