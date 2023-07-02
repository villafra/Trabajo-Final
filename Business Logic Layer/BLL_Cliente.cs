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
    public class BLL_Cliente : IGestionable<BE_Cliente>
    {
        
        public bool Baja(BE_Cliente cliente)
        {
            return MPP_Cliente.DevolverInstancia().Baja(cliente);
        }

        public bool Guardar(BE_Cliente cliente)
        {
            return MPP_Cliente.DevolverInstancia().Guardar(cliente);
        }

        public List<BE_Cliente> Listar()
        {
            return MPP_Cliente.DevolverInstancia().Listar();
        }

        public BE_Cliente ListarObjeto(BE_Cliente cliente, DataSet ds = null)
        {
            return MPP_Cliente.DevolverInstancia().ListarObjeto(cliente);
        }

        public bool modificarCliente(BE_Cliente cliente)
        {
            return MPP_Cliente.DevolverInstancia().Modificar(cliente);
        }

        public bool borrarCliente(BE_Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public List<BE_Reserva> listarReservas(BE_Cliente cliente)
        {
            return cliente.ListaReservas;
        }

        public List<BE_Plato> listarPlatos(BE_Cliente cliente)
        {
            return cliente.ListadePlatos;
        }

        public List<BE_Bebida> listarBebidas(BE_Cliente cliente)
        {
            return cliente.ListadeBebidas;
        }

        public bool Modificar(BE_Cliente cliente)
        {
            return MPP_Cliente.DevolverInstancia().Modificar(cliente);
        }
    }
}
