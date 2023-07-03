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
    public class MPP_Asistencia : IGestionable<BE_Asistencia>
    {
        private static List<BE_TuplaXML> ListadoXML;
        private static MPP_Asistencia mapper = null;
        public static MPP_Asistencia DevolverInstancia()
        {
            if (mapper == null) mapper = new MPP_Asistencia();
            else ListadoXML = null;
            return mapper;
        }
        ~MPP_Asistencia()
        {
            mapper = null;
            ListadoXML = null;
        }
        public bool Baja(BE_Asistencia asistencia)
        {
            ListadoXML = new List<BE_TuplaXML>();
            ListadoXML.Add(CrearAsistenciaXML(asistencia));
            return Xml_Database.DevolverInstancia().Baja(ListadoXML);
        }

        public bool Guardar(BE_Asistencia asistencia)
        {
            ListadoXML = new List<BE_TuplaXML>();
            ListadoXML.Add(CrearAsistenciaXML(asistencia));
            return Xml_Database.DevolverInstancia().Escribir(ListadoXML);
        }
        public bool Guardar(List<BE_Asistencia> asistencias)
        {
            ListadoXML = CrearAsistenciasXML(asistencias);
            return Xml_Database.DevolverInstancia().Escribir(ListadoXML);
        }

        public List<BE_Asistencia> Listar()
        {
            DataSet ds = new DataSet();
            ds = Xml_Database.DevolverInstancia().Listar();

            List<BE_Asistencia> listado = ds.Tables.Contains("Asistencia") != false ?
                (from asi in ds.Tables["Asistencia"].AsEnumerable()
                 select new BE_Asistencia
                 {
                     Codigo = Convert.ToInt32(asi[0]),
                     Novedad = MPP_Novedad.DevolverInstancia().ListarObjeto(new BE_Novedad { Codigo = Convert.ToInt32(asi[1]) }),
                     Fecha = Convert.ToDateTime(asi[2]),
                     Asistencia = Convert.ToBoolean(asi[3]),
                     HoraIngreso = TimeSpan.Parse(asi[4].ToString()),
                     HoraEgreso = TimeSpan.Parse(asi[5].ToString()),
                     Motivo = (Inasistencia)Enum.Parse(typeof(Inasistencia), asi[6].ToString())
                 }).ToList() : null;
            return listado;
                
        }

        public BE_Asistencia ListarObjeto(BE_Asistencia asistencia, DataSet ds=null)
        {
            if (ds is null)
            {
                ds = new DataSet();
                ds = Xml_Database.DevolverInstancia().Listar();
            }
            BE_Asistencia ObjetoEncontrado = ds.Tables.Contains("Asistencia") != false ?
                (from asi in ds.Tables["Asistencia"].AsEnumerable()
                 where Convert.ToInt32(asi[0]) == asistencia.Codigo
                 select new BE_Asistencia
                 {
                     Codigo = Convert.ToInt32(asi[0]),
                     Novedad = MPP_Novedad.DevolverInstancia().ListarObjeto(new BE_Novedad { Codigo = Convert.ToInt32(asi[1]) }),
                     Fecha = Convert.ToDateTime(asi[2]),
                     Asistencia = Convert.ToBoolean(asi[3]),
                     HoraIngreso = TimeSpan.Parse(asi[4].ToString()),
                     HoraEgreso = TimeSpan.Parse(asi[5].ToString()),
                     Motivo = (Inasistencia)Enum.Parse(typeof(Inasistencia), asi[6].ToString())
                 }).FirstOrDefault() : null;
            return ObjetoEncontrado;
        }
        public List<BE_Asistencia>Asistencia_Empleado(BE_Novedad novedad, DataSet ds = null)
        {
            if (ds is null)
            {
                ds = new DataSet();
                ds = Xml_Database.DevolverInstancia().Listar();
            }

            List<BE_Asistencia> listado = ds.Tables.Contains("Asistencia") != false ?
                (from asi in ds.Tables["Asistencia"].AsEnumerable()
                 where Convert.ToInt32(asi[1]) == novedad.Codigo
                 select new BE_Asistencia
                 {
                     Codigo = Convert.ToInt32(asi[0]),
                     Novedad = MPP_Novedad.DevolverInstancia().ListarObjeto(new BE_Novedad { Codigo = Convert.ToInt32(asi[1])}),
                     Fecha = Convert.ToDateTime(asi[2]),
                     Asistencia = Convert.ToBoolean(asi[3]),
                     HoraIngreso = TimeSpan.Parse(asi[4].ToString()),
                     HoraEgreso = TimeSpan.Parse(asi[5].ToString()),
                     Motivo = (Inasistencia)Enum.Parse(typeof(Inasistencia), asi[6].ToString())
                 }).ToList() : null;
            return listado.OrderBy(x=> x.Fecha).ToList();
        }

        public bool Modificar(BE_Asistencia asistencia)
        {
            ListadoXML = new List<BE_TuplaXML>();
            ListadoXML.Add(CrearAsistenciaXML(asistencia));
            return Xml_Database.DevolverInstancia().Modificar(ListadoXML);
        }
        private BE_TuplaXML CrearAsistenciaXML(BE_Asistencia asistencia)
        {
            BE_TuplaXML nuevaTupla = new BE_TuplaXML();
            nuevaTupla.NodoRoot = "Asistencias";
            nuevaTupla.NodoLeaf = "Asistencia";
            XElement nuevaAsistencia = new XElement("Asistencia",
                new XElement("ID", Cálculos.IDPadleft(asistencia.Codigo)),
                new XElement("ID_Novedad", asistencia.Novedad.Codigo.ToString()),
                new XElement("Fecha", asistencia.Fecha.ToString("dd/MM/yyyy HH:mm:ss")),
                new XElement("Asistio", asistencia.Asistencia.ToString()),
                new XElement("Hora_Ingreso", asistencia.Asistencia ? asistencia.HoraIngreso.ToString() : TimeSpan.Zero.ToString()),
                new XElement("Hora_Egreso", asistencia.Asistencia ? asistencia.HoraEgreso.ToString() : TimeSpan.Zero.ToString()),
                new XElement("Motivo", asistencia.Motivo.ToString())
                );
            nuevaTupla.Xelement = nuevaAsistencia;
            return nuevaTupla;
        }
        private List<BE_TuplaXML> CrearAsistenciasXML(List<BE_Asistencia> asistencias)
        {
            List<BE_TuplaXML> ListadeAsistencias = new List<BE_TuplaXML>();
            foreach (BE_Asistencia asistencia in asistencias)
            {
                BE_TuplaXML nuevaTupla = new BE_TuplaXML();
                nuevaTupla.NodoRoot = "Asistencias";
                nuevaTupla.NodoLeaf = "Asistencia";
                XElement nuevaAsistencia = new XElement("Asistencia",
                new XElement("ID", Cálculos.IDPadleft(asistencia.Codigo)),
                new XElement("ID_Novedad", asistencia.Novedad.Codigo.ToString()),
                new XElement("Fecha", asistencia.Fecha.ToString("dd/MM/yyyy HH:mm:ss")),
                new XElement("Asistio", asistencia.Asistencia.ToString()),
                new XElement("Hora_Ingreso", asistencia.Asistencia ? asistencia.HoraIngreso.ToString() : TimeSpan.Zero.ToString()),
                new XElement("Hora_Egreso", asistencia.Asistencia ? asistencia.HoraEgreso.ToString() : TimeSpan.Zero.ToString()),
                new XElement("Motivo", asistencia.Motivo.ToString())
                );
                nuevaTupla.Xelement = nuevaAsistencia;
                ListadeAsistencias.Add(nuevaTupla);
            }
            return ListadeAsistencias;
        }
    }
}
