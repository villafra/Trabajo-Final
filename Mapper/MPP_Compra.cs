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
        Xml_Database Acceso;
        List<BE_TuplaXML> ListadoXML;

        public MPP_Compra()
        {
            ListadoXML = new List<BE_TuplaXML>();
        }

        public bool Baja(BE_Compra compra)
        {
            Acceso = new Xml_Database();
            ListadoXML.Add(CrearCompraXML(compra));
            return Acceso.Baja(ListadoXML);
        }

        public bool Guardar(BE_Compra compra)
        {
            Acceso = new Xml_Database();
            ListadoXML.Add(CrearCompraXML(compra));
            return Acceso.Escribir(ListadoXML);
        }

        public List<BE_Compra> Listar()
        {
            Acceso = new Xml_Database();
            DataSet ds = new DataSet();
            ds = Acceso.Listar();

            List<BE_Compra> listadeCompras = ds.Tables.Contains("Compra") != false ? (from comp in ds.Tables["Compra"].AsEnumerable()
                                              select new BE_Compra
                                              {
                                                  Codigo = Convert.ToInt32(comp[0]),
                                                  ID_Ingrediente = ds.Tables.Contains("Ingrediente") != false ? (from ing in ds.Tables["Ingrediente"].AsEnumerable()
                                                                                                                 where Convert.ToInt32(ing[0]) == Convert.ToInt32(comp[1])
                                                                                                                 select new BE_Ingrediente
                                                                                                                 {
                                                                                                                     Codigo = Convert.ToInt32(ing[0]),
                                                                                                                     Nombre = Convert.ToString(ing[1]),
                                                                                                                     Tipo = (TipoIng)Enum.Parse(typeof(TipoIng), Convert.ToString(ing[2])),
                                                                                                                     Refrigeracion = Convert.ToBoolean(ing[3]),
                                                                                                                     UnidadMedida = (UM)Enum.Parse(typeof(UM), Convert.ToString(ing[4])),
                                                                                                                     Activo = Convert.ToBoolean(ing[5]),
                                                                                                                     VidaUtil = Convert.ToInt32(ing[6]),
                                                                                                                     Status = (StatusIng)Enum.Parse(typeof(StatusIng), Convert.ToString(ing[7])),
                                                                                                                     CostoUnitario = Convert.ToDecimal(ing[8]),
                                                                                                                     GestionLote = Convert.ToBoolean(ing[9])
                                                                                                                 }).FirstOrDefault() : null,
                                                  Cantidad = Convert.ToDecimal(comp[2]),
                                                  FechaCompra = Convert.ToDateTime(comp[3]),
                                                  FechaEntrega = Convert.ToDateTime(comp[4]),
                                                  FechaIngreso = comp[8].ToString() != StausComp.En_Curso.ToString() ? Convert.ToDateTime(comp[5]) : (DateTime?)null,
                                                  CantidadRecibida = Convert.ToDecimal(comp[6]),
                                                  Costo = Convert.ToDecimal(comp[7]),
                                                  Status = (StausComp)Enum.Parse(typeof(StausComp), comp[8].ToString()),
                                                  Activo = Convert.ToBoolean(comp[9])
                                              }).ToList(): null;
            return listadeCompras;
        }

        public BE_Compra ListarObjeto(BE_Compra compra)
        {
            throw new NotImplementedException();
        }

        public bool Modificar(BE_Compra compra)
        {
            Acceso = new Xml_Database();
            ListadoXML.Add(CrearCompraXML(compra));
            return Acceso.Modificar(ListadoXML);
        }

        private BE_TuplaXML CrearCompraXML(BE_Compra compra)
        {
            BE_TuplaXML nuevaTupla = new BE_TuplaXML();
            nuevaTupla.NodoRoot = "Compras";
            nuevaTupla.NodoLeaf = "Compra";
            XElement nuevaCompra = new XElement("Compra",
                new XElement("ID", Cálculos.IDPadleft(compra.Codigo)),
                new XElement("ID_Ingrediente", compra.ID_Ingrediente.Codigo.ToString()),
                new XElement("Cantidad", compra.Cantidad.ToString()),
                new XElement("Fecha_Compra", compra.FechaCompra.ToString("dd/MM/yyyy HH:mm:ss")),
                new XElement("Fecha_Entrega", compra.FechaEntrega.ToString("dd/MM/yyyy HH:mm:ss")),
                new XElement("Fecha_Ingreso", compra.Status != StausComp.En_Curso ? compra.FechaIngreso.Value.ToString("dd/MM/yyyy HH:mm:ss"):""),
                new XElement("Cantidad_Recibida", compra.CantidadRecibida.ToString()),
                new XElement("Costo", compra.Costo.ToString()),
                new XElement("Status", compra.Status.ToString()),
                new XElement("Activo",compra.Activo.ToString())
                );
            nuevaTupla.Xelement = nuevaCompra;
            return nuevaTupla;
        }
    }
}
