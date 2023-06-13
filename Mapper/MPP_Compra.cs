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
            return Acceso.Borrar(ListadoXML);
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
                                                                        Tipo = Convert.ToString(ing[2]),
                                                                        Refrigeracion = Convert.ToBoolean(ing[3]),
                                                                        Stock = Convert.ToDecimal(ing[4]),
                                                                        UnidadMedida = Convert.ToString(ing[5]),
                                                                        FechaCreacion = Convert.ToDateTime(ing[6]),
                                                                        Lote = Convert.ToString(ing[7]),
                                                                        Activo = Convert.ToBoolean(ing[8]),
                                                                        VidaUtil = Convert.ToInt32(ing[9]),
                                                                        Status = Convert.ToString(ing[10]),
                                                                        CostoUnitario = Convert.ToDecimal(ing[11])
                                                                    }).FirstOrDefault():null,
                                                  Cantidad = Convert.ToDecimal(comp[2]),
                                                  FechaCompra = Convert.ToDateTime(comp[3]),
                                                  FechaEntrega = Convert.ToDateTime(comp[4]),
                                                  CantidadRecibida = Convert.ToDecimal(comp[5]),
                                                  Costo = Convert.ToDecimal(comp[6])
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
            nuevaTupla.NodoRoot = ReferenciasBD.Root;
            nuevaTupla.NodoLeaf = "Compras";
            XElement nuevaCompra = new XElement("Compra",
                new XElement("ID", compra.Codigo.ToString()),
                new XElement("ID Ingrediente", compra.ID_Ingrediente.Codigo.ToString()),
                new XElement("Cantidad", compra.Cantidad.ToString()),
                new XElement("Fecha Compra", compra.FechaCompra.ToString("dd/MM/yyyy")),
                new XElement("Fecha Entrega", compra.FechaEntrega.ToString("dd/MM/yyyy")),
                new XElement("Cantidad Recibida", compra.Cantidad.ToString()),
                new XElement("Costo", compra.Costo.ToString())
                );
            nuevaTupla.Xelement = nuevaCompra;
            return nuevaTupla;
        }
    }
}
