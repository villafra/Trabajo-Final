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

        public bool Baja(BE_Pago pago)
        {
            Acceso = new Xml_Database();
            return Acceso.Borrar("Pagos", "Pago", CrearPagoXML(pago));
        }

        public bool Guardar(BE_Pago pago)
        {
            Acceso = new Xml_Database();
            return Acceso.Escribir("Pago", CrearPagoXML(pago));
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
            return Acceso.Modificar("Pagos", "Pago", CrearPagoXML(pago));
        }

        private XElement CrearPagoXML (BE_Pago pago)
        {
            XElement nuevoPago = new XElement("Pago",
                new XElement("ID", pago.Codigo.ToString()),
                new XElement("Tipo", pago.Tipo)
                );
            return nuevoPago;
        }
    }
}
