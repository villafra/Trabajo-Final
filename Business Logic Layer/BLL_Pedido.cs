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
    public class BLL_Pedido : IGestionable<BE_Pedido>
    {
        public bool Baja(BE_Pedido pedido)
        {
            return MPP_Pedido.DevolverInstancia().Baja(pedido);
        }

        public bool Guardar(BE_Pedido pedido)
        {
            return MPP_Pedido.DevolverInstancia().Guardar(pedido);
        }

        public List<BE_Pedido> Listar()
        {
            return MPP_Pedido.DevolverInstancia().Listar();
        }

        public BE_Pedido ListarObjeto(BE_Pedido pedido, DataSet ds = null)
        {
            return MPP_Pedido.DevolverInstancia().ListarObjeto(pedido);
        }

        public List<BE_Plato> AgregarPlatos(List<BE_Plato_Stock> platos)
        {
            List<BE_Plato> lista = new List<BE_Plato>();
            foreach(BE_Plato_Stock plato in platos)
            {
                lista.Add(plato.Material);
            }
            return lista;
        }

        public List<BE_Bebida> AgregarBebidas(List<BE_Bebida_Stock> bebidas)
        {
            List<BE_Bebida> lista = new List<BE_Bebida>();
            foreach (BE_Bebida_Stock bebida in bebidas)
            {
                lista.Add(bebida.Material);
            }
            return lista;
        }
        public bool AgregarBebida(BE_Pedido pedido, BE_Bebida_Stock bebida)
        {
            return MPP_Pedido.DevolverInstancia().AgregarBebida(pedido, bebida);
        }
        public bool AgregarPlato(BE_Pedido pedido, BE_Plato_Stock plato)
        {
            return MPP_Pedido.DevolverInstancia().AgregarPlato(pedido, plato);
        }
        public bool EliminarPlato(BE_Pedido pedido, BE_Plato_Stock plato)
        {
            return MPP_Pedido.DevolverInstancia().EliminarPlato(pedido, plato);
        }

        public bool EliminarBebida(BE_Pedido pedido, BE_Bebida_Stock bebida)
        {
            return MPP_Pedido.DevolverInstancia().EliminarBebida(pedido, bebida);
        }

        public decimal CalcularTotal(BE_Pedido pedido)
        {
            decimal SubTotal = pedido.ListadeBebida.Sum(x => x.CostoUnitario);
            SubTotal += pedido.ListadePlatos.Sum(x => x.CostoUnitario);
            return SubTotal;

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
            return MPP_Pedido.DevolverInstancia().Modificar(pedido);
        }
    }
}
