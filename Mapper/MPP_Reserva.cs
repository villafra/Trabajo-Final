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
    public class MPP_Reserva:IGestionable<BE_Reserva>
    {
        private static List<BE_TuplaXML> ListadoXML;
        private static MPP_Reserva mapper = null;
        public static MPP_Reserva DevolverInstancia()
        {
            if (mapper == null) mapper = new MPP_Reserva();
            else
                ListadoXML = null;
            return mapper;
        }
        ~MPP_Reserva()
        {
            mapper = null;
            ListadoXML = null;
        }
        public bool Baja(BE_Reserva reserva)
        {
            ListadoXML = new List<BE_TuplaXML>();
            ListadoXML.Add(CrearReservaXML(reserva));
            return Xml_Database.DevolverInstancia().Borrar(ListadoXML);
        }

        public bool Guardar(BE_Reserva reserva)
        {
            ListadoXML = new List<BE_TuplaXML>();
            ListadoXML.Add(CrearReservaXML(reserva));
            return Xml_Database.DevolverInstancia().Escribir(ListadoXML);
        }

        public List<BE_Reserva> Listar()
        {
            DataSet ds = new DataSet();
            ds = Xml_Database.DevolverInstancia().Listar();

            List<BE_Reserva> listaReservas = ds.Tables.Contains("Reserva") != false ?
                (from res in ds.Tables["Reserva"].AsEnumerable()
                 select new BE_Reserva
                 {
                     Codigo = Convert.ToInt32(res[0]),
                     FechaInicio = Convert.ToDateTime(res[1]),
                     HoraInicio = Convert.ToDateTime(res[2]),
                     HoraFin = Convert.ToDateTime(res[3]),
                     Recurrencia = Convert.ToBoolean(res[4]),
                     FechaFin = Convert.ToDateTime(res[5]),
                     TipoRecurrencia = Convert.ToString(res[6]),
                     ID_Pedido = MPP_Pedido.DevolverInstancia().ListarObjeto(new BE_Pedido { Codigo = Convert.ToInt32(res[7])},ds)
                 }).ToList() : null;
            return listaReservas;
        }

        public BE_Reserva ListarObjeto(BE_Reserva reserva, DataSet ds=null)
        {
            if (ds is null)
            {
                ds = new DataSet();
                ds = Xml_Database.DevolverInstancia().Listar();
            }
            BE_Reserva ObjetoEncontrado = ds.Tables.Contains("Reserva") != false ?
                (from res in ds.Tables["Reserva"].AsEnumerable()
                 where Convert.ToInt32(res[0]) == reserva.Codigo
                 select new BE_Reserva
                 {
                     Codigo = Convert.ToInt32(res[0]),
                     FechaInicio = Convert.ToDateTime(res[1]),
                     HoraInicio = Convert.ToDateTime(res[2]),
                     HoraFin = Convert.ToDateTime(res[3]),
                     Recurrencia = Convert.ToBoolean(res[4]),
                     FechaFin = Convert.ToDateTime(res[5]),
                     TipoRecurrencia = Convert.ToString(res[6]),
                     ID_Pedido = MPP_Pedido.DevolverInstancia().ListarObjeto(new BE_Pedido { Codigo = Convert.ToInt32(res[7]) },ds)
                 }).FirstOrDefault() : null;
            return ObjetoEncontrado;
        }

        public bool Modificar(BE_Reserva reserva)
        {
            ListadoXML = new List<BE_TuplaXML>();
            ListadoXML.Add(CrearReservaXML(reserva));
            return Xml_Database.DevolverInstancia().Modificar(ListadoXML);
        }

        private BE_TuplaXML CrearReservaXML(BE_Reserva reserva)
        {
            BE_TuplaXML nuevaTupla = new BE_TuplaXML();
            nuevaTupla.NodoRoot = "Reservas";
            nuevaTupla.NodoLeaf = "Reserva";
            XElement nuevaReserva = new XElement("Reserva",
                new XElement("ID", Cálculos.IDPadleft(reserva.Codigo)),
                new XElement("Fecha Inicio", reserva.FechaInicio.ToString("dd/MM/yyyy")),
                new XElement("Hora Inicio",reserva.HoraInicio.ToString("HH:mm")),
                new XElement("Hora Fin",reserva.HoraFin.ToString("HH:mm")),
                new XElement("Recurrencia", reserva.Recurrencia.ToString()),
                new XElement("Fecha Fin", reserva.FechaFin.ToString("dd/MM/yyyy")),
                new XElement("Tipo Recurrencia",reserva.TipoRecurrencia),
                new XElement("ID Pedido", reserva.ID_Pedido.Codigo.ToString())
                );
            nuevaTupla.Xelement = nuevaReserva;
            return nuevaTupla;
        }

       
    }
}
