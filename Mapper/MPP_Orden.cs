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
            return Xml_Database.DevolverInstancia().Borrar(ListadoXML);
        }

        public bool Guardar(BE_Orden orden)
        {
            ListadoXML = new List<BE_TuplaXML>();
            ListadoXML.Add(CrearOrdenXML(orden));
            return Xml_Database.DevolverInstancia().Escribir(ListadoXML);
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
                     Pasos_Orden = Convert.ToInt32(ord[1]),
                     Status = Convert.ToString(ord[2]),
                     ID_Pedido = MPP_Pedido.DevolverInstancia().ListarObjeto(new BE_Pedido { Codigo = Convert.ToInt32(ord[3])},ds),
                     ID_Mesa = MPP_Mesa.DevolverInstancia().ListarObjeto(new BE_Mesa { Codigo = Convert.ToInt32(ord[4])},ds),
                     ID_Empleado = MPP_Empleado.DevolverInstancia().ListarObjeto(new BE_Mozo { Codigo = Convert.ToInt32(ord[5])},ds)
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
                     Pasos_Orden = Convert.ToInt32(ord[1]),
                     Status = Convert.ToString(ord[2]),
                     ID_Pedido = MPP_Pedido.DevolverInstancia().ListarObjeto(new BE_Pedido { Codigo = Convert.ToInt32(ord[3]) },ds),
                     ID_Mesa = MPP_Mesa.DevolverInstancia().ListarObjeto(new BE_Mesa { Codigo = Convert.ToInt32(ord[4]) },ds),
                     ID_Empleado = MPP_Empleado.DevolverInstancia().ListarObjeto(new BE_Mozo { Codigo = Convert.ToInt32(ord[5]) },ds)
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
            nuevaTupla.NodoLeaf = "Ordene";
            XElement nuevaOrden = new XElement("Orden",
                new XElement("ID", Cálculos.IDPadleft(orden.Codigo)),
                new XElement("Pasos Orden", orden.Pasos_Orden.ToString()),
                new XElement("Status", orden.Status),
                new XElement("ID Pedido", orden.ID_Pedido.ToString()),
                new XElement("ID Mesa", orden.ID_Mesa.ToString()),
                new XElement("ID Empleado", orden.ID_Empleado.ToString())
                );
            nuevaTupla.Xelement = nuevaOrden;
            return nuevaTupla;
        }
    }
}
