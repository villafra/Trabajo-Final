using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_Entities;
using Mapper;

namespace Business_Logic_Layer
{
    public class BLL_Dash_Ventas
    {
        public List<BE_Pedido> RecolectarPedidos()
        {
            List<BE_Pedido> listado = MPP_Pedido.DevolverInstancia().Listar();
            return listado;
        }
        public List<BE_Plato> RecolectarPlatos()
        {
            List<BE_Plato> listado = MPP_Plato.DevolverInstancia().Listar();
            return listado;
        }
        public List<BE_Bebida> RecolectarBebidas()
        {
            List<BE_Bebida> listado = MPP_Bebida.DevolverInstancia().Listar();
            return listado;
        }
        public List<Dash_PlatosVentas> ListarPlatos(List<BE_Pedido> pedidos, List<BE_Plato> platos, DateTime inicio, DateTime fin)
        {
            List<Dash_PlatosVentas> listado = new List<Dash_PlatosVentas>();
            foreach(BE_Plato plato in platos)
            {
                Dash_PlatosVentas dash = new Dash_PlatosVentas();
                dash.Plato = plato.ToString();
                dash.Cantidad = pedidos.Sum(pedido => pedido.ListadePlatos.Count(p => p.Nombre == dash.Plato && pedido.FechaInicio >= inicio && pedido.FechaInicio <= fin));
                listado.Add(dash);
            }
            return listado;
        }
        public List<Dash_BebidasVentas> ListarBebidas(List<BE_Pedido> pedidos, List<BE_Bebida> bebidas, DateTime inicio, DateTime fin)
        {
            List<Dash_BebidasVentas> listado = new List<Dash_BebidasVentas>();
            foreach (BE_Bebida bebida in bebidas)
            {
                Dash_BebidasVentas dash = new Dash_BebidasVentas();
                dash.Bebida = bebida.ToString();
                dash.Cantidad = pedidos.Sum(pedido => pedido.ListadeBebida.Count(p => p.Nombre == dash.Bebida && pedido.FechaInicio >= inicio && pedido.FechaInicio <= fin));
                listado.Add(dash);
            }
            return listado;
        }
        public Dash_PlatosVentas MayorPlato(List<Dash_PlatosVentas> lista)
        {
            Dash_PlatosVentas MasPlato = lista.OrderByDescending(x => x.Cantidad).FirstOrDefault();
            return MasPlato;
        }
        public Dash_BebidasVentas MayorBebida(List<Dash_BebidasVentas> lista)
        {
            Dash_BebidasVentas MasBebida = lista.OrderByDescending(x => x.Cantidad).FirstOrDefault();
            return MasBebida;
        }
        public Dash_PedidoPromedio Promedio(List<BE_Pedido> lista)
        {
            Dash_PedidoPromedio promedio = new Dash_PedidoPromedio();
            promedio.Cantidad = lista.Count();
            promedio.Promedio = lista.Average(x => x.Monto_Total);
            return promedio;
        }
    }
}
