using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_Entities;
using Mapper;

namespace Business_Logic_Layer
{
    public class BLL_Dash_Compras
    {
        public List<BE_Compra> RecolectarCompras()
        {
            List<BE_Compra> listado = MPP_Compra.DevolverInstancia().Listar();
            return listado;
        }
        public List<BE_Ingrediente> RecolectarIngredientes()
        {
            List<BE_Ingrediente> listado = MPP_Ingrediente.DevolverInstancia().Listar();
            return listado;
        }
        public List<BE_Bebida> RecolectarBebidas()
        {
            List<BE_Bebida> listado = MPP_Bebida.DevolverInstancia().Listar();
            return listado.Where(x=> !(x is BE_Bebida_Preparada)).ToList();
        }
        public List<Dash_Compras> ListarIngrediente(List<BE_Compra> compras, List<BE_Ingrediente> ingredientes, DateTime inicio, DateTime fin)
        {
            List<Dash_Compras> listado = new List<Dash_Compras>();
            foreach(BE_Ingrediente ingrediente in ingredientes)
            {
                Dash_Compras dash = new Dash_Compras();
                dash.Material = ingrediente.ToString();
                var comprasIngrediente = compras.Where(compra => compra is BE_CompraIngrediente && ((BE_CompraIngrediente)compra).ID_Material.Codigo == ingrediente.Codigo && compra.FechaCompra >= inicio && compra.FechaCompra <= fin);
                dash.Cantidad = (int)Math.Round(comprasIngrediente.Sum(compra => compra.Cantidad), 0);
                dash.Costo = comprasIngrediente.Sum(compra => ((BE_CompraIngrediente)compra).Costo);
                listado.Add(dash);
            }
            return listado;
        }
        public List<Dash_Compras> ListarBebida(List<BE_Compra> compras, List<BE_Bebida> bebidas, DateTime inicio, DateTime fin)
        {
            List<Dash_Compras> listado = new List<Dash_Compras>();
            foreach (BE_Bebida bebida in bebidas)
            {
                Dash_Compras dash = new Dash_Compras();
                dash.Material = bebida.ToString();
                var comprasBebida = compras.Where(compra => compra is BE_CompraBebida && ((BE_CompraBebida)compra).ID_Material.Codigo == bebida.Codigo && compra.FechaCompra >= inicio && compra.FechaCompra <= fin);
                dash.Cantidad = (int)Math.Round(comprasBebida.Sum(compra => ((BE_CompraBebida)compra).Cantidad), 0);
                dash.Costo = comprasBebida.Sum(compra => ((BE_CompraBebida)compra).Costo);
                listado.Add(dash);
            }
            return listado;
        }
        public Dash_Compras MayorIngrediente(List<Dash_Compras> lista)
        {
            Dash_Compras MasIng = lista.OrderByDescending(x => x.Cantidad).FirstOrDefault();
            return MasIng;
        }
        public Dash_Compras MayorBebida(List<Dash_Compras> lista)
        {
            Dash_Compras MasBebida = lista.OrderByDescending(x => x.Cantidad).FirstOrDefault();
            return MasBebida;
        }
        public Dash_PedidoPromedio PromedioCompra(List<BE_Compra> lista)
        {
            Dash_PedidoPromedio promedio = new Dash_PedidoPromedio();
            promedio.Cantidad = lista.Count();
            promedio.Promedio = lista.Average(x => x.Costo);
            return promedio;
        }
    }
}
