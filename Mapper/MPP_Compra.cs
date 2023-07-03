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
    public class MPP_Compra:IGestionable<BE_Compra>
    {
        private static List<BE_TuplaXML> ListadoXML;
        private static MPP_Compra mapper = null;
        public static MPP_Compra DevolverInstancia()
        {
            if (mapper == null) mapper = new MPP_Compra();
            else ListadoXML = null;
            return mapper;
        }
        ~MPP_Compra()
        {
            mapper = null;
            ListadoXML = null;
        }
        public bool Baja(BE_Compra compra)
        {
            ListadoXML = new List<BE_TuplaXML>();
            ListadoXML.Add(CrearCompraXML(compra));
            return Xml_Database.DevolverInstancia().Baja(ListadoXML);
        }

        public bool Guardar(BE_Compra compra)
        {
            ListadoXML = new List<BE_TuplaXML>();
            ListadoXML.Add(CrearCompraXML(compra));
            return Xml_Database.DevolverInstancia().Escribir(ListadoXML);
        }

        public List<BE_Compra> Listar()
        {
            DataSet ds = new DataSet();
            ds = Xml_Database.DevolverInstancia().Listar();

            List<BE_Compra> listadeCompras = ds.Tables.Contains("Compra") != false ?
                (from comp in ds.Tables["Compra"].AsEnumerable()
                 select comp[1].ToString() == MaterialCompra.Ingrediente.ToString() ?
                 new BE_CompraIngrediente
                 {
                     Codigo = Convert.ToInt32(comp[0]),
                     Material = (MaterialCompra)Enum.Parse(typeof(MaterialCompra), comp[1].ToString()),
                     ID_Material = MPP_Ingrediente.DevolverInstancia().ListarObjeto(new BE_Ingrediente { Codigo = Convert.ToInt32(comp[2]) }, ds),
                     Cantidad = Convert.ToDecimal(comp[3]),
                     FechaCompra = Convert.ToDateTime(comp[4]),
                     FechaEntrega = Convert.ToDateTime(comp[5]),
                     FechaIngreso = comp[10].ToString() != StausComp.En_Curso.ToString() ? Convert.ToDateTime(comp[6]) : (DateTime?)null,
                     CantidadRecibida = Convert.ToDecimal(comp[7]),
                     NroFactura = comp[8].ToString(),
                     Costo = comp[10].ToString() == StausComp.En_Curso.ToString() ? MPP_Costo.DevolverInstancia().DevolverCosto(new BE_Ingrediente { Codigo = Convert.ToInt32(comp[2]) }, Convert.ToDecimal(comp[3])) : Convert.ToDecimal(comp[9]),
                     Status = (StausComp)Enum.Parse(typeof(StausComp), comp[10].ToString()),
                     Activo = Convert.ToBoolean(comp[11])

                 } : (BE_Compra)new BE_CompraBebida
                 {
                     Codigo = Convert.ToInt32(comp[0]),
                     Material = (MaterialCompra)Enum.Parse(typeof(MaterialCompra), comp[1].ToString()),
                     ID_Material = MPP_Bebida.DevolverInstancia().ListarObjeto(new BE_Bebida { Codigo = Convert.ToInt32(comp[2]) }, ds),
                     Cantidad = Convert.ToDecimal(comp[3]),
                     FechaCompra = Convert.ToDateTime(comp[4]),
                     FechaEntrega = Convert.ToDateTime(comp[5]),
                     FechaIngreso = comp[10].ToString() != StausComp.En_Curso.ToString() ? Convert.ToDateTime(comp[6]) : (DateTime?)null,
                     CantidadRecibida = Convert.ToDecimal(comp[7]),
                     NroFactura = comp[8].ToString(),
                     Costo = comp[10].ToString() == StausComp.En_Curso.ToString() ? MPP_Costo.DevolverInstancia().DevolverCosto(new BE_Bebida { Codigo = Convert.ToInt32(comp[2]) }, Convert.ToDecimal(comp[3])) : Convert.ToDecimal(comp[9]),
                     Status = (StausComp)Enum.Parse(typeof(StausComp), comp[10].ToString()),
                     Activo = Convert.ToBoolean(comp[11])
                 }).ToList() : null;
            return listadeCompras;
        }

        public BE_Compra ListarObjeto(BE_Compra compra, DataSet ds = null)
        {
            if (ds is null)
            {
                ds = new DataSet();
                ds = Xml_Database.DevolverInstancia().Listar();
            }

            BE_Compra ObjetoEncontrado = ds.Tables.Contains("Compra") != false ?
                (from comp in ds.Tables["Compra"].AsEnumerable()
                 where Convert.ToInt32(comp[0]) == compra.Codigo
                 select comp[1].ToString() == MaterialCompra.Ingrediente.ToString() ?
                 new BE_CompraIngrediente
                 {
                     Codigo = Convert.ToInt32(comp[0]),
                     Material = (MaterialCompra)Enum.Parse(typeof(MaterialCompra),comp[1].ToString()),
                     ID_Material = MPP_Ingrediente.DevolverInstancia().ListarObjeto(new BE_Ingrediente { Codigo = Convert.ToInt32(comp[2]) },ds),
                     Cantidad = Convert.ToDecimal(comp[3]),
                     FechaCompra = Convert.ToDateTime(comp[4]),
                     FechaEntrega = Convert.ToDateTime(comp[5]),
                     FechaIngreso = comp[10].ToString() != StausComp.En_Curso.ToString() ? Convert.ToDateTime(comp[6]) : (DateTime?)null,
                     CantidadRecibida = Convert.ToDecimal(comp[7]),
                     NroFactura = comp[8].ToString(),
                     Costo = comp[10].ToString() == StausComp.En_Curso.ToString() ? MPP_Costo.DevolverInstancia().DevolverCosto(new BE_Ingrediente { Codigo = Convert.ToInt32(comp[2]) }, Convert.ToDecimal(comp[3])) : Convert.ToDecimal(comp[9]),
                     Status = (StausComp)Enum.Parse(typeof(StausComp), comp[10].ToString()),
                     Activo = Convert.ToBoolean(comp[11])

                 } : (BE_Compra)new BE_CompraBebida
                 {
                     Codigo = Convert.ToInt32(comp[0]),
                     Material = (MaterialCompra)Enum.Parse(typeof(MaterialCompra), comp[1].ToString()),
                     ID_Material = MPP_Bebida.DevolverInstancia().ListarObjeto(new BE_Bebida { Codigo = Convert.ToInt32(comp[2]) }, ds),
                     Cantidad = Convert.ToDecimal(comp[3]),
                     FechaCompra = Convert.ToDateTime(comp[4]),
                     FechaEntrega = Convert.ToDateTime(comp[5]),
                     FechaIngreso = comp[10].ToString() != StausComp.En_Curso.ToString() ? Convert.ToDateTime(comp[6]) : (DateTime?)null,
                     CantidadRecibida = Convert.ToDecimal(comp[7]),
                     NroFactura = comp[8].ToString(),
                     Costo = comp[10].ToString() == StausComp.En_Curso.ToString() ? MPP_Costo.DevolverInstancia().DevolverCosto(new BE_Bebida { Codigo = Convert.ToInt32(comp[2]) }, Convert.ToDecimal(comp[3])) : Convert.ToDecimal(comp[9]),
                     Status = (StausComp)Enum.Parse(typeof(StausComp), comp[10].ToString()),
                     Activo = Convert.ToBoolean(comp[11])

                 }).FirstOrDefault() : null;
            return ObjetoEncontrado;
        }

        public bool Modificar(BE_Compra compra)
        {
            ListadoXML = new List<BE_TuplaXML>();
            ListadoXML.Add(CrearCompraXML(compra));
            if (compra is BE_CompraIngrediente)
            {
                if ((int)((BE_CompraIngrediente)compra).ID_Material.Status == 1 || (int)((BE_CompraIngrediente)compra).ID_Material.Status == 3 || (int)((BE_CompraIngrediente)compra).ID_Material.Status == 5)
                {
                    ((BE_CompraIngrediente)compra).ID_Material.Status = StatusIng.Disponible;
                }
                return Xml_Database.DevolverInstancia().Modificar(ListadoXML) & MPP_Ingrediente.DevolverInstancia().Modificar(((BE_CompraIngrediente)compra).ID_Material);
            }
            else
            {
                return Xml_Database.DevolverInstancia().Modificar(ListadoXML);
            }

        }

        private BE_TuplaXML CrearCompraXML(BE_Compra compra)
        {
            BE_TuplaXML nuevaTupla = new BE_TuplaXML();
            nuevaTupla.NodoRoot = "Compras";
            nuevaTupla.NodoLeaf = "Compra";
            XElement nuevaCompra = new XElement("Compra",
                new XElement("ID", Cálculos.IDPadleft(compra.Codigo)),
                new XElement("Tipo_Material", compra.Material.ToString()),
                new XElement("ID_Material", compra.Material == MaterialCompra.Ingrediente ? ((BE_CompraIngrediente)compra).ID_Material.Codigo.ToString(): ((BE_CompraBebida)compra).ID_Material.Codigo.ToString()),
                new XElement("Cantidad", compra.Cantidad.ToString()),
                new XElement("Fecha_Compra", compra.FechaCompra.ToString("dd/MM/yyyy HH:mm:ss")),
                new XElement("Fecha_Entrega", compra.FechaEntrega.ToString("dd/MM/yyyy HH:mm:ss")),
                new XElement("Fecha_Ingreso", compra.Status != StausComp.En_Curso ? compra.FechaIngreso.Value.ToString("dd/MM/yyyy HH:mm:ss"):""),
                new XElement("Cantidad_Recibida", compra.CantidadRecibida.ToString()),
                new XElement("NroFactura", compra.NroFactura),
                new XElement("Costo", compra.Costo.ToString()),
                new XElement("Status", compra.Status.ToString()),
                new XElement("Activo",compra.Activo.ToString())
                );
            nuevaTupla.Xelement = nuevaCompra;
            return nuevaTupla;
        }
    }
}
