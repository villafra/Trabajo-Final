using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_Entities;
using Mapper;

namespace Business_Logic_Layer
{
    public class BLL_Dash_Motivos
    {
        public List<BE_Asistencia> RecolectarDatosAsistencia()
        {
            List<BE_Asistencia> lista = MPP_Asistencia.DevolverInstancia().Listar();
            return lista;

        }
        public List<Inasistencia> RecolectarDatosMotivos()
        {
            List<Inasistencia> MotivosInasistencia = Enum.GetValues(typeof(Inasistencia))
                       .Cast<Inasistencia>()
                       .ToList();

            return MotivosInasistencia;
        }
        public List<Dash_Motivos> Listar(List<BE_Asistencia> asistencias, List<Inasistencia> motivos, DateTime inicio, DateTime fin)
        {
            List<Dash_Motivos> DashMotivos = new List<Dash_Motivos>();
            foreach (Inasistencia motivo in motivos)
            {
                Dash_Motivos dash = new Dash_Motivos();
                if (motivo != Inasistencia.Asistencia)
                {
                    dash.Motivo = motivo.ToString();
                    dash.Cantidad = asistencias.Where(x => x.Fecha >= inicio && x.Fecha <= fin).Count(x => x.Motivo.ToString() == dash.Motivo);
                    DashMotivos.Add(dash);
                }
            }
            return DashMotivos;
        }
        public Dash_Motivos MotivoFrecuente(List<Dash_Motivos> lista)
        {
            Dash_Motivos motivo = lista.OrderByDescending(x => x.Cantidad).FirstOrDefault();
            return motivo;
        }
    }
}
