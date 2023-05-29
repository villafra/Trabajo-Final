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

            List<BE_Cliente> listaClientes = (from cli in ds.Tables["Cliente"].AsEnumerable()
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
                                                                 join res in ds.Tables["Reserva"].AsEnumerable()
                                                                 on Convert.ToInt32(obj[1]) equals Convert.ToInt32(res[0])
                                                                 select new BE_Reserva
                                                                 {



                                                                 }).ToList()


                                            }).ToList();
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
                new XElement("ID", cliente.Codigo.ToString()),
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
                    new XElement("ID Bebida", bebidas.Codigo.ToString()),
                    new XElement("ID Cliente", cliente.Codigo.ToString())
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
                    new XElement("ID Plato", platos.Codigo.ToString()),
                    new XElement("ID Cliente", cliente.Codigo.ToString())
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
                nuevaTupla.NodoRoot = "Reservas-Clientes";
                nuevaTupla.NodoLeaf = "Reserva-Cliente";
                XElement nuevaReserva = new XElement("Reserva-Cliente",
                    new XElement("ID Reserva", reservas.Codigo.ToString()),
                    new XElement("ID Cliente", cliente.Codigo.ToString())
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
