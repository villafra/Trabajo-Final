using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_Entities;
using Abstraction_Layer;
using Mapper;

namespace Business_Logic_Layer
{
    public class BLL_Gerente_Sucursal : BLL_Empleado
    {
       
        public bool combinarMesa(BE_Mesa mesabase, BE_Mesa submesa)
        {
            BE_Mesa Mesacombinada = new BE_Mesa();
            Mesacombinada.Codigo = mesabase.Codigo;
            Mesacombinada.Capacidad = mesabase.Capacidad + submesa.Capacidad;
            Mesacombinada.Ubicación = mesabase.Ubicación;
            Mesacombinada.OcupaciónActual = mesabase.OcupaciónActual;
            Mesacombinada.Status = mesabase.Status;
            Mesacombinada.ID_Empleado = mesabase.ID_Empleado;

            List<BE_Mesa> listadeMesas = new List<BE_Mesa>();
            listadeMesas.Add(mesabase);
            listadeMesas.Add(submesa);

            try
            {
                return MPP_Mesa.DevolverInstancia().CombinarMesa(listadeMesas) & MPP_Mesa.DevolverInstancia().Guardar(Mesacombinada);
            }
            catch(Exception ex)
            {
                return false;
                throw ex;
            }
            

            
        }

        public bool relevarCategoria(BE_Empleado empleado, Category categoria)
        {
            MPP_Empleado oMPP_Empleado = new MPP_Empleado();

            empleado.Categoria = categoria;
            try
            {
                return oMPP_Empleado.Modificar(empleado);
            }
            catch(Exception ex)
            {
                return false;
                throw ex;
            }
        }

        public void cargarAsistencia()
        {
            throw new NotImplementedException();
        }

        public void cargarLicencia()
        {
            throw new NotImplementedException();
        }

        public void cargarVacaciones()
        {
            throw new NotImplementedException();
        }

        public void HabilitarProveedor()
        {
            throw new NotImplementedException();
        }
    }
}
