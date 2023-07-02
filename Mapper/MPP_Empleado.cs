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
    public class MPP_Empleado:IGestionable<BE_Empleado>
    {
        private static List<BE_TuplaXML> ListadoXML;
        private static MPP_Empleado mapper = null;
        public static MPP_Empleado DevolverInstancia()
        {
            if (mapper == null) mapper = new MPP_Empleado();
            else
                ListadoXML = null;
            return mapper;
        }
        ~MPP_Empleado()
        {
            mapper = null;
            ListadoXML = null;
        }
        public bool Baja(BE_Empleado empleado)
        {
            ListadoXML = new List<BE_TuplaXML>();
            ListadoXML.Add(CrearEmpleadoXML(empleado));
            return Xml_Database.DevolverInstancia().Baja(ListadoXML);
        }

        public bool Guardar(BE_Empleado empleado)
        {
            ListadoXML = new List<BE_TuplaXML>();
            ListadoXML.Add(CrearEmpleadoXML(empleado));
            return Xml_Database.DevolverInstancia().Escribir(ListadoXML);
        }

        public List<BE_Empleado> Listar()
        {
            DataSet ds = new DataSet();
            ds = Xml_Database.DevolverInstancia().Listar();
            List<BE_Empleado> ListaTotal = new List<BE_Empleado>();
            try
            {
                ListaTotal = ds.Tables.Contains("Empleado") != false ? (from emp in ds.Tables["Empleado"].AsEnumerable()
                                                                        select (int)(Category)Enum.Parse(typeof(Category), emp[6].ToString()) == 1 ?
                                                                        new BE_GerenteSucursal
                                                                        {
                                                                            Codigo = Convert.ToInt32(emp[0]),
                                                                            DNI = Convert.ToInt64(emp[1]),
                                                                            Nombre = Convert.ToString(emp[2]),
                                                                            Apellido = Convert.ToString(emp[3]),
                                                                            FechaNacimiento = Convert.ToDateTime(emp[4]),
                                                                            FechaIngreso = Convert.ToDateTime(emp[5]),
                                                                            Categoria = (Category)Enum.Parse(typeof(Category), Convert.ToString(emp[6])),
                                                                            Activo = Convert.ToBoolean(emp[7]),
                                                                            Contacto = Convert.ToString(emp[8])
                                                                        } : (int)(Category)Enum.Parse(typeof(Category), emp[6].ToString()) > 1 & (int)(Category)Enum.Parse(typeof(Category), emp[6].ToString()) < 6 ?
                                                                        (BE_Empleado)new BE_ChefPrincipal
                                                                        {
                                                                            Codigo = Convert.ToInt32(emp[0]),
                                                                            DNI = Convert.ToInt64(emp[1]),
                                                                            Nombre = Convert.ToString(emp[2]),
                                                                            Apellido = Convert.ToString(emp[3]),
                                                                            FechaNacimiento = Convert.ToDateTime(emp[4]),
                                                                            FechaIngreso = Convert.ToDateTime(emp[5]),
                                                                            Categoria = (Category)Enum.Parse(typeof(Category), Convert.ToString(emp[6])),
                                                                            Activo = Convert.ToBoolean(emp[7]),
                                                                            OrdenesPendientes = null
                                                                        } : new BE_Mozo
                                                                        {
                                                                            Codigo = Convert.ToInt32(emp[0]),
                                                                            DNI = Convert.ToInt64(emp[1]),
                                                                            Nombre = Convert.ToString(emp[2]),
                                                                            Apellido = Convert.ToString(emp[3]),
                                                                            FechaNacimiento = Convert.ToDateTime(emp[4]),
                                                                            FechaIngreso = Convert.ToDateTime(emp[5]),
                                                                            Categoria = (Category)Enum.Parse(typeof(Category), Convert.ToString(emp[6])),
                                                                            Activo = Convert.ToBoolean(emp[7]),
                                                                            PedidosTomados = null
                                                                        }
                                                                      ).ToList() : null;


                return ListaTotal.OrderBy(x => x.Codigo).ToList();
            }
            catch(Exception ex)
            {
                ListaTotal = null;
                return ListaTotal;
                throw ex;
            }
            
        }

        public List<BE_Mozo> ListarMozos()
        {
            DataSet ds = new DataSet();
            ds = Xml_Database.DevolverInstancia().Listar();

            List<BE_Mozo> listadeMozos = ds.Tables.Contains("Empleado") != false ?
                (from emp in ds.Tables["Empleado"].AsEnumerable()
                 where (int)(Category)Enum.Parse(typeof(Category), emp[6].ToString()) > 6
                 select new BE_Mozo
                 {
                     Codigo = Convert.ToInt32(emp[0]),
                     DNI = Convert.ToInt64(emp[1]),
                     Nombre = Convert.ToString(emp[2]),
                     Apellido = Convert.ToString(emp[3]),
                     FechaNacimiento = Convert.ToDateTime(emp[4]),
                     FechaIngreso = Convert.ToDateTime(emp[5]),
                     Categoria = (Category)Enum.Parse(typeof(Category), Convert.ToString(emp[6])),
                     Activo = Convert.ToBoolean(emp[7]),
                     PedidosTomados = null

                 }).ToList() : null;
            return listadeMozos;
        }
        public List<BE_GerenteSucursal> ListarGerentes()
        {
            DataSet ds = new DataSet();
            ds = Xml_Database.DevolverInstancia().Listar();

            List<BE_GerenteSucursal> listadeGerentes = ds.Tables.Contains("Empleado") != false ?
                (from emp in ds.Tables["Empleado"].AsEnumerable()
                 where (int)(Category)Enum.Parse(typeof(Category), emp[6].ToString()) == 1
                 select new BE_GerenteSucursal
                 {
                     Codigo = Convert.ToInt32(emp[0]),
                     DNI = Convert.ToInt64(emp[1]),
                     Nombre = Convert.ToString(emp[2]),
                     Apellido = Convert.ToString(emp[3]),
                     FechaNacimiento = Convert.ToDateTime(emp[4]),
                     FechaIngreso = Convert.ToDateTime(emp[5]),
                     Categoria = (Category)Enum.Parse(typeof(Category), Convert.ToString(emp[6])),
                     Activo = Convert.ToBoolean(emp[7]),
                     Contacto = Convert.ToString(emp[8])

                 }).ToList() : null;
            return listadeGerentes;
        }

        public List<BE_ChefPrincipal> ListarChefs()
        {
            DataSet ds = new DataSet();
            ds = Xml_Database.DevolverInstancia().Listar();

            List<BE_ChefPrincipal> listadeChef = ds.Tables.Contains("Empleado") != false ?
                (from emp in ds.Tables["Empleado"].AsEnumerable()
                 where (int)(Category)Enum.Parse(typeof(Category), emp[6].ToString()) > 1 &
                 (int)(Category)Enum.Parse(typeof(Category), emp[6].ToString()) < 6
                 select new BE_ChefPrincipal
                 {
                     Codigo = Convert.ToInt32(emp[0]),
                     DNI = Convert.ToInt64(emp[1]),
                     Nombre = Convert.ToString(emp[2]),
                     Apellido = Convert.ToString(emp[3]),
                     FechaNacimiento = Convert.ToDateTime(emp[4]),
                     FechaIngreso = Convert.ToDateTime(emp[5]),
                     Categoria = (Category)Enum.Parse(typeof(Category), Convert.ToString(emp[6])),
                     Activo = Convert.ToBoolean(emp[7]),
                     OrdenesPendientes = null

                 }).ToList() : null;
            return listadeChef;
        }
        public BE_Empleado ListarObjeto(BE_Empleado empleado, DataSet ds=null)
        {
            if (ds is null)
            {
                ds = new DataSet();
                ds = Xml_Database.DevolverInstancia().Listar();
            }
            var Empleado = ds.Tables.Contains("Empleado") != false ?
                (from emp in ds.Tables["Empleado"].AsEnumerable()
                 where Convert.ToInt32(emp[0]) == empleado.Codigo
                 select (int)(Category)Enum.Parse(typeof(Category), emp[6].ToString()) == 1 ?
                 new BE_GerenteSucursal
                 {
                     Codigo = Convert.ToInt32(emp[0]),
                     DNI = Convert.ToInt64(emp[1]),
                     Nombre = Convert.ToString(emp[2]),
                     Apellido = Convert.ToString(emp[3]),
                     FechaNacimiento = Convert.ToDateTime(emp[4]),
                     FechaIngreso = Convert.ToDateTime(emp[5]),
                     Categoria = (Category)Enum.Parse(typeof(Category), Convert.ToString(emp[6])),
                     Activo = Convert.ToBoolean(emp[7]),
                     Contacto = Convert.ToString(emp[8])
                 } : (int)(Category)Enum.Parse(typeof(Category), emp[6].ToString()) > 1 & (int)(Category)Enum.Parse(typeof(Category), emp[6].ToString()) < 6 ?
                 (BE_Empleado)new BE_ChefPrincipal
                 {
                     Codigo = Convert.ToInt32(emp[0]),
                     DNI = Convert.ToInt64(emp[1]),
                     Nombre = Convert.ToString(emp[2]),
                     Apellido = Convert.ToString(emp[3]),
                     FechaNacimiento = Convert.ToDateTime(emp[4]),
                     FechaIngreso = Convert.ToDateTime(emp[5]),
                     Categoria = (Category)Enum.Parse(typeof(Category), Convert.ToString(emp[6])),
                     Activo = Convert.ToBoolean(emp[7]),
                     OrdenesPendientes = null
                 } : new BE_Mozo
                 {
                     Codigo = Convert.ToInt32(emp[0]),
                     DNI = Convert.ToInt64(emp[1]),
                     Nombre = Convert.ToString(emp[2]),
                     Apellido = Convert.ToString(emp[3]),
                     FechaNacimiento = Convert.ToDateTime(emp[4]),
                     FechaIngreso = Convert.ToDateTime(emp[5]),
                     Categoria = (Category)Enum.Parse(typeof(Category), Convert.ToString(emp[6])),
                     Activo = Convert.ToBoolean(emp[7]),
                     PedidosTomados = null
                 }).FirstOrDefault() : null;
            return Empleado;
                                                                  
                                                                      
        }

        public bool Modificar(BE_Empleado empleado)
        {
            ListadoXML = new List<BE_TuplaXML>();
            ListadoXML.Add(CrearEmpleadoXML(empleado));
            return Xml_Database.DevolverInstancia().Modificar(ListadoXML);
        }

        private BE_TuplaXML CrearEmpleadoXML(BE_Empleado empleado)
        {
            BE_TuplaXML nuevaTupla = new BE_TuplaXML();
            XElement nuevoEmpleado;
            nuevaTupla.NodoRoot = "Empleados";
            nuevaTupla.NodoLeaf = "Empleado";
            if (empleado.DevolverNombre() == "Mozo" || empleado.DevolverNombre() == "ChefPrincipal")
            {       
                nuevoEmpleado = new XElement("Empleado",
                    new XElement("ID", Cálculos.IDPadleft(empleado.Codigo)),
                    new XElement("DNI", empleado.DNI.ToString()),
                    new XElement("Nombre", empleado.Nombre),
                    new XElement("Apellido", empleado.Apellido),
                    new XElement("Fecha_Nacimiento", empleado.FechaNacimiento.ToString("dd/MM/yyyy")),
                    new XElement("Fecha_Ingreso", empleado.FechaIngreso.ToString("dd/MM/yyyy")),
                    new XElement("Categoria", empleado.Categoria),
                    new XElement("Activo", empleado.Activo.ToString())
                    );
                nuevaTupla.Xelement = nuevoEmpleado;
            }
            else
            {
                nuevoEmpleado = new XElement("Empleado",
                   new XElement("ID", Cálculos.IDPadleft(empleado.Codigo)),
                   new XElement("DNI", empleado.DNI.ToString()),
                   new XElement("Nombre", empleado.Nombre),
                   new XElement("Apellido", empleado.Apellido),
                   new XElement("Fecha_Nacimiento", empleado.FechaNacimiento.ToString("dd/MM/yyyy")),
                   new XElement("Fecha_Ingreso", empleado.FechaIngreso.ToString("dd/MM/yyyy")),
                   new XElement("Categoria", empleado.Categoria.ToString()),
                   new XElement("Activo", empleado.Activo.ToString()),
                   new XElement("Contacto", ((BE_GerenteSucursal)empleado).Contacto)
                   );
                nuevaTupla.Xelement = nuevoEmpleado;
            }
            return nuevaTupla;    
        }

        private List<BE_TuplaXML> CrearMozoPedidosXML(BE_Mozo mozo)
        {
            List<BE_TuplaXML> listadePedidos = new List<BE_TuplaXML>();
            foreach(BE_Pedido pedido in mozo.PedidosTomados)
            {
                BE_TuplaXML nuevaTupla = new BE_TuplaXML();
                nuevaTupla.NodoRoot = ReferenciasBD.Root;
                nuevaTupla.NodoLeaf = "Mozo-Pedidos";
                XElement nuevoMozoPedido = new XElement("Mozo-Pedido",
                    new XElement("ID_Pedido", Cálculos.IDPadleft(pedido.Codigo)),
                    new XElement("ID_Mozo", Cálculos.IDPadleft(mozo.Codigo))
                    );
                nuevaTupla.Xelement = nuevoMozoPedido;
                listadePedidos.Add(nuevaTupla);
            }
            return listadePedidos;
        }

        private List<BE_TuplaXML> CrearOrdenesPendientesXML(BE_ChefPrincipal chef)
        {
            List<BE_TuplaXML> listadeOrdenes = new List<BE_TuplaXML>();
            foreach(BE_Orden orden in chef.OrdenesPendientes)
            {
                BE_TuplaXML nuevaTupla = new BE_TuplaXML();
                nuevaTupla.NodoRoot = ReferenciasBD.Root;
                nuevaTupla.NodoLeaf = "Ordenes_Pendientes";
                XElement nuevaOrdenPendiente = new XElement("Orden_Pendiente",
                    new XElement("ID_Orden",Cálculos.IDPadleft(orden.Codigo)),
                    new XElement("ID_Chef", Cálculos.IDPadleft(chef.Codigo))
                    );
                nuevaTupla.Xelement = nuevaOrdenPendiente;
                listadeOrdenes.Add(nuevaTupla);
            }
            return listadeOrdenes;
        }
    }
}
    