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
    public class BLL_Cliente : IGestionable<BE_Cliente>
    {
        MPP_Cliente oMPP_Cliente;

        public BLL_Cliente()
        {
            oMPP_Cliente = new MPP_Cliente();
        }

        public bool Baja(BE_Cliente cliente)
        {
            return oMPP_Cliente.Baja(cliente);
        }

        public bool Guardar(BE_Cliente cliente)
        {
            return oMPP_Cliente.Guardar(cliente);
        }

        public List<BE_Cliente> Listar()
        {
            return oMPP_Cliente.Listar();
        }

        public BE_Cliente ListarObjeto(BE_Cliente cliente)
        {
            return oMPP_Cliente.ListarObjeto(cliente);
        }

        public void modificarCliente()
        {
            throw new NotImplementedException();
        }

        public void borrarCliente()
        {
            throw new NotImplementedException();
        }

        public List<BE_Reserva> listarReservas()
        {
            throw new NotImplementedException();
        }

        public List<BE_Plato> listarPlatos()
        {
            throw new NotImplementedException();
        }

        public List<BE_Bebida> listarBebidas()
        {
            throw new NotImplementedException();
        }

        public bool Modificar(BE_Cliente cliente)
        {
            return oMPP_Cliente.Modificar(cliente);
        }
    }
}
