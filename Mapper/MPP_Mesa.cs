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
        private static List<BE_TuplaXML> ListadoXML;
        private static MPP_Mesa mapper = null;
        public static MPP_Mesa DevolverInstancia()
        {
            if (mapper == null) mapper = new MPP_Mesa();
            else ListadoXML = null;
            return mapper;
        }
        ~MPP_Mesa()
        {
            mapper = null;
            ListadoXML = null;
        }
        public bool Baja(BE_Mesa mesa)
        {
            ListadoXML = new List<BE_TuplaXML>();
            ListadoXML.Add(CrearMesaXML(mesa));
            return Xml_Database.DevolverInstancia().Borrar(ListadoXML);
        }
        public bool Baja (List<BE_Mesa> mesas)
        {
            ListadoXML = new List<BE_TuplaXML>();
            foreach(BE_Mesa mesa in mesas)
            {
                ListadoXML.Add(CrearMesaXML(mesa));
            }
            return Xml_Database.DevolverInstancia().Borrar(ListadoXML);
        }

        public bool Guardar(BE_Mesa mesa)
        {
            ListadoXML = new List<BE_TuplaXML>();
            ListadoXML.Add(CrearMesaXML(mesa));
            return Xml_Database.DevolverInstancia().Escribir(ListadoXML);
        }

        public bool Guardar(List<BE_Mesa> mesas)
        {
            ListadoXML = new List<BE_TuplaXML>();
            foreach (BE_Mesa mesa in mesas)
            {
                ListadoXML.Add(CrearMesaXML(mesa));
            }
            return Xml_Database.DevolverInstancia().Escribir(ListadoXML);
        }

        public List<BE_Mesa> Listar()
        {
            DataSet ds = new DataSet();
            ds = Xml_Database.DevolverInstancia().Listar();

            List<BE_Mesa> listadeMesas = ds.Tables.Contains("Mesa") != false ?
                (from mes in ds.Tables["Mesa"].AsEnumerable()
                 select mes[7].ToString() != "Combinada" ? new BE_Mesa
                 {
                     Codigo = Convert.ToInt32(mes[0]),
                     Capacidad = Convert.ToInt32(mes[1]),
                     Ubicación = (Ubicacion)Enum.Parse(typeof(Ubicacion), Convert.ToString(mes[2])),
                     OcupaciónActual = Convert.ToInt32(mes[3]),
                     Status = (StatusMesa)Enum.Parse(typeof(StatusMesa), Convert.ToString(mes[4])),
                     ID_Empleado = mes[5].ToString() != "" ?
                     MPP_Empleado.DevolverInstancia().ListarObjeto(new BE_Mozo { Codigo = Convert.ToInt32(mes[5])},ds) : null,
                     Activo = Convert.ToBoolean(mes[6]),

                 } : new BE_MesaCombinada
                 {
                     Codigo = Convert.ToInt32(mes[0]),
                     Capacidad = Convert.ToInt32(mes[1]),
                     Ubicación = (Ubicacion)Enum.Parse(typeof(Ubicacion), Convert.ToString(mes[2])),
                     OcupaciónActual = Convert.ToInt32(mes[3]),
                     Status = (StatusMesa)Enum.Parse(typeof(StatusMesa), Convert.ToString(mes[4])),
                     ID_Empleado = mes[5].ToString() != "" ?
                     MPP_Empleado.DevolverInstancia().ListarObjeto(new BE_Mozo { Codigo = Convert.ToInt32(mes[5]) },ds) : null,
                     Activo = Convert.ToBoolean(mes[6]),
                     Mesa1 = ListarObjeto(new BE_Mesa { Codigo = Convert.ToInt32(mes[8]) },ds),
                     Mesa2 = ListarObjeto(new BE_Mesa { Codigo = Convert.ToInt32(mes[9]) },ds),
                 }).ToList() : null;
            return listadeMesas;
        }

        public List<BE_Mesa> ListarLibres()
        {
            DataSet ds = new DataSet();
            ds = Xml_Database.DevolverInstancia().Listar();

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
                     Mesa1 = ListarObjeto(new BE_Mesa { Codigo = Convert.ToInt32(mes[8]) },ds),
                     Mesa2 = ListarObjeto(new BE_Mesa { Codigo = Convert.ToInt32(mes[9]) },ds),

                 }).ToList() : null;
            return listadeMesas;
        }

        public BE_Mesa ListarObjeto(BE_Mesa mesa, DataSet ds=null)
        {
            BE_Mesa ObjetoEncontrado = ds.Tables.Contains("Mesa") != false ?
                (from mes in ds.Tables["Mesa"].AsEnumerable()
                 where Convert.ToInt32(mes[0]) == mesa.Codigo
                 select mes[7].ToString() != "Combinada" ? new BE_Mesa
                 {
                     Codigo = Convert.ToInt32(mes[0]),
                     Capacidad = Convert.ToInt32(mes[1]),
                     Ubicación = (Ubicacion)Enum.Parse(typeof(Ubicacion), Convert.ToString(mes[2])),
                     OcupaciónActual = Convert.ToInt32(mes[3]),
                     Status = (StatusMesa)Enum.Parse(typeof(StatusMesa), Convert.ToString(mes[4])),
                     ID_Empleado = mes[5].ToString() != "" ?
                     MPP_Empleado.DevolverInstancia().ListarObjeto(new BE_Mozo { Codigo = Convert.ToInt32(mes[5]) },ds) : null,
                     Activo = Convert.ToBoolean(mes[6]),

                 } : new BE_MesaCombinada
                 {
                     Codigo = Convert.ToInt32(mes[0]),
                     Capacidad = Convert.ToInt32(mes[1]),
                     Ubicación = (Ubicacion)Enum.Parse(typeof(Ubicacion), Convert.ToString(mes[2])),
                     OcupaciónActual = Convert.ToInt32(mes[3]),
                     Status = (StatusMesa)Enum.Parse(typeof(StatusMesa), Convert.ToString(mes[4])),
                     ID_Empleado = mes[5].ToString() != "" ?
                     MPP_Empleado.DevolverInstancia().ListarObjeto(new BE_Mozo { Codigo = Convert.ToInt32(mes[5]) },ds) : null,
                     Activo = Convert.ToBoolean(mes[6]),
                     Mesa1 = ListarObjeto(new BE_Mesa { Codigo = Convert.ToInt32(mes[8]) },ds),
                     Mesa2 = ListarObjeto(new BE_Mesa { Codigo = Convert.ToInt32(mes[9]) },ds),
                 }).FirstOrDefault() : null;
            return ObjetoEncontrado;
        }

        public bool Modificar(BE_Mesa mesa)
        {
            ListadoXML = new List<BE_TuplaXML>();
            ListadoXML.Add(CrearMesaXML(mesa));
            return Xml_Database.DevolverInstancia().Modificar(ListadoXML);
        }

        public bool CombinarMesa(List<BE_Mesa> mesas)
        {
            ListadoXML = new List<BE_TuplaXML>();
            foreach (BE_Mesa mesa in mesas)
            {
               ListadoXML.Add(CrearMesaXML(mesa));
            }
            return Xml_Database.DevolverInstancia().Modificar(ListadoXML);
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
