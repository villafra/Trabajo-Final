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
        public List<Dash_Asistencia> Listar(DateTime inicio, DateTime fin)
        {
            List<BE_Empleado> listado = MPP_Empleado.DevolverInstancia().Listar();
            List<BE_Asistencia> asistencias = MPP_Asistencia.DevolverInstancia().Listar();

            List<Dash_Asistencia> dashs = new List<Dash_Asistencia>();

            foreach(BE_Empleado emp in listado)
            {
                Dash_Asistencia dash = new Dash_Asistencia();
                dash.Empleado = emp.ToString();
                dash.Asistencias = asistencias.Where(x=> x.Fecha >= inicio && x.Fecha <= fin).Count(x => x.Novedad.Empleado.Codigo == emp.Codigo && x.Asistencia == true);
                dashs.Add(dash);
            }
            return dashs;
        }
        
    }
}
