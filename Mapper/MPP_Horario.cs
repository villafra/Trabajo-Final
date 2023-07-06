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
    public class MPP_Horario : IGestionable<BE_Horario>
    {
        private static List<BE_TuplaXML> ListadoXML;
        private static MPP_Horario mapper = null;
        public static MPP_Horario DevolverInstancia()
        {
            if (mapper == null) mapper = new MPP_Horario();
            else
                ListadoXML = null;
            return mapper;
        }
        ~MPP_Horario()
        {
            mapper = null;
            ListadoXML = null;
        }

        public void CrearAgenda(List<BE_Horario> agenda)
        {
            CrearAgendaXML(agenda);
            Xml_Database.DevolverInstancia().CrearCalendario(ListadoXML);
        }
 
        public bool Baja(BE_Horario horario)
        {
            throw new NotImplementedException();
        }

        public bool Guardar(BE_Horario horario)
        {
            throw new NotImplementedException();
        }

        public List<BE_Horario> Listar()
        {
            DataSet ds = new DataSet();
            ds = Xml_Database.DevolverInstancia().Listar();

            List<BE_Horario> calendario = ds.Tables.Contains("Calendario") != false ? (from dia in ds.Tables["Calendario"].AsEnumerable()
                                           select new BE_Horario
                                           {
                                               Codigo = Convert.ToInt32(dia[0]),
                                               Día = Convert.ToDateTime(dia[1]),
                                               Hora = Convert.ToInt32(dia[2]),
                                               Disponible = Convert.ToBoolean(dia[3]),
                                               ID_Reserva = ds.Tables.Contains("Reserva") !=false ?  (from res in ds.Tables["Reserva"].AsEnumerable()
                                                             where Convert.ToInt32(dia[4]) == Convert.ToInt32(res[0])
                                                             select new BE_Reserva
                                                             {
                                                                 Codigo = Convert.ToInt32(res[0]),
                                                                 FechaInicio = Convert.ToDateTime(res[1]),
                                                                 HoraInicio = Convert.ToDateTime(res[2]),
                                                                 HoraFin = Convert.ToDateTime(res[3]),
                                                                 Recurrencia = Convert.ToBoolean(res[4]),
                                                                 FechaFin = Convert.ToDateTime(res[5]),
                                                                 TipoRecurrencia = Convert.ToString(res[6]),
                                                                 ID_Pedido = ds.Tables.Contains("Pedido") != false ? (from ped in ds.Tables["Pedido"].AsEnumerable()
                                                                              where Convert.ToInt32(res[8]) == Convert.ToInt32(ped[0])
                                                                              select new BE_Pedido
                                                                              {
                                                                                  Codigo = Convert.ToInt32(ped[0]),
                                                                                  FechaInicio = Convert.ToDateTime(ped[1]),
                                                                                  Customizado = Convert.ToBoolean(ped[2]),
                                                                                  Aclaraciones = Convert.ToString(ped[3]),
                                                                                  Monto_Total = Convert.ToDecimal(ped[5]),
                                                                                  ID_Pago = ds.Tables.Contains("Pago") != false ? (from pago in ds.Tables["Pago"].AsEnumerable()
                                                                                             where Convert.ToInt32(ped[6]) == Convert.ToInt32(pago[0])
                                                                                             select new BE_Pago
                                                                                             {
                                                                                                 Codigo = Convert.ToInt32(pago[0]),
                                                                                                 Tipo = Convert.ToString(pago[1])
                                                                                             }).FirstOrDefault() : null,
                                                                                  ListadeBebida = ds.Tables.Contains("Bebida") && ds.Tables.Contains("Bebida-Pedido") != false ? (from obj in ds.Tables["Bebida-Pedido"].AsEnumerable()
                                                                                                   join beb in ds.Tables["Bebida"].AsEnumerable()
                                                                                                   on Convert.ToInt32(obj[1]) equals Convert.ToInt32(ped[0])
                                                                                                   select new BE_Bebida
                                                                                                   {

                                                                                                   }).ToList() : null,
                                                                                  ListadePlatos = ds.Tables.Contains("Plato") && ds.Tables.Contains("Plato-Pedido") != false ? (from obj in ds.Tables["Plato-Pedido"].AsEnumerable()
                                                                                                   join platos in ds.Tables["Plato"].AsEnumerable()
                                                                                                   on Convert.ToInt32(obj[1]) equals Convert.ToInt32(ped[0])
                                                                                                   select new BE_Plato
                                                                                                   {
                                                                                                       Codigo = Convert.ToInt32(platos[0]),
                                                                                                       Nombre = Convert.ToString(platos[1]),
                                                                                                       Tipo = (Tipo_Plato)Enum.Parse(typeof(Tipo_Plato), Convert.ToString(platos[2])),
                                                                                                       Clase = (Clasificación)Enum.Parse(typeof(Clasificación), Convert.ToString(platos[3])),
                                                                                                       CostoUnitario = Convert.ToDecimal(platos[4]),
                                                                                                       Activo = Convert.ToBoolean(platos[5]),
                                                                                                       ListaIngredientes = ds.Tables.Contains("Ingrediente") & ds.Tables.Contains("Ingrediente-Pedido") != false ? (from obje in ds.Tables["Ingrediente-Plato"].AsEnumerable()
                                                                                                                            join ing in ds.Tables["Ingrediente"].AsEnumerable()
                                                                                                                            on Convert.ToInt32(obje[1]) equals Convert.ToInt32(platos[0])
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
                                                                                                                                GestionLote = Convert.ToBoolean(ing[8])

                                                                                                                            }).ToList() : null

                                                                                                   }).ToList() :  null,

                                                                              }).FirstOrDefault() : null,

                                                             }).FirstOrDefault(): null,
                                           }).ToList() : null;

            return calendario;

        }

        public BE_Horario ListarObjeto(BE_Horario horario,DataSet ds = null)
        {
            throw new NotImplementedException();
        }

        public bool Modificar(BE_Horario horario)
        {
            throw new NotImplementedException();
        }

        private void CrearAgendaXML(List<BE_Horario> Calendario)
        {
            foreach(BE_Horario hora in Calendario)
            {
                BE_TuplaXML nuevaTupla = new BE_TuplaXML();
                nuevaTupla.NodoRoot = "Calendarios";
                nuevaTupla.NodoLeaf = "Calendario";
                XElement nuevaHora = new XElement("Calendario",
                    new XElement("ID", Cálculos.IDPadleft(hora.Codigo)),
                    new XElement("Dia", hora.Día.ToString("dd/MM/yyy HH:mm:ss")),
                    new XElement("Hora", hora.Hora.ToString()),
                    new XElement("Disponible", hora.Disponible.ToString()),
                    new XElement("ID_Reserva", hora.ID_Reserva != null ? hora.ID_Reserva.Codigo.ToString() : "")
                    );
                nuevaTupla.Xelement = nuevaHora;
                ListadoXML.Add(nuevaTupla);
            }
        }
        public void ActualizarAgenda(List<BE_Horario> agenda)
        {
            DateTime limite = DateTime.Now.AddDays(-1);
            agenda.RemoveAll(x => x.Día < limite);
        }

        private BE_TuplaXML CrearAppointmentXML(BE_Horario horario)
        {
            BE_TuplaXML nuevaTupla = new BE_TuplaXML();
            nuevaTupla.NodoRoot = ReferenciasBD.Root;
            nuevaTupla.NodoLeaf = "Calendarios";

            XElement nuevaHora = new XElement("Calendario",
               new XElement("ID_Horario", Cálculos.IDPadleft(horario.Codigo)),
               new XElement("Día", horario.Día.ToString("dd/MM/yyyy HH:mm:ss")),
               new XElement("Hora", horario.Hora.ToString()),
               new XElement("Disponible", horario.Disponible.ToString()),
               new XElement("ID_Reserva", horario.ID_Reserva.Codigo.ToString())
               );
            nuevaTupla.Xelement = nuevaHora;


            return nuevaTupla;
        }

    }
}
