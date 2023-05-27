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

        public bool Baja(BE_Cliente cliente)
        {
            Acceso = new Xml_Database();
            return Acceso.Borrar("Clientes", "Cliente", CrearClienteXML(cliente));
        }

        public bool Guardar(BE_Cliente cliente)
        {
            Acceso = new Xml_Database();
            return Acceso.Escribir("Clientes", CrearClienteXML(cliente));
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
                                                

                                            }).ToList();
            return listaClientes;

        }

        public BE_Cliente ListarObjeto(BE_Cliente cliente)
        {
            throw new NotImplementedException();
        }

        private XElement CrearClienteXML(BE_Cliente cliente)
        {
            XElement nuevoCliente = new XElement("Cliente",
                new XElement("ID", cliente.Codigo.ToString()),
                new XElement("DNI",cliente.DNI.ToString()),
                new XElement("Nombre",cliente.Nombre),
                new XElement("Apellido",cliente.Apellido),
                new XElement("FechaNacimiento",cliente.FechaNacimiento.ToString()),
                new XElement("Teléfono",cliente.Telefono),
                new XElement("Mail",cliente.Mail)
                );
            return nuevoCliente;
        }
    }
}
