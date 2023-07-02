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
        Xml_Database Acceso;
        List<BE_TuplaXML> ListadoXML;

        public bool Baja(BE_Novedad Novedad)
        {
            Acceso = new Xml_Database();
            ListadoXML = new List<BE_TuplaXML>();
            ListadoXML.Add(CrearNovedadXML(Novedad));
            return Acceso.Baja(ListadoXML);
        }

        public bool Guardar(BE_Novedad Novedad)
        {
            Acceso = new Xml_Database();
            ListadoXML = new List<BE_TuplaXML>();
            ListadoXML.Add(CrearNovedadXML(Novedad));
            return Acceso.Escribir(ListadoXML);
        }

        public List<BE_Novedad> Listar()
        {
            Acceso = new Xml_Database();
            DataSet ds = new DataSet();
            ds = Acceso.Listar();

            List<BE_Novedad> listado = ds.Tables.Contains("Novedad") != false ?
                (from nov in ds.Tables["Novedad"].AsEnumerable()
                 select new BE_Novedad
                 {
                     Codigo = Convert.ToInt32(nov[0]),
                     Empleado = new MPP_Empleado().ListarObjeto(new BE_Mozo { Codigo = Convert.ToInt32(nov[1])}),
                     VacacionesDisponibles = Convert.ToInt32(nov[2]),
                     listadoAsistencia = null,
                     Activo = Convert.ToBoolean(nov[4])
                 }).ToList() : null;
            return listado;
        }

        public BE_Novedad ListarObjeto(BE_Novedad Novedad)
        {
            Acceso = new Xml_Database();
            DataSet ds = new DataSet();
            ds = Acceso.Listar();

            BE_Novedad ObjectoEncontrado = ds.Tables.Contains("Novedad") != false ?
                (from nov in ds.Tables["Novedad"].AsEnumerable()
                 where Convert.ToInt32(nov[0]) == Novedad.Codigo
                 select new BE_Novedad
                 {
                     Codigo = Convert.ToInt32(nov[0]),
                     Empleado = new MPP_Empleado().ListarObjeto(new BE_Mozo { Codigo = Convert.ToInt32(nov[1]) }),
                     VacacionesDisponibles = Convert.ToInt32(nov[2]),
                     listadoAsistencia = null,
                     Activo = Convert.ToBoolean(nov[4])

                 }).FirstOrDefault() : null;
            return ObjectoEncontrado;
        }

        public bool Modificar(BE_Novedad Novedad)
        {
            Acceso = new Xml_Database();
            ListadoXML = new List<BE_TuplaXML>();
            ListadoXML.Add(CrearNovedadXML(Novedad));
            return Acceso.Modificar(ListadoXML);
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
