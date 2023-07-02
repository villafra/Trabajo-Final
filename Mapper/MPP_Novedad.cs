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
    public class MPP_Novedad: IGestionable<BE_Novedad>
    {
        private static List<BE_TuplaXML> ListadoXML;
        private static MPP_Novedad mapper = null;
        public static MPP_Novedad DevolverInstancia()
        {
            if (mapper == null) mapper = new MPP_Novedad();
            else ListadoXML = null;
            return mapper;
        }
        ~MPP_Novedad()
        {
            mapper = null;
            ListadoXML = null;
        }
        public bool Baja(BE_Novedad Novedad)
        {
            ListadoXML = new List<BE_TuplaXML>();
            ListadoXML.Add(CrearNovedadXML(Novedad));
            return Xml_Database.DevolverInstancia().Baja(ListadoXML);
        }

        public bool Guardar(BE_Novedad Novedad)
        {
            ListadoXML = new List<BE_TuplaXML>();
            ListadoXML.Add(CrearNovedadXML(Novedad));
            return Xml_Database.DevolverInstancia().Escribir(ListadoXML);
        }

        public List<BE_Novedad> Listar()
        {
            DataSet ds = new DataSet();
            ds = Xml_Database.DevolverInstancia().Listar();

            List<BE_Novedad> listado = ds.Tables.Contains("Novedad") != false ?
                (from nov in ds.Tables["Novedad"].AsEnumerable()
                 select new BE_Novedad
                 {
                     Codigo = Convert.ToInt32(nov[0]),
                     Empleado = MPP_Empleado.DevolverInstancia().ListarObjeto(new BE_Mozo { Codigo = Convert.ToInt32(nov[1])},ds),
                     VacacionesDisponibles = Convert.ToInt32(nov[2]),
                     listadoAsistencia = null,
                     Activo = Convert.ToBoolean(nov[4])
                 }).ToList() : null;
            return listado;
        }

        public BE_Novedad ListarObjeto(BE_Novedad Novedad, DataSet ds = null)
        {
            if (ds is null)
            {
                ds = new DataSet();
                ds = Xml_Database.DevolverInstancia().Listar();
            }

            BE_Novedad ObjectoEncontrado = ds.Tables.Contains("Novedad") != false ?
                (from nov in ds.Tables["Novedad"].AsEnumerable()
                 where Convert.ToInt32(nov[0]) == Novedad.Codigo
                 select new BE_Novedad
                 {
                     Codigo = Convert.ToInt32(nov[0]),
                     Empleado = MPP_Empleado.DevolverInstancia().ListarObjeto(new BE_Mozo { Codigo = Convert.ToInt32(nov[1]) },ds),
                     VacacionesDisponibles = Convert.ToInt32(nov[2]),
                     listadoAsistencia = null,
                     Activo = Convert.ToBoolean(nov[4])

                 }).FirstOrDefault() : null;
            return ObjectoEncontrado;
        }

        public bool Modificar(BE_Novedad Novedad)
        {
            ListadoXML = new List<BE_TuplaXML>();
            ListadoXML.Add(CrearNovedadXML(Novedad));
            return Xml_Database.DevolverInstancia().Modificar(ListadoXML);
        }
        private BE_TuplaXML CrearNovedadXML(BE_Novedad Novedad)
        {
            BE_TuplaXML nuevaTupla = new BE_TuplaXML();
            nuevaTupla.NodoRoot = "Novedades";
            nuevaTupla.NodoLeaf = "Novedad";
            XElement nuevaNovedad = new XElement("Novedad",
                new XElement("ID", Novedad.Codigo.ToString()),
                new XElement("ID_Empleado", Novedad.Empleado.Codigo.ToString()),
                new XElement("Vacaciones_Disponibles", Novedad.VacacionesDisponibles.ToString()),
                new XElement("Activo", Novedad.Activo.ToString())
                );
            nuevaTupla.Xelement = nuevaNovedad;
            return nuevaTupla;
        }

    }
}
