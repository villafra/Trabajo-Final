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
        public List<Dash_Motivos> Listar(DateTime inicio, DateTime fin)
        {
            List<BE_Asistencia> lista = MPP_Asistencia.DevolverInstancia().Listar();
            List<Dash_Motivos> motivos = new List<Dash_Motivos>();
            var listaStrings = Enum.GetValues(typeof(Inasistencia))
                       .Cast<Inasistencia>()
                       .Select(e => e.ToString())
                       .ToList();

            foreach (var asis in listaStrings)
            {
                Dash_Motivos dash = new Dash_Motivos();
                if (asis != Inasistencia.Asistencia.ToString())
                {
                    dash.Motivo = asis;
                    dash.Cantidad = lista.Where(x=> x.Fecha >= inicio && x.Fecha <= fin).Count(x => x.Motivo.ToString() == dash.Motivo);
                    motivos.Add(dash);
                }
                
            }
           return motivos;
        }
    }
}
