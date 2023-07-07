using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_Logic_Layer;
using Business_Entities;
using Mapper;

namespace Business_Logic_Layer
{
    public class BLL_Dash_Asistencia
    {
        public List<BE_Empleado> RecolectarDatosEmpleado()
        {
            List<BE_Empleado> listado = MPP_Empleado.DevolverInstancia().Listar();
            return listado;
        }
        public List<BE_Asistencia> RecolectarDatosAsistencia()
        {
            List<BE_Asistencia> asistencias = MPP_Asistencia.DevolverInstancia().Listar();
            return asistencias;
        }
        public List<Dash_Asistencia> Listar(List<BE_Asistencia>asistencias, List<BE_Empleado>empleados, DateTime inicio, DateTime fin)
        {
            List<Dash_Asistencia> DashMotivos = new List<Dash_Asistencia>();

            foreach(BE_Empleado emp in empleados)
            {
                Dash_Asistencia dash = new Dash_Asistencia();
                dash.Empleado = emp.ToString();
                dash.Asistencias = asistencias.Where(x=> x.Fecha >= inicio && x.Fecha <= fin).Count(x => x.Novedad.Empleado.Codigo == emp.Codigo && x.Asistencia == true);
                DashMotivos.Add(dash);
            }
            return DashMotivos;
        }
        public Dash_Asistencia MayorAsistencia(List<Dash_Asistencia> lista)
        {
            Dash_Asistencia MasAsistencia = lista.OrderByDescending(x => x.Asistencias).FirstOrDefault();
            return MasAsistencia;
        }
        public Dash_Asistencia MayorInAsistencia(List<Dash_Asistencia> lista)
        {
            Dash_Asistencia MasAsistencia = lista.OrderBy(x => x.Asistencias).FirstOrDefault();
            return MasAsistencia;
        }
    }
}
