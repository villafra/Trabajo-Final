using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_Entities;
using Abstraction_Layer;
using Data_Access_Layer;
using System.Data;
using System.Xml.Linq;
using Automate_Layer;

namespace Mapper
{
    public class MPP_Cliente:IGestionable<BE_Cliente>
    {
        Xml_Database Acceso;
        List<BE_TuplaXML> ListadoXML;

        public MPP_Cliente()
        {
            ListadoXML = new List<BE_TuplaXML>();
        }

        public bool Baja(BE_Cliente cliente)
        {
            Acceso = new Xml_Database();
            ListadoXML.Add(CrearClienteXML(cliente));
            return Acceso.Borrar(ListadoXML);
        }

        public bool Guardar(BE_Cliente cliente)
        {
            Acceso = new Xml_Database();
            ListadoXML.Add(CrearClienteXML(cliente));
            foreach(BE_TuplaXML tupla in CrearListaBebidasXML(cliente))
            {
                ListadoXML.Add(tupla);
            }
            foreach (BE_TuplaXML tupla in CrearListaPlatosXML(cliente))
            {
                ListadoXML.Add(tupla);
            }
            foreach (BE_TuplaXML tupla in CrearListadeReservas(cliente))
            {
                ListadoXML.Add(tupla);
            }

            return Acceso.Escribir(ListadoXML);
                
        }

        public List<BE_Cliente> Listar()
        {
            Acceso = new Xml_Database();
            DataSet ds = new DataSet();
            ds = Acceso.Listar();
            MPP_Ingrediente oMPP_Ingrediente = new MPP_Ingrediente();

            List<BE_Cliente> listaClientes = ds.Tables.Contains("Cliente")!= false ? (from cli in ds.Tables["Cliente"].AsEnumerable()
                                            select new BE_Cliente
                                            {
                                                Codigo = Convert.ToInt32(cli[0]),
                                                DNI = Convert.ToInt64(cli[1]),
                                                Nombre = Convert.ToString(cli[2]),
                                                Apellido = Convert.ToString(cli[3]),
                                                FechaNacimiento = Convert.ToDateTime(cli[4]),
                                                Telefono = Convert.ToString(cli[5]),
                                                Mail = Convert.ToString(cli[6]),
                                                ListadeBebidas = ds.Tables.Contains("Bebida-Cliente") & ds.Tables.Contains("Bebida") != false ?(from obj in ds.Tables["Bebida-Cliente"].AsEnumerable()
                                                                  join beb in ds.Tables["Bebida"].AsEnumerable()
                                                                  on Convert.ToInt32(obj[1]) equals Convert.ToInt32(cli[0])
                                                                  select new BE_Bebida
                                                                  {

                                                                  }).ToList():null,
                                                ListadePlatos = ds.Tables.Contains("Plato-Cliente") & ds.Tables.Contains("Plato") != false ?(from obj in ds.Tables["Plato-Cliente"].AsEnumerable()
                                                                 join platos in ds.Tables["Plato"].AsEnumerable()
                                                                 on Convert.ToInt32(obj[1]) equals Convert.ToInt32(cli[0])
                                                                 select new BE_Plato
                                                                 {
                                                                     Codigo = Convert.ToInt32(platos[0]),
                                                                     Nombre = Convert.ToString(platos[1]),
                                                                     Tipo = (BE_Plato.Tipo_Plato)Enum.Parse(typeof(BE_Plato.Tipo_Plato), Convert.ToString(platos[2])),
                                                                     Clase = (BE_Plato.Clasificación)Enum.Parse(typeof(BE_Plato.Clasificación), Convert.ToString(platos[3])),
                                                                     Status = Convert.ToString(platos[4]),
                                                                     CostoUnitario = Convert.ToDecimal(platos[5]),
                                                                     Activo = Convert.ToBoolean(platos[6]),
                                                                     ListaIngredientes = ds.Tables.Contains("Ingrediente-Plato") & ds.Tables.Contains("Ingrediente") != false ? (from obje in ds.Tables["Ingrediente-Plato"].AsEnumerable()
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
                                                                                                                                                                                     Status = (StatusIng)Enum.Parse(typeof(StatusIng), Convert.ToString(ing[8])),
                                                                                                                                                                                     CostoUnitario = Convert.ToDecimal(ing[7])

                                                                                                                                                                                 }).ToList() : null

                                                                 }).ToList():null,
                                                ListaReservas = ds.Tables.Contains("Reserva-Cliente") != false ? (from obj in ds.Tables["Reserva-Cliente"].AsEnumerable()
                                                                 join res in ds.Tables["Reserva"].AsEnumerable()
                                                                 on Convert.ToInt32(obj[1]) equals Convert.ToInt32(res[0])
                                                                 select new BE_Reserva
                                                                 {
                                                                     Codigo = Convert.ToInt32(res[0]),
                                                                     FechaInicio = Convert.ToDateTime(res[1]),
                                                                     HoraInicio = Convert.ToDateTime(res[2]),
                                                                     HoraFin = Convert.ToDateTime(res[3]),
                                                                     Recurrencia = Convert.ToBoolean(res[4]),
                                                                     FechaFin = Convert.ToDateTime(res[5]),
                                                                     TipoRecurrencia = Convert.ToString(res[6]),
                                                                 }).ToList():null


                                            }).ToList():null;
            return listaClientes;

        }

        public BE_Cliente ListarObjeto(BE_Cliente cliente)
        {
            throw new NotImplementedException();
        }

        private BE_TuplaXML CrearClienteXML(BE_Cliente cliente)
        {
            BE_TuplaXML nuevaTupla = new BE_TuplaXML();
            nuevaTupla.NodoRoot = "Clientes";
            nuevaTupla.NodoLeaf = "Cliente";
            XElement nuevoCliente = new XElement("Cliente",
                new XElement("ID", Cálculos.IDPadleft(cliente.Codigo)),
                new XElement("DNI",cliente.DNI.ToString()),
                new XElement("Nombre",cliente.Nombre),
                new XElement("Apellido",cliente.Apellido),
                new XElement("FechaNacimiento",cliente.FechaNacimiento.ToString()),
                new XElement("Teléfono",cliente.Telefono),
                new XElement("Mail",cliente.Mail)
                );
            nuevaTupla.Xelement= nuevoCliente;
            return nuevaTupla;
        }

        private List<BE_TuplaXML> CrearListaBebidasXML(BE_Cliente cliente)
        {
            List<BE_TuplaXML> ListadeBebidas = new List<BE_TuplaXML>();
            
            foreach (BE_Bebida bebidas in cliente.ListadeBebidas)
            {
                BE_TuplaXML nuevaTupla = new BE_TuplaXML();
                nuevaTupla.NodoRoot = "Bebidas-Clientes";
                nuevaTupla.NodoLeaf = "Bebida-Cliente";
                XElement nuevaBebidaCliente = new XElement("Bebida-Cliente",
                    new XElement("ID Bebida", Cálculos.IDPadleft(bebidas.Codigo)),
                    new XElement("ID Cliente", Cálculos.IDPadleft(cliente.Codigo))
                    );
                nuevaTupla.Xelement =  nuevaBebidaCliente;
                ListadeBebidas.Add(nuevaTupla);
            }
            return ListadeBebidas;
        }

        private List<BE_TuplaXML> CrearListaPlatosXML(BE_Cliente cliente)
        {
            List<BE_TuplaXML> listadePlatos = new List<BE_TuplaXML>();

            foreach (BE_Plato platos in cliente.ListadePlatos)
            {
                BE_TuplaXML nuevaTupla = new BE_TuplaXML();
                nuevaTupla.NodoRoot = "Platos-Clientes";
                nuevaTupla.NodoLeaf = "Plato-Cliente";
                XElement nuevoPlatoCliente = new XElement("Plato-Cliente",
                    new XElement("ID Plato", Cálculos.IDPadleft(platos.Codigo)),
                    new XElement("ID Cliente", Cálculos.IDPadleft(cliente.Codigo))
                    );
                nuevaTupla.Xelement = nuevoPlatoCliente;
                listadePlatos.Add(nuevaTupla);
            }
            return listadePlatos;
        }

        private List<BE_TuplaXML> CrearListadeReservas(BE_Cliente cliente)
        {
            List<BE_TuplaXML> listadeReservas = new List<BE_TuplaXML>();

            foreach(BE_Reserva reservas in cliente.ListaReservas)
            {
                BE_TuplaXML nuevaTupla = new BE_TuplaXML();
                nuevaTupla.NodoRoot = ReferenciasBD.Root;
                nuevaTupla.NodoLeaf = "Reservas-Clientes";
                XElement nuevaReserva = new XElement("Reserva-Cliente",
                    new XElement("ID Reserva", Cálculos.IDPadleft(reservas.Codigo)),
                    new XElement("ID Cliente", Cálculos.IDPadleft(cliente.Codigo))
                    );
                nuevaTupla.Xelement = nuevaReserva;
                listadeReservas.Add(nuevaTupla);
            }
            return listadeReservas;
        }

        public bool Modificar(BE_Cliente cliente)
        {
            Acceso = new Xml_Database();
            ListadoXML.Add(CrearClienteXML(cliente));
            return Acceso.Modificar(ListadoXML);
        }

    }
}
