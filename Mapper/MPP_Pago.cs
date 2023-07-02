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
    public class MPP_Pago:IGestionable<BE_Pago>
    {
        private static List<BE_TuplaXML> ListadoXML;
        private static MPP_Pago mapper = null;
        public static MPP_Pago DevolverInstancia()
        {
            if (mapper == null) mapper = new MPP_Pago();
            else
                ListadoXML = null;
            return mapper;
        }
        ~MPP_Pago()
        {
            mapper = null;
            ListadoXML = null;
        }
        public bool Baja(BE_Pago pago)
        {
            ListadoXML = new List<BE_TuplaXML>();
            ListadoXML.Add(CrearPagoXML(pago));
            return Xml_Database.DevolverInstancia().Borrar(ListadoXML);
        }

        public bool Guardar(BE_Pago pago)
        {
            ListadoXML = new List<BE_TuplaXML>();
            ListadoXML.Add(CrearPagoXML(pago));
            return Xml_Database.DevolverInstancia().Escribir(ListadoXML);
        }

        public List<BE_Pago> Listar()
        {
            DataSet ds = new DataSet();
            ds = Xml_Database.DevolverInstancia().Listar();

            List<BE_Pago> listadePagos = ds.Tables.Contains("Pago") != false ?
                (from pag in ds.Tables["Pago"].AsEnumerable()
                 select new BE_Pago
                 {
                     Codigo = Convert.ToInt32(pag[0]),
                     Tipo = Convert.ToString(pag[1])
                 }).ToList() : null;
            return listadePagos;

        }

        public BE_Pago ListarObjeto(BE_Pago pago, DataSet ds = null)
        {
            if (ds is null)
            {
                ds = new DataSet();
                ds = Xml_Database.DevolverInstancia().Listar();
            }
            BE_Pago ObjetoEncontrado = ds.Tables.Contains("Pago") != false ?
                (from pag in ds.Tables["Pago"].AsEnumerable()
                 where Convert.ToInt32(pag[0]) == pago.Codigo
                 select new BE_Pago
                 {
                     Codigo = Convert.ToInt32(pag[0]),
                     Tipo = Convert.ToString(pag[1])
                 }).FirstOrDefault() : null;
            return ObjetoEncontrado;
        }

        public bool Modificar(BE_Pago pago)
        {
            ListadoXML = new List<BE_TuplaXML>();
            ListadoXML.Add(CrearPagoXML(pago));
            return Xml_Database.DevolverInstancia().Modificar(ListadoXML);
        }

        private BE_TuplaXML CrearPagoXML (BE_Pago pago)
        {
            BE_TuplaXML nuevaTupla = new BE_TuplaXML();
            nuevaTupla.NodoRoot = "Pagos";
            nuevaTupla.NodoLeaf = "Pago";
            XElement nuevoPago = new XElement("Pago",
                new XElement("ID", Cálculos.IDPadleft(pago.Codigo)),
                new XElement("Tipo", pago.Tipo)
                );
            nuevaTupla.Xelement = nuevoPago;
            return nuevaTupla;
        }
    }
}
