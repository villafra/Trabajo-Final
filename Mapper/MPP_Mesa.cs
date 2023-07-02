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
    public class MPP_Mesa:IGestionable<BE_Mesa>
    {
        Xml_Database Acceso;
        List<BE_TuplaXML> ListadoXML;
        public bool Baja(BE_Mesa mesa)
        {
            ListadoXML = new List<BE_TuplaXML>();
            Acceso = new Xml_Database();
            ListadoXML.Add(CrearMesaXML(mesa));
            return Acceso.Borrar(ListadoXML);
        }
        public bool Baja (List<BE_Mesa> mesas)
        {
            ListadoXML = new List<BE_TuplaXML>();
            Acceso = new Xml_Database();
            foreach(BE_Mesa mesa in mesas)
            {
                ListadoXML.Add(CrearMesaXML(mesa));
            }
            return Acceso.Borrar(ListadoXML);
        }

        public bool Guardar(BE_Mesa mesa)
        {
            ListadoXML = new List<BE_TuplaXML>();
            Acceso = new Xml_Database();
            ListadoXML.Add(CrearMesaXML(mesa));
            return Acceso.Escribir(ListadoXML);
        }

        public bool Guardar(List<BE_Mesa> mesas)
        {
            ListadoXML = new List<BE_TuplaXML>();
            Acceso = new Xml_Database();
            foreach (BE_Mesa mesa in mesas)
            {
                ListadoXML.Add(CrearMesaXML(mesa));
            }
            return Acceso.Escribir(ListadoXML);
        }

        public List<BE_Mesa> Listar()
        {
            Acceso = new Xml_Database();
            DataSet ds = new DataSet();
            ds = Acceso.Listar();

            List<BE_Mesa> listadeMesas = ds.Tables.Contains("Mesa") != false ?
                (from mes in ds.Tables["Mesa"].AsEnumerable()
                 select mes[7].ToString() != "Combinada" ? new BE_Mesa
                 {
                     Codigo = Convert.ToInt32(mes[0]),
                     Capacidad = Convert.ToInt32(mes[1]),
                     Ubicación = (Ubicacion)Enum.Parse(typeof(Ubicacion), Convert.ToString(mes[2])),
                     OcupaciónActual = Convert.ToInt32(mes[3]),
                     Status = (StatusMesa)Enum.Parse(typeof(StatusMesa), Convert.ToString(mes[4])),
                     ID_Empleado = Convert.ToString(mes[4]) == StatusMesa.Ocupada.ToString() ?
                     new MPP_Empleado().ListarObjeto(new BE_Mozo { Codigo = Convert.ToInt32(mes[5])}) : null,
                     Activo = Convert.ToBoolean(mes[6]),

                 } : new BE_MesaCombinada
                 {
                     Codigo = Convert.ToInt32(mes[0]),
                     Capacidad = Convert.ToInt32(mes[1]),
                     Ubicación = (Ubicacion)Enum.Parse(typeof(Ubicacion), Convert.ToString(mes[2])),
                     OcupaciónActual = Convert.ToInt32(mes[3]),
                     Status = (StatusMesa)Enum.Parse(typeof(StatusMesa), Convert.ToString(mes[4])),
                     ID_Empleado = Convert.ToString(mes[4]) == StatusMesa.Ocupada.ToString() ?
                     new MPP_Empleado().ListarObjeto(new BE_Mozo { Codigo = Convert.ToInt32(mes[5]) }) : null,
                     Activo = Convert.ToBoolean(mes[6]),
                     Mesa1 = ListarObjeto(new BE_Mesa { Codigo = Convert.ToInt32(mes[8]) }),
                     Mesa2 = ListarObjeto(new BE_Mesa { Codigo = Convert.ToInt32(mes[9]) }),
                 }).ToList() : null;
            return listadeMesas;
        }

        public List<BE_Mesa> ListarLibres()
        {
            Acceso = new Xml_Database();
            DataSet ds = new DataSet();
            ds = Acceso.Listar();

            List<BE_Mesa> listadeMesas = ds.Tables.Contains("Mesa") != false ?
                (from mes in ds.Tables["Mesa"].AsEnumerable()
                 where mes[4].ToString() == StatusMesa.Libre.ToString()
                 & Convert.ToBoolean(mes[6]) == true
                 select mes[7].ToString() != "Combinada" ? new BE_Mesa
                 {
                     Codigo = Convert.ToInt32(mes[0]),
                     Capacidad = Convert.ToInt32(mes[1]),
                     Ubicación = (Ubicacion)Enum.Parse(typeof(Ubicacion), Convert.ToString(mes[2])),
                     OcupaciónActual = Convert.ToInt32(mes[3]),
                     Status = (StatusMesa)Enum.Parse(typeof(StatusMesa), Convert.ToString(mes[4])),
                     Activo = Convert.ToBoolean(mes[6]),

                 } : new BE_MesaCombinada
                 {
                     Codigo = Convert.ToInt32(mes[0]),
                     Capacidad = Convert.ToInt32(mes[1]),
                     Ubicación = (Ubicacion)Enum.Parse(typeof(Ubicacion), Convert.ToString(mes[2])),
                     OcupaciónActual = Convert.ToInt32(mes[3]),
                     Status = (StatusMesa)Enum.Parse(typeof(StatusMesa), Convert.ToString(mes[4])),
                     Activo = Convert.ToBoolean(mes[6]),
                     Mesa1 = ListarObjeto(new BE_Mesa { Codigo = Convert.ToInt32(mes[8]) }),
                     Mesa2 = ListarObjeto(new BE_Mesa { Codigo = Convert.ToInt32(mes[9]) }),

                 }).ToList() : null;
            return listadeMesas;
        }

        public BE_Mesa ListarObjeto(BE_Mesa mesa)
        {
            Acceso = new Xml_Database();
            DataSet ds = new DataSet();
            ds = Acceso.Listar();

            BE_Mesa ObjetoEncontrado = ds.Tables.Contains("Mesa") != false ?
                (from mes in ds.Tables["Mesa"].AsEnumerable()
                 select mes[7].ToString() != "Combinada" ? new BE_Mesa
                 {
                     Codigo = Convert.ToInt32(mes[0]),
                     Capacidad = Convert.ToInt32(mes[1]),
                     Ubicación = (Ubicacion)Enum.Parse(typeof(Ubicacion), Convert.ToString(mes[2])),
                     OcupaciónActual = Convert.ToInt32(mes[3]),
                     Status = (StatusMesa)Enum.Parse(typeof(StatusMesa), Convert.ToString(mes[4])),
                     ID_Empleado = Convert.ToString(mes[4]) == StatusMesa.Ocupada.ToString() ?
                     new MPP_Empleado().ListarObjeto(new BE_Mozo { Codigo = Convert.ToInt32(mes[5]) }) : null,
                     Activo = Convert.ToBoolean(mes[6]),

                 } : new BE_MesaCombinada
                 {
                     Codigo = Convert.ToInt32(mes[0]),
                     Capacidad = Convert.ToInt32(mes[1]),
                     Ubicación = (Ubicacion)Enum.Parse(typeof(Ubicacion), Convert.ToString(mes[2])),
                     OcupaciónActual = Convert.ToInt32(mes[3]),
                     Status = (StatusMesa)Enum.Parse(typeof(StatusMesa), Convert.ToString(mes[4])),
                     ID_Empleado = Convert.ToString(mes[4]) == StatusMesa.Ocupada.ToString() ?
                     new MPP_Empleado().ListarObjeto(new BE_Mozo { Codigo = Convert.ToInt32(mes[5]) }) : null,
                     Activo = Convert.ToBoolean(mes[6]),
                     Mesa1 = ListarObjeto(new BE_Mesa { Codigo = Convert.ToInt32(mes[8]) }),
                     Mesa2 = ListarObjeto(new BE_Mesa { Codigo = Convert.ToInt32(mes[9]) }),
                 }).FirstOrDefault() : null;
            return ObjetoEncontrado;
        }

        public bool Modificar(BE_Mesa mesa)
        {
            ListadoXML = new List<BE_TuplaXML>();
            Acceso = new Xml_Database();
            ListadoXML.Add(CrearMesaXML(mesa));
            return Acceso.Modificar(ListadoXML);
        }

        public bool CombinarMesa(List<BE_Mesa> mesas)
        {
            ListadoXML = new List<BE_TuplaXML>();
            Acceso = new Xml_Database();
            foreach (BE_Mesa mesa in mesas)
            {
               ListadoXML.Add(CrearMesaXML(mesa));
            }
            return Acceso.Modificar(ListadoXML);
        }

        private BE_TuplaXML CrearMesaXML(BE_Mesa mesa)
        {
            BE_TuplaXML nuevaTupla = new BE_TuplaXML();
            nuevaTupla.NodoRoot = "Mesas";
            nuevaTupla.NodoLeaf = "Mesa";
            XElement nuevaMesa = new XElement("Mesa",
                new XElement("ID", Cálculos.IDPadleft(mesa.Codigo)),
                new XElement("Capacidad", mesa.Capacidad.ToString()),
                new XElement("Ubicación", mesa.Ubicación),
                new XElement("Ocupación_Actual", mesa.OcupaciónActual.ToString()),
                new XElement("Status", mesa.Status.ToString()),
                new XElement("ID_Mozo", mesa.ID_Empleado != null ? mesa.ID_Empleado.Codigo.ToString() : ""),
                new XElement("Activo", mesa.Activo.ToString()),
                new XElement("Tipo_Mesa", mesa is BE_MesaCombinada ? "Combinada" :""),
                new XElement("Mesa_1", mesa is BE_MesaCombinada ? ((BE_MesaCombinada)mesa).Mesa1.Codigo.ToString() : ""),
                new XElement("Mesa_2", mesa is BE_MesaCombinada ? ((BE_MesaCombinada)mesa).Mesa2.Codigo.ToString() : "")
                );
            nuevaTupla.Xelement = nuevaMesa;
            return nuevaTupla;
        }
    }
}
