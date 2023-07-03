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
    public class BLL_Novedad : IGestionable<BE_Novedad>
    {
        public bool Baja(BE_Novedad Novedad)
        {
            return MPP_Novedad.DevolverInstancia().Baja(Novedad);
        }

        public bool Guardar(BE_Novedad Novedad)
        {
            return MPP_Novedad.DevolverInstancia().Guardar(Novedad);
        }

        public List<BE_Novedad> Listar()
        {
            return MPP_Novedad.DevolverInstancia().Listar();
        }

        public BE_Novedad ListarObjeto(BE_Novedad Novedad, DataSet ds = null)
        {
            return MPP_Novedad.DevolverInstancia().ListarObjeto(Novedad);
        }

        public bool Modificar(BE_Novedad Novedad)
        {
            return MPP_Novedad.DevolverInstancia().Modificar(Novedad);
        }
        public bool ExisteNovedad(BE_Empleado empleado)
        {
            return MPP_Novedad.DevolverInstancia().ExisteNovedad(empleado);
        }
        public BE_Novedad Novedad_Empleado(BE_Empleado empleado, DataSet ds = null)
        {
            return MPP_Novedad.DevolverInstancia().Novedad_Empleado(empleado);
        }
        public bool AsignarVacacionesXLey(BE_Novedad novedad)
        {
            int antiguedad = novedad.Empleado.CalcularAños(novedad.Empleado.FechaIngreso);
            int vacaciones;
            if (antiguedad >= 0 && antiguedad < 5) vacaciones = 14;
            else if (antiguedad >= 5 && antiguedad < 10) vacaciones = 21;
            else if (antiguedad >= 10 && antiguedad < 20) vacaciones = 28;
            else vacaciones = 35;
            novedad.VacacionesDisponibles = vacaciones;
            return MPP_Novedad.DevolverInstancia().Modificar(novedad);
        }
    }
}
