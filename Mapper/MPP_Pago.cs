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
    public class MPP_Pago:IGestionable<BE_Pago>
    {
        Xml_Database Acceso;
        List<BE_TuplaXML> ListadoXML;

        public MPP_Pago()
        {
            ListadoXML = new List<BE_TuplaXML>();
        }

        public bool Baja(BE_Pago pago)
        {
            Acceso = new Xml_Database();
            ListadoXML.Add(CrearPagoXML(pago));
            return Acceso.Borrar(ListadoXML);
        }

        public bool Guardar(BE_Pago pago)
        {
            Acceso = new Xml_Database();
            ListadoXML.Add(CrearPagoXML(pago));
            return Acceso.Escribir(ListadoXML);
        }

        public List<BE_Pago> Listar()
        {
            Acceso = new Xml_Database();
            DataSet ds = new DataSet();
            ds = Acceso.Listar();

            List<BE_Pago> listadePagos = (from pag in ds.Tables["Pago"].AsEnumerable()
                                          select new BE_Pago
                                          {
                                              Codigo = Convert.ToInt32(pag[0]),
                                              Tipo = Convert.ToString(pag[1])
                                          }).ToList();
            return listadePagos;

        }

        public BE_Pago ListarObjeto(BE_Pago pago)
        {
            throw new NotImplementedException();
        }

        public bool Modificar(BE_Pago pago)
        {
            Acceso = new Xml_Database();
            ListadoXML.Add(CrearPagoXML(pago));
            return Acceso.Modificar(ListadoXML);
        }

        private BE_TuplaXML CrearPagoXML (BE_Pago pago)
        {
            BE_TuplaXML nuevaTupla = new BE_TuplaXML();
            nuevaTupla.NodoRoot = "Pagos";
            nuevaTupla.NodoLeaf = "Pago";
            XElement nuevoPago = new XElement("Pago",
                new XElement("ID", pago.Codigo.ToString()),
                new XElement("Tipo", pago.Tipo)
                );
            nuevaTupla.Xelement = nuevoPago;
            return nuevaTupla;
        }
    }
}
