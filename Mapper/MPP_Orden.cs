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
    public class MPP_Orden:IGestionable<BE_Orden>
    {
        private static List<BE_TuplaXML> ListadoXML;
        private static MPP_Orden mapper = null;
        public static MPP_Orden DevolverInstancia()
        {
            if (mapper == null) mapper = new MPP_Orden();
            else
                ListadoXML = null;
            return mapper;
        }
        ~MPP_Orden()
        {
            mapper = null;
            ListadoXML = null;
        }
        public bool Baja(BE_Orden orden)
        {
            ListadoXML = new List<BE_TuplaXML>();
            ListadoXML.Add(CrearOrdenXML(orden));
            return Xml_Database.DevolverInstancia().Baja(ListadoXML);
        }

        public bool Guardar(BE_Orden orden)
        {
            ListadoXML = new List<BE_TuplaXML>();
            ListadoXML.Add(CrearOrdenXML(orden));
            return Xml_Database.DevolverInstancia().Escribir(ListadoXML);
        }

        public object ListarEnEntrega()
        {
            DataSet ds = new DataSet();
            ds = Xml_Database.DevolverInstancia().Listar();

            List<BE_Orden> listadeOrdenes = ds.Tables.Contains("Orden") != false ?
                (from ord in ds.Tables["Orden"].AsEnumerable()
                 where ord[1].ToString() == StatusOrden.Bebidas_Listas.ToString() ||
                 ord[1].ToString() == StatusOrden.Platos_Listos.ToString()
                 && Convert.ToBoolean(ord[6])
                 select new BE_Orden
                 {
                     Codigo = Convert.ToInt32(ord[0]),
                     Status = (StatusOrden)Enum.Parse(typeof(StatusOrden), Convert.ToString(ord[1])),
                     ID_Pedido = ord[2].ToString() != "" ? MPP_Pedido.DevolverInstancia().ListarObjeto(new BE_Pedido { Codigo = Convert.ToInt32(ord[2]) }, ds) : null,
                     ID_Mesa = ord[3].ToString() != "" ? MPP_Mesa.DevolverInstancia().ListarObjeto(new BE_Mesa { Codigo = Convert.ToInt32(ord[3]) }, ds) : null,
                     ID_Empleado = ord[4].ToString() != "" ? MPP_Empleado.DevolverInstancia().ListarObjeto(new BE_Mozo { Codigo = Convert.ToInt32(ord[4]) }, ds) : null,
                     Finalizada = Convert.ToBoolean(ord[5]),
                     Activo = Convert.ToBoolean(ord[6])
                 }).ToList() : null;
            return listadeOrdenes;
        }

        public List<BE_Orden> Listar()
        {
            DataSet ds = new DataSet();
            ds = Xml_Database.DevolverInstancia().Listar();

            List<BE_Orden> listadeOrdenes = ds.Tables.Contains("Orden") != false ?
                (from ord in ds.Tables["Orden"].AsEnumerable()
                 select new BE_Orden
                 {
                     Codigo = Convert.ToInt32(ord[0]),
                     Status = (StatusOrden)Enum.Parse(typeof(StatusOrden), Convert.ToString(ord[1])),
                     ID_Pedido = ord[2].ToString() != "" ? MPP_Pedido.DevolverInstancia().ListarObjeto(new BE_Pedido { Codigo = Convert.ToInt32(ord[2]) }, ds) : null,
                     ID_Mesa = ord[3].ToString() != "" ? MPP_Mesa.DevolverInstancia().ListarObjeto(new BE_Mesa { Codigo = Convert.ToInt32(ord[3]) }, ds) : null,
                     ID_Empleado = ord[4].ToString() != "" ? MPP_Empleado.DevolverInstancia().ListarObjeto(new BE_Mozo { Codigo = Convert.ToInt32(ord[4]) }, ds) : null,
                     Finalizada = Convert.ToBoolean(ord[5]),
                     Activo = Convert.ToBoolean(ord[6])
                 }).ToList() : null;
            return listadeOrdenes;
        }
        public List<BE_Orden> ListarEnEsperaBebidas()
        {
            DataSet ds = new DataSet();
            ds = Xml_Database.DevolverInstancia().Listar();

            List<BE_Orden> listadeOrdenes = ds.Tables.Contains("Orden") != false ?
                (from ord in ds.Tables["Orden"].AsEnumerable()
                 where ord[1].ToString() == StatusOrden.En_Espera_Bebidas.ToString() && Convert.ToBoolean(ord[6])
                 select new BE_Orden
                 {
                     Codigo = Convert.ToInt32(ord[0]),
                     Status = (StatusOrden)Enum.Parse(typeof(StatusOrden), Convert.ToString(ord[1])),
                     ID_Pedido = ord[2].ToString() != "" ? MPP_Pedido.DevolverInstancia().ListarObjeto(new BE_Pedido { Codigo = Convert.ToInt32(ord[2]) }, ds) : null,
                     ID_Mesa = ord[3].ToString() != "" ? MPP_Mesa.DevolverInstancia().ListarObjeto(new BE_Mesa { Codigo = Convert.ToInt32(ord[3]) }, ds) : null,
                     ID_Empleado = ord[4].ToString() != "" ? MPP_Empleado.DevolverInstancia().ListarObjeto(new BE_Mozo { Codigo = Convert.ToInt32(ord[4]) }, ds) : null,
                     Finalizada = Convert.ToBoolean(ord[5]),
                     Activo = Convert.ToBoolean(ord[6])
                 }).ToList() : null;
            return listadeOrdenes;
        }
        public List<BE_Orden> ListarEnEsperaPlatos()
        {
            DataSet ds = new DataSet();
            ds = Xml_Database.DevolverInstancia().Listar();

            List<BE_Orden> listadeOrdenes = ds.Tables.Contains("Orden") != false ?
                (from ord in ds.Tables["Orden"].AsEnumerable()
                 where ord[1].ToString() == StatusOrden.En_Espera_Platos.ToString() ||
                 ord[1].ToString() == StatusOrden.Bebidas_Entregadas.ToString()
                 && Convert.ToBoolean(ord[6])
                 select new BE_Orden
                 {
                     Codigo = Convert.ToInt32(ord[0]),
                     Status = (StatusOrden)Enum.Parse(typeof(StatusOrden), Convert.ToString(ord[1])),
                     ID_Pedido = ord[2].ToString() != "" ? MPP_Pedido.DevolverInstancia().ListarObjeto(new BE_Pedido { Codigo = Convert.ToInt32(ord[2]) }, ds) : null,
                     ID_Mesa = ord[3].ToString() != "" ? MPP_Mesa.DevolverInstancia().ListarObjeto(new BE_Mesa { Codigo = Convert.ToInt32(ord[3]) }, ds) : null,
                     ID_Empleado = ord[4].ToString() != "" ? MPP_Empleado.DevolverInstancia().ListarObjeto(new BE_Mozo { Codigo = Convert.ToInt32(ord[4]) }, ds) : null,
                     Finalizada = Convert.ToBoolean(ord[5]),
                     Activo = Convert.ToBoolean(ord[6])
                 }).ToList() : null;
            return listadeOrdenes;
        }
        public List<BE_Orden> ListarOrdenesEntregadas()
        {
            DataSet ds = new DataSet();
            ds = Xml_Database.DevolverInstancia().Listar();

            List<BE_Orden> listadeOrdenes = ds.Tables.Contains("Orden") != false ?
                (from ord in ds.Tables["Orden"].AsEnumerable()
                 where ord[1].ToString() == StatusOrden.Orden_Entregada.ToString()
                 && Convert.ToBoolean(ord[6]) && Convert.ToBoolean(ord[5]) == false
                 select new BE_Orden
                 {
                     Codigo = Convert.ToInt32(ord[0]),
                     Status = (StatusOrden)Enum.Parse(typeof(StatusOrden), Convert.ToString(ord[1])),
                     ID_Pedido = ord[2].ToString() != "" ? MPP_Pedido.DevolverInstancia().ListarObjeto(new BE_Pedido { Codigo = Convert.ToInt32(ord[2]) }, ds) : null,
                     ID_Mesa = ord[3].ToString() != "" ? MPP_Mesa.DevolverInstancia().ListarObjeto(new BE_Mesa { Codigo = Convert.ToInt32(ord[3]) }, ds) : null,
                     ID_Empleado = ord[4].ToString() != "" ? MPP_Empleado.DevolverInstancia().ListarObjeto(new BE_Mozo { Codigo = Convert.ToInt32(ord[4]) }, ds) : null,
                     Finalizada = Convert.ToBoolean(ord[5]),
                     Activo = Convert.ToBoolean(ord[6])
                 }).ToList() : null;
            return listadeOrdenes;
        }
        public BE_Orden ListarObjeto(BE_Orden orden, DataSet ds=null)
        {
            if (ds is null)
            {
                ds = new DataSet();
                ds = Xml_Database.DevolverInstancia().Listar();
            }
            BE_Orden ObjetoEncontrado = ds.Tables.Contains("Orden") != false ?
                (from ord in ds.Tables["Orden"].AsEnumerable()
                 where Convert.ToInt32(ord[0]) == orden.Codigo
                 select new BE_Orden
                 {
                     Codigo = Convert.ToInt32(ord[0]),
                     Status = (StatusOrden)Enum.Parse(typeof(StatusOrden), Convert.ToString(ord[1])),
                     ID_Pedido = ord[2].ToString() != "" ? MPP_Pedido.DevolverInstancia().ListarObjeto(new BE_Pedido { Codigo = Convert.ToInt32(ord[2]) }, ds) : null,
                     ID_Mesa = ord[3].ToString() != "" ? MPP_Mesa.DevolverInstancia().ListarObjeto(new BE_Mesa { Codigo = Convert.ToInt32(ord[3]) }, ds) : null,
                     ID_Empleado = ord[4].ToString() != "" ? MPP_Empleado.DevolverInstancia().ListarObjeto(new BE_Mozo { Codigo = Convert.ToInt32(ord[4]) }, ds) : null,
                     Finalizada = Convert.ToBoolean(ord[5]),
                     Activo = Convert.ToBoolean(ord[6])
                 }).FirstOrDefault() : null;
            return ObjetoEncontrado;
        }

        public bool Modificar(BE_Orden orden)
        {
            ListadoXML = new List<BE_TuplaXML>();
            ListadoXML.Add(CrearOrdenXML(orden));
            return Xml_Database.DevolverInstancia().Modificar(ListadoXML);
        }

        private BE_TuplaXML CrearOrdenXML (BE_Orden orden)
        {
            BE_TuplaXML nuevaTupla = new BE_TuplaXML();
            nuevaTupla.NodoRoot = "Ordenes";
            nuevaTupla.NodoLeaf = "Orden";
            XElement nuevaOrden = new XElement("Orden",
                new XElement("ID", Cálculos.IDPadleft(orden.Codigo)),
                new XElement("Status", orden.Status.ToString()),
                new XElement("ID_Pedido", orden.ID_Pedido.Codigo.ToString()),
                new XElement("ID_Mesa", orden.ID_Mesa != null ? orden.ID_Mesa.Codigo.ToString() : null),
                new XElement("ID_Empleado", orden.ID_Empleado != null ? orden.ID_Empleado.Codigo.ToString() : null),
                new XElement("Finalizada", orden.Finalizada.ToString()),
                new XElement("Activo", orden.Activo.ToString())
                );
            nuevaTupla.Xelement = nuevaOrden;
            return nuevaTupla;
        }
    }
}
