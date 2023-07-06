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
using Automate_Layer;

namespace Mapper
{
    public class MPP_Pedido : IGestionable<BE_Pedido>
    {
        private static List<BE_TuplaXML> ListadoXML;
        private static MPP_Pedido mapper = null;
        public static MPP_Pedido DevolverInstancia()
        {
            if (mapper == null) mapper = new MPP_Pedido();
            else
                ListadoXML = null;
            return mapper;
        }
        ~MPP_Pedido()
        {
            mapper = null;
            ListadoXML = null;
        }
        public bool Baja(BE_Pedido pedido)
        {
            ListadoXML = new List<BE_TuplaXML>();
            ListadoXML.Add(CrearPedidoXML(pedido));
            return Xml_Database.DevolverInstancia().Borrar(ListadoXML);
        }

        public bool Guardar(BE_Pedido pedido)
        {
            ListadoXML = new List<BE_TuplaXML>();
            ListadoXML.Add(CrearPedidoXML(pedido));
            return Xml_Database.DevolverInstancia().Escribir(ListadoXML);
        }

        public List<BE_Pedido> Listar()
        {
            DataSet ds = new DataSet();
            ds = Xml_Database.DevolverInstancia().Listar();

            List<BE_Pedido> ListadePedidos = ds.Tables.Contains("Pedido") != false ?
                (from ped in ds.Tables["Pedido"].AsEnumerable()
                 select new BE_Pedido
                 {
                     Codigo = Convert.ToInt32(ped[0]),
                     FechaInicio = Convert.ToDateTime(ped[1]),
                     Customizado = Convert.ToBoolean(ped[2]),
                     Aclaraciones = Convert.ToString(ped[3]),
                     Status = Convert.ToString(ped[4]),
                     Monto_Total = Convert.ToDecimal(ped[5]),
                     ID_Pago = MPP_Pago.DevolverInstancia().ListarObjeto(new BE_Pago { Codigo = Convert.ToInt32(ped[6]) }, ds),
                     ListadeBebida = MPP_Bebida.DevolverInstancia().Bebidas_Pedidos(new BE_Pedido { Codigo = Convert.ToInt32(ped[0]) }, ds),
                     ListadePlatos = MPP_Plato.DevolverInstancia().Platos_Pedidos(new BE_Pedido { Codigo = Convert.ToInt32(ped[0]) }, ds)
                 }).ToList() : null;

            return ListadePedidos;
        }

        public bool EliminarBebida(BE_Pedido pedido, BE_Bebida_Stock bebida)
        {
            throw new NotImplementedException();
        }

        public bool EliminarPlato(BE_Pedido pedido, BE_Plato_Stock plato)
        {
            throw new NotImplementedException();
        }

        public bool AgregarPlato(BE_Pedido pedido, BE_Plato_Stock plato)
        {
            throw new NotImplementedException();
        }

        public bool AgregarBebida(BE_Pedido pedido, BE_Bebida_Stock bebida)
        {
            throw new NotImplementedException();
        }

        public BE_Pedido ListarObjeto(BE_Pedido pedido, DataSet ds=null)
        {
            throw new NotImplementedException();
        }

        private BE_TuplaXML CrearPedidoXML(BE_Pedido pedido)
        {
            BE_TuplaXML nuevaTupla = new BE_TuplaXML();
            nuevaTupla.NodoRoot = "Pedidos";
            nuevaTupla.NodoLeaf = "Pedido";
            XElement nuevoPedido = new XElement("Pedido",
                new XElement("ID", Cálculos.IDPadleft(pedido.Codigo)),
                new XElement("Fecha de Inicio", pedido.FechaInicio.ToString()),
                new XElement("Customizado", pedido.Customizado.ToString()),
                new XElement("Aclaraciones", pedido.Aclaraciones),
                new XElement("Status", pedido.Status),
                new XElement("Monto Total", pedido.Monto_Total.ToString()),
                new XElement("ID_Pago", pedido.ID_Pago.Codigo.ToString())
                );
            nuevaTupla.Xelement = nuevoPedido;
            return nuevaTupla;
        }

        private List<BE_TuplaXML> CrearPlatoPedido(BE_Pedido pedido)
        {
            List<BE_TuplaXML> listadePlatos = new List<BE_TuplaXML>();
            foreach(BE_Plato plato in pedido.ListadePlatos)
            {
                BE_TuplaXML nuevaTupla = new BE_TuplaXML();
                nuevaTupla.NodoRoot = "Platos-Pedidos";
                nuevaTupla.NodoLeaf = "Plato-Pedido";
                XElement nuevoPlatoPedido = new XElement("Plato-Pedido",
                    new XElement("ID Pedido", Cálculos.IDPadleft(pedido.Codigo)),
                    new XElement("ID Plato", Cálculos.IDPadleft(plato.Codigo))
                    );
                nuevaTupla.Xelement= nuevoPlatoPedido;
                listadePlatos.Add(nuevaTupla);
            }
            return listadePlatos;
        }

        private List<BE_TuplaXML> CrearBebidaPedido(BE_Pedido pedido)
        {
            List<BE_TuplaXML> listadeBebidas = new List<BE_TuplaXML>();
            foreach (BE_Bebida bebida in pedido.ListadeBebida)
            {
                BE_TuplaXML nuevaTupla = new BE_TuplaXML();
                nuevaTupla.NodoRoot = "Bebidas-Pedidos";
                nuevaTupla.NodoLeaf = "Bebida-Pedido";
                XElement nuevaBebidaPedido = new XElement("Bebida-Pedido",
                   new XElement("ID Pedido", Cálculos.IDPadleft(bebida.Codigo)),
                   new XElement("ID Bebida", Cálculos.IDPadleft(bebida.Codigo))
                    ); 
                nuevaTupla.Xelement = nuevaBebidaPedido;
                listadeBebidas.Add(nuevaTupla);
            }
            return listadeBebidas;
        }

        public bool Modificar(BE_Pedido pedido)
        {
            ListadoXML = new List<BE_TuplaXML>();
            ListadoXML.Add(CrearPedidoXML(pedido));
            return Xml_Database.DevolverInstancia().Modificar(ListadoXML);
        }
    }
}
