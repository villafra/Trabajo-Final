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
        Xml_Database Acceso;
        List<BE_TuplaXML> ListadoXML;

        public bool Baja(BE_Orden orden)
        {
            Acceso = new Xml_Database();
            ListadoXML = new List<BE_TuplaXML>();
            ListadoXML.Add(CrearOrdenXML(orden));
            return Acceso.Borrar(ListadoXML);
        }

        public bool Guardar(BE_Orden orden)
        {
            Acceso = new Xml_Database();
            ListadoXML = new List<BE_TuplaXML>();
            ListadoXML.Add(CrearOrdenXML(orden));
            return Acceso.Escribir(ListadoXML);
        }

        public List<BE_Orden> Listar()
        {
            Acceso = new Xml_Database();
            DataSet ds = new DataSet();
            ds = Acceso.Listar();

            List<BE_Orden> listadeOrdenes = ds.Tables.Contains("Orden") != false ?
                (from ord in ds.Tables["Orden"].AsEnumerable()
                 select new BE_Orden
                 {
                     Codigo = Convert.ToInt32(ord[0]),
                     Pasos_Orden = Convert.ToInt32(ord[1]),
                     Status = Convert.ToString(ord[2]),
                     ID_Pedido = new MPP_Pedido().ListarObjeto(new BE_Pedido { Codigo = Convert.ToInt32(ord[3])}),
                     ID_Mesa = new MPP_Mesa().ListarObjeto(new BE_Mesa { Codigo = Convert.ToInt32(ord[4])}),
                     ID_Empleado = new MPP_Empleado().ListarObjeto(new BE_Mozo { Codigo = Convert.ToInt32(ord[5])})
                 }).ToList() : null;
            return listadeOrdenes;
        }

        public BE_Orden ListarObjeto(BE_Orden orden)
        {
            Acceso = new Xml_Database();
            DataSet ds = new DataSet();
            ds = Acceso.Listar();

            BE_Orden ObjetoEncontrado = ds.Tables.Contains("Orden") != false ?
                (from ord in ds.Tables["Orden"].AsEnumerable()
                 where Convert.ToInt32(ord[0]) == orden.Codigo
                 select new BE_Orden
                 {
                     Codigo = Convert.ToInt32(ord[0]),
                     Pasos_Orden = Convert.ToInt32(ord[1]),
                     Status = Convert.ToString(ord[2]),
                     ID_Pedido = new MPP_Pedido().ListarObjeto(new BE_Pedido { Codigo = Convert.ToInt32(ord[3]) }),
                     ID_Mesa = new MPP_Mesa().ListarObjeto(new BE_Mesa { Codigo = Convert.ToInt32(ord[4]) }),
                     ID_Empleado = new MPP_Empleado().ListarObjeto(new BE_Mozo { Codigo = Convert.ToInt32(ord[5]) })
                 }).FirstOrDefault() : null;
            return ObjetoEncontrado;
        }

        public bool Modificar(BE_Orden orden)
        {
            Acceso = new Xml_Database();
            ListadoXML = new List<BE_TuplaXML>();
            ListadoXML.Add(CrearOrdenXML(orden));
            return Acceso.Modificar(ListadoXML);
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
