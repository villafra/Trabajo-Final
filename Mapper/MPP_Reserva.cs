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
    public class MPP_Reserva:IGestionable<BE_Reserva>
    {
        Xml_Database Acceso;
        Dictionary<string, string> DicReserva = new Dictionary<string, string>();

        public MPP_Reserva()
        {
            DicReserva.Add("Reservas","Reserva");
        }

        public bool Baja(BE_Reserva reserva)
        {
            Acceso = new Xml_Database();
            return Acceso.Borrar(DicReserva, CrearReservaXML(reserva));
        }

        public bool Guardar(BE_Reserva reserva)
        {
            Acceso = new Xml_Database();
            return Acceso.Escribir(DicReserva, CrearReservaXML(reserva));
        }

        public List<BE_Reserva> Listar()
        {
            Acceso = new Xml_Database();
            DataSet ds = new DataSet();
            ds = Acceso.Listar();

            List<BE_Reserva> listaReservas = (from res in ds.Tables["Reserva"].AsEnumerable()
                                              select new BE_Reserva
                                              {
                                                  Codigo = Convert.ToInt32(res[0]),
                                                  FechaInicio = Convert.ToDateTime(res[1]),
                                                  HoraInicio = Convert.ToDateTime(res[2]),
                                                  HoraFin = Convert.ToDateTime(res[3]),
                                                  Recurrencia = Convert.ToBoolean(res[4]),
                                                  FechaFin = Convert.ToDateTime(res[5]),
                                                  TipoRecurrencia = Convert.ToString(res[6]),
                                                  ID_Cliente = (from cli in ds.Tables["Cliente"].AsEnumerable()
                                                                where Convert.ToInt32(cli[0]) == Convert.ToInt32(res[7])
                                                                select new BE_Cliente
                                                                {
                                                                    Codigo = Convert.ToInt32(cli[0]),
                                                                    DNI = Convert.ToInt64(cli[1]),
                                                                    Nombre = Convert.ToString(cli[2]),
                                                                    Apellido = Convert.ToString(cli[3]),
                                                                    FechaNacimiento = Convert.ToDateTime(cli[4]),
                                                                    Telefono = Convert.ToString(cli[5]),
                                                                    Mail = Convert.ToString(cli[6]),
                                                                    ListadeBebidas = (from obj in ds.Tables["Bebida-Cliente"].AsEnumerable()
                                                                                      join beb in ds.Tables["Bebida"].AsEnumerable()
                                                                                      on Convert.ToInt32(obj[1]) equals Convert.ToInt32(cli[0])
                                                                                      select new BE_Bebida
                                                                                      {

                                                                                      }).ToList(),
                                                                    ListadePlatos = (from obj in ds.Tables["Plato-Cliente"].AsEnumerable()
                                                                                     join platos in ds.Tables["Plato"].AsEnumerable()
                                                                                     on Convert.ToInt32(obj[1]) equals Convert.ToInt32(cli[0])
                                                                                     select new BE_Plato
                                                                                     {
                                                                                         Codigo = Convert.ToInt32(platos[0]),
                                                                                         Nombre = Convert.ToString(platos[1]),
                                                                                         Tipo = Convert.ToString(platos[2]),
                                                                                         Clase = Convert.ToString(platos[3]),
                                                                                         Status = Convert.ToString(platos[4]),
                                                                                         CostoUnitario = Convert.ToDecimal(platos[5]),
                                                                                         Activo = Convert.ToBoolean(platos[6]),
                                                                                         ListaIngredientes = (from obje in ds.Tables["Ingrediente-Plato"].AsEnumerable()
                                                                                                              join ing in ds.Tables["Ingrediente"].AsEnumerable()
                                                                                                              on Convert.ToInt32(obje[1]) equals Convert.ToInt32(platos[0])
                                                                                                              select new BE_Ingrediente
                                                                                                              {
                                                                                                                  Codigo = Convert.ToInt32(ing[0]),
                                                                                                                  Nombre = Convert.ToString(ing[1]),
                                                                                                                  Tipo = Convert.ToString(ing[2]),
                                                                                                                  Refrigeracion = Convert.ToBoolean(ing[3]),
                                                                                                                  Stock = Convert.ToDecimal(ing[4]),
                                                                                                                  UnidadMedida = Convert.ToString(ing[5]),
                                                                                                                  Lote = Convert.ToString(ing[6]),
                                                                                                                  Activo = Convert.ToBoolean(ing[7]),
                                                                                                                  VidaUtil = Convert.ToInt32(ing[8]),
                                                                                                                  Status = Convert.ToString(ing[9]),
                                                                                                                  CostoUnitario = Convert.ToDecimal(ing[10])

                                                                                                              }).ToList()

                                                                                     }).ToList(),
                                                                    ListaReservas = (from obj in ds.Tables["Plato-Cliente"].AsEnumerable()
                                                                                     join res1 in ds.Tables["Reserva"].AsEnumerable()
                                                                                     on Convert.ToInt32(obj[1]) equals Convert.ToInt32(res1[0])
                                                                                     select new BE_Reserva
                                                                                     {



                                                                                     }).ToList()

                                                                }).FirstOrDefault(),
                                                  ID_Pedido = (from ped in ds.Tables["Pedido"].AsEnumerable()
                                                               where Convert.ToInt32(res[8]) == Convert.ToInt32(ped[0])
                                                               select new BE_Pedido
                                                               {
                                                                   Codigo = Convert.ToInt32(ped[0]),
                                                                   FechaInicio = Convert.ToDateTime(ped[1]),
                                                                   Customizado = Convert.ToBoolean(ped[2]),
                                                                   Aclaraciones = Convert.ToString(ped[3]),
                                                                   Status = Convert.ToString(ped[4]),
                                                                   Monto_Total = Convert.ToDecimal(ped[5]),
                                                                   ID_Pago = (from pago in ds.Tables["Pago"].AsEnumerable()
                                                                              where Convert.ToInt32(ped[6]) == Convert.ToInt32(pago[0])
                                                                              select new BE_Pago
                                                                              {
                                                                                  Codigo = Convert.ToInt32(pago[0]),
                                                                                  Tipo = Convert.ToString(pago[1])
                                                                              }).FirstOrDefault(),
                                                                   ListadeBebida = (from obj in ds.Tables["Bebida-Pedido"].AsEnumerable()
                                                                                    join beb in ds.Tables["Bebida"].AsEnumerable()
                                                                                    on Convert.ToInt32(obj[1]) equals Convert.ToInt32(ped[0])
                                                                                    select new BE_Bebida
                                                                                    {

                                                                                    }).ToList(),
                                                                   ListadePlatos = (from obj in ds.Tables["Plato-Pedido"].AsEnumerable()
                                                                                    join platos in ds.Tables["Plato"].AsEnumerable()
                                                                                    on Convert.ToInt32(obj[1]) equals Convert.ToInt32(ped[0])
                                                                                    select new BE_Plato
                                                                                    {
                                                                                        Codigo = Convert.ToInt32(platos[0]),
                                                                                        Nombre = Convert.ToString(platos[1]),
                                                                                        Tipo = Convert.ToString(platos[2]),
                                                                                        Clase = Convert.ToString(platos[3]),
                                                                                        Status = Convert.ToString(platos[4]),
                                                                                        CostoUnitario = Convert.ToDecimal(platos[5]),
                                                                                        Activo = Convert.ToBoolean(platos[6]),
                                                                                        ListaIngredientes = (from obje in ds.Tables["Ingrediente-Plato"].AsEnumerable()
                                                                                                             join ing in ds.Tables["Ingrediente"].AsEnumerable()
                                                                                                             on Convert.ToInt32(obje[1]) equals Convert.ToInt32(platos[0])
                                                                                                             select new BE_Ingrediente
                                                                                                             {
                                                                                                                 Codigo = Convert.ToInt32(ing[0]),
                                                                                                                 Nombre = Convert.ToString(ing[1]),
                                                                                                                 Tipo = Convert.ToString(ing[2]),
                                                                                                                 Refrigeracion = Convert.ToBoolean(ing[3]),
                                                                                                                 Stock = Convert.ToDecimal(ing[4]),
                                                                                                                 UnidadMedida = Convert.ToString(ing[5]),
                                                                                                                 Lote = Convert.ToString(ing[6]),
                                                                                                                 Activo = Convert.ToBoolean(ing[7]),
                                                                                                                 VidaUtil = Convert.ToInt32(ing[8]),
                                                                                                                 Status = Convert.ToString(ing[9]),
                                                                                                                 CostoUnitario = Convert.ToDecimal(ing[10])

                                                                                                             }).ToList()

                                                                                    }).ToList(),



                                                               }).FirstOrDefault(),
                                              }).ToList();

            return listaReservas;
        }

        public BE_Reserva ListarObjeto(BE_Reserva reserva)
        {
            throw new NotImplementedException();
        }

        public bool Modificar(BE_Reserva reserva)
        {
            Acceso = new Xml_Database();
            return Acceso.Modificar(DicReserva, CrearReservaXML(reserva));
        }

        private HashSet<XElement> CrearReservaXML(BE_Reserva reserva)
        {
            HashSet<XElement> ListaReserva = new HashSet<XElement>();

            XElement nuevaReserva = new XElement("Reserva",
                new XElement("ID", reserva.Codigo.ToString()),
                new XElement("Fecha Inicio", reserva.FechaInicio.ToString("dd/MM/yyyy")),
                new XElement("Hora Inicio",reserva.HoraInicio.ToString("HH:mm")),
                new XElement("Hora Fin",reserva.HoraFin.ToString("HH:mm")),
                new XElement("Recurrencia", reserva.Recurrencia.ToString()),
                new XElement("Fecha Fin", reserva.FechaFin.ToString("dd/MM/yyyy")),
                new XElement("Tipo Recurrencia",reserva.TipoRecurrencia),
                new XElement("ID Cliente",reserva.ID_Cliente.Codigo.ToString()),
                new XElement("ID Pedido", reserva.ID_Pedido.Codigo.ToString())
                );
            ListaReserva.Add(nuevaReserva);
            return ListaReserva;
        }
    }
}
