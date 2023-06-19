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
    public class MPP_Pedido:IGestionable<BE_Pedido>
    {
        Xml_Database Acceso;
        List<BE_TuplaXML> ListadoXML;

        public MPP_Pedido()
        {
            ListadoXML = new List<BE_TuplaXML>();
        }

        public bool Baja(BE_Pedido pedido)
        {
            Acceso = new Xml_Database();
            ListadoXML.Add(CrearPedidoXML(pedido));
            return Acceso.Borrar(ListadoXML);
        }

        public bool Guardar(BE_Pedido pedido)
        {
            Acceso = new Xml_Database();
            ListadoXML.Add(CrearPedidoXML(pedido));
            return Acceso.Escribir(ListadoXML);
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
                                                  ID_Pago = ds.Tables.Contains("Pago") != false ? (from pago in ds.Tables["Pago"].AsEnumerable()
                                                                                                   where Convert.ToInt32(ped[6]) == Convert.ToInt32(pago[0])
                                                                                                   select new BE_Pago
                                                                                                   {
                                                                                                       Codigo = Convert.ToInt32(pago[0]),
                                                                                                       Tipo = Convert.ToString(pago[1])
                                                                                                   }).FirstOrDefault() : null,
                                                  ListadeBebida = ds.Tables.Contains("Bebida-Pedido") & ds.Tables.Contains("Bebida") != false ? (from obj in ds.Tables["Bebida-Pedido"].AsEnumerable()
                                                                                                                                                 join beb in ds.Tables["Bebida"].AsEnumerable()
                                                                                                                                                 on Convert.ToInt32(obj[1]) equals Convert.ToInt32(ped[0])
                                                                                                                                                 select new BE_Bebida
                                                                                                                                                 {

                                                                                                                                                 }).ToList() : null,
                                                  ListadePlatos = ds.Tables.Contains("Plato-Pedido") & ds.Tables.Contains("Plato") != false ? (from obj in ds.Tables["Plato-Pedido"].AsEnumerable()
                                                                                                                                               join platos in ds.Tables["Plato"].AsEnumerable()
                                                                                                                                               on Convert.ToInt32(obj[1]) equals Convert.ToInt32(ped[0])
                                                                                                                                               select new BE_Plato
                                                                                                                                               {
                                                                                                                                                   Codigo = Convert.ToInt32(platos[0]),
                                                                                                                                                   Nombre = Convert.ToString(platos[1]),
                                                                                                                                                   Tipo = (BE_Plato.Tipo_Plato)Enum.Parse(typeof(BE_Plato.Tipo_Plato), Convert.ToString(platos[2])),
                                                                                                                                                   Clase = (BE_Plato.Clasificación)Enum.Parse(typeof(BE_Plato.Clasificación), Convert.ToString(platos[3])),
                                                                                                                                                   Status = Convert.ToString(platos[4]),
                                                                                                                                                   CostoUnitario = Convert.ToDecimal(platos[5]),
                                                                                                                                                   Activo = Convert.ToBoolean(platos[6]),
                                                                                                                                                   ListaIngredientes = ds.Tables.Contains("Ingrediente") != false ? (from obje in ds.Tables["Ingrediente-Plato"].AsEnumerable()
                                                                                                                                                                                                                     join ing in ds.Tables["Ingrediente"].AsEnumerable()
                                                                                                                                                                                                                     on Convert.ToInt32(obje[1]) equals Convert.ToInt32(platos[0])
                                                                                                                                                                                                                     select new BE_Ingrediente
                                                                                                                                                                                                                     {
                                                                                                                                                                                                                         Codigo = Convert.ToInt32(ing[0]),
                                                                                                                                                                                                                         Nombre = Convert.ToString(ing[1]),
                                                                                                                                                                                                                         Tipo = (BE_Ingrediente.TipoIng)Enum.Parse(typeof(BE_Ingrediente.TipoIng), Convert.ToString(ing[2])),
                                                                                                                                                                                                                         Refrigeracion = Convert.ToBoolean(ing[3]),
                                                                                                                                                                                                                         UnidadMedida = (BE_Ingrediente.UM)Enum.Parse(typeof(BE_Ingrediente.UM), Convert.ToString(ing[4])),
                                                                                                                                                                                                                         Activo = Convert.ToBoolean(ing[5]),
                                                                                                                                                                                                                         VidaUtil = Convert.ToInt32(ing[6]),
                                                                                                                                                                                                                         Status = (BE_Ingrediente.StatusIng)Enum.Parse(typeof(BE_Ingrediente.StatusIng), Convert.ToString(ing[8])),
                                                                                                                                                                                                                         CostoUnitario = Convert.ToDecimal(ing[7])

                                                                                                                                                                                                                     }).ToList() : null

                                                                                                                                               }).ToList() : null,
                                              }).ToList();

            return ListadePedidos;

        }

        public BE_Pedido ListarObjeto(BE_Pedido pedido)
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
            Acceso = new Xml_Database();
            ListadoXML.Add(CrearPedidoXML(pedido));
            return Acceso.Modificar(ListadoXML);
        }
    }
}
