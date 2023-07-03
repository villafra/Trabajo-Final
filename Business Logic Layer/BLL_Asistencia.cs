using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_Entities;
using Mapper;
using Abstraction_Layer;
using System.Data;

namespace Business_Logic_Layer
{
    public class BLL_Asistencia : IGestionable<BE_Asistencia>
    {
        public bool Baja(BE_Asistencia asistencia)
        {
            return MPP_Asistencia.DevolverInstancia().Baja(asistencia);
        }

        public bool Guardar(BE_Asistencia asistencia)
        {
            return MPP_Asistencia.DevolverInstancia().Guardar(asistencia);
        }

        public List<BE_Asistencia> Listar()
        {
            return MPP_Asistencia.DevolverInstancia().Listar();
        }

        public BE_Asistencia ListarObjeto(BE_Asistencia asistencia, DataSet ds=null)
        {
            return MPP_Asistencia.DevolverInstancia().ListarObjeto(asistencia);
        }

        public bool Modificar(BE_Asistencia asistencia)
        {
            return MPP_Asistencia.DevolverInstancia().Modificar(asistencia);
        }
        public bool CompletarAsistencias(BE_Asistencia asistencia, DateTime inicio, DateTime fin)
        {
            List<BE_Asistencia> listado = new List<BE_Asistencia>();
            for (DateTime fecha = inicio; fecha <= fin; fecha = fecha.AddDays(1))
            {
                BE_Asistencia nueva = (BE_Asistencia)asistencia.Clone();
                nueva.Fecha = fecha;
                listado.Add(nueva);
            }
            return MPP_Asistencia.DevolverInstancia().Guardar(listado);
        }
    }
}
