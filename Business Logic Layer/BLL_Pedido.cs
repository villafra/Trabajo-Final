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
    public class BLL_Pedido : IGestionable<BE_Pedido>
    {
        MPP_Pedido oMPP_Pedido;

        public BLL_Pedido()
        {
            oMPP_Pedido = new MPP_Pedido();
        }

        public bool Baja(BE_Pedido pedido)
        {
            return oMPP_Pedido.Baja(pedido);
        }

        public bool Guardar(BE_Pedido pedido)
        {
            return oMPP_Pedido.Guardar(pedido);
        }

        public List<BE_Pedido> Listar()
        {
            return oMPP_Pedido.Listar();
        }

        public BE_Pedido ListarObjeto(BE_Pedido pedido)
        {
            return oMPP_Pedido.ListarObjeto(pedido);
        }

        public bool agregarPlato()
        {
            throw new NotImplementedException();
        }

        public bool agregarBebida()
        {
            throw new NotImplementedException();
        }

        public bool eliminarPlato()
        {
            throw new NotImplementedException();
        }

        public bool eliminarBebida()
        {
            throw new NotImplementedException();
        }

        public decimal calcularTotal()
        {
            throw new NotImplementedException();
        }

        public bool modificarPedido()
        {
            throw new NotImplementedException();
        }

        public bool confirmarPedido()
        {
            throw new NotImplementedException();
        }

        public bool guardarPlato()
        {
            throw new NotImplementedException();
        }

        public bool agendarPlato()
        {
            throw new NotImplementedException();
        }

        public bool sugerirPlato()
        {
            throw new NotImplementedException();
        }

        public bool abonarPedido(decimal monto)
        {
            throw new NotImplementedException();
        }

        public bool Modificar(BE_Pedido pedido)
        {
            return oMPP_Pedido.Modificar(pedido);
        }
    }
}
