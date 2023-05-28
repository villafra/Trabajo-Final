using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_Entities;
using Abstraction_Layer;
using Data_Access_Layer;
using System.Xml.Linq;
using System.Data;

namespace Mapper
{
    public class MPP_Pedido:IGestionable<BE_Pedido>
    {
        Xml_Database Acceso;

        public bool Baja(BE_Pedido pedido)
        {
            Acceso = new Xml_Database();
            return Acceso.Borrar("Pedidos", "Pedido", CrearPedidoXML(pedido));
        }

        public bool Guardar(BE_Pedido pedido)
        {
            Acceso = new Xml_Database();
            return Acceso.Escribir("Pedidos", CrearPedidoXML(pedido)) &
                Acceso.Escribir("Platos-Pedidos", listaNodos: CrearPlatoPedido(pedido)) &
                Acceso.Escribir("Bebidas-Pedidos", listaNodos: CrearBebidaPedido(pedido));
        }

        public List<BE_Pedido> Listar()
        {
            Acceso = new Xml_Database();
            DataSet ds = new DataSet();
            ds = Acceso.Listar();

            List<BE_Pedido> ListadePedidos = (from ped in ds.Tables["Pedido"].AsEnumerable()
                                              select new BE_Pedido
                                              {
                                                  Codigo = Convert.ToInt32(ped[0]),
                                                  FechaInicio = Convert.ToDateTime(ped[1]),
                                                  Customizado = Convert.ToBoolean(ped[2]),
                                                  Aclaraciones = Convert.ToString(ped[3]),
                                                  Status = Convert.ToString(ped[4]),
                                                  Monto_Total = Convert.ToDecimal(ped[5]),
                                                  ID_Pago = (from pago in ds.Tables["Pago"].AsEnumerable()
                                                             where Convert.ToInt32(ped[6]) == Convert.ToInt32(pago[0])
                                                             select new BE_Pago
                                                             {
                                                                 Codigo = Convert.ToInt32(pago[0]),
                                                                 Tipo = Convert.ToString(pago[1])
                                                             }).FirstOrDefault(),
                                                  ListadeBebida = (from obj in ds.Tables["Bebida-Pedido"].AsEnumerable()
                                                                   join beb in ds.Tables["Bebida"].AsEnumerable()
                                                                   on Convert.ToInt32(obj[1]) equals Convert.ToInt32(ped[0])
                                                                   select new BE_Bebida
                                                                   {

                                                                   }).ToList(),
                                                  ListadePlatos = (from obj in ds.Tables["Plato-Pedido"].AsEnumerable()
                                                                   join platos in ds.Tables["Plato"].AsEnumerable()
                                                                   on Convert.ToInt32(obj[1]) equals Convert.ToInt32(ped[0])
                                                                   select new BE_Plato
                                                                   {
                                                                       Codigo = Convert.ToInt32(platos[0]),
                                                                       Nombre = Convert.ToString(platos[1]),
                                                                       Tipo = Convert.ToString(platos[2]),
                                                                       Clase = Convert.ToString(platos[3]),
                                                                       Status = Convert.ToString(platos[4]),
                                                                       CostoUnitario = Convert.ToDecimal(platos[5]),
                                                                       Activo = Convert.ToBoolean(platos[6]),
                                                                       ListaIngredientes = (from obje in ds.Tables["Ingrediente-Plato"].AsEnumerable()
                                                                                            join ing in ds.Tables["Ingrediente"].AsEnumerable()
                                                                                            on Convert.ToInt32(obje[1]) equals Convert.ToInt32(platos[0])
                                                                                            select new BE_Ingrediente
                                                                                            {
                                                                                                Codigo = Convert.ToInt32(ing[0]),
                                                                                                Nombre = Convert.ToString(ing[1]),
                                                                                                Tipo = Convert.ToString(ing[2]),
                                                                                                Refrigeracion = Convert.ToBoolean(ing[3]),
                                                                                                Stock = Convert.ToDecimal(ing[4]),
                                                                                                UnidadMedida = Convert.ToString(ing[5]),
                                                                                                Lote = Convert.ToString(ing[6]),
                                                                                                Activo = Convert.ToBoolean(ing[7]),
                                                                                                VidaUtil = Convert.ToInt32(ing[8]),
                                                                                                Status = Convert.ToString(ing[9]),
                                                                                                CostoUnitario = Convert.ToDecimal(ing[10])

                                                                                            }).ToList()

                                                                   }).ToList(),
                                              }).ToList();

            return ListadePedidos;

        }

        public BE_Pedido ListarObjeto(BE_Pedido pedido)
        {
            throw new NotImplementedException();
        }

        private XElement CrearPedidoXML(BE_Pedido pedido)
        {
            XElement nuevoPedido = new XElement("Pedido",
                new XElement("ID", pedido.Codigo.ToString()),
                new XElement("Fecha de Inicio", pedido.FechaInicio.ToString()),
                new XElement("Customizado", pedido.Customizado.ToString()),
                new XElement("Aclaraciones", pedido.Aclaraciones),
                new XElement("Status", pedido.Status),
                new XElement("Monto Total", pedido.Monto_Total.ToString()),
                new XElement("ID_Pago", pedido.ID_Pago.Codigo.ToString())
                );
            return nuevoPedido;
        }

        private List<XElement> CrearPlatoPedido(BE_Pedido pedido)
        {
            List<XElement> listadePlatos = new List<XElement>();
            foreach(BE_Plato plato in pedido.ListadePlatos)
            {
                XElement nuevoPlatoPedido = new XElement("Plato-Pedido",
                    new XElement("ID Pedido", pedido.Codigo.ToString()),
                    new XElement("ID Plato", plato.Codigo.ToString())
                    );
                listadePlatos.Add(nuevoPlatoPedido);
            }
            return listadePlatos;
        }

        private List<XElement> CrearBebidaPedido(BE_Pedido pedido)
        {
            List<XElement> listadeBebidas = new List<XElement>();
            foreach (BE_Bebida bebida in pedido.ListadeBebida)
            {
                XElement nuevaBebidaPedido = new XElement("Bebida-Pedido",
                   new XElement("ID Pedido", bebida.Codigo.ToString()),
                   new XElement("ID Bebida", bebida.Codigo.ToString())
                    );
                listadeBebidas.Add(nuevaBebidaPedido);
            }
            return listadeBebidas;
        }

        public bool Modificar(BE_Pedido pedido)
        {
            Acceso = new Xml_Database();
            return Acceso.Modificar("Pedidos", "Pedido", CrearPedidoXML(pedido));
        }
    }
}
