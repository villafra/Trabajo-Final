using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraction_Layer;
using Business_Entities;
using Mapper;

namespace Business_Logic_Layer
{
    public abstract class BLL_Empleado : IGestionable<BE_Empleado>
    {
        public bool Baja(BE_Empleado empleado)
        {
            return MPP_Empleado.DevolverInstancia().Baja(empleado);
        }

        public bool Guardar(BE_Empleado empleado)
        {
            return MPP_Empleado.DevolverInstancia().Guardar(empleado);
        }

        public List<BE_Ingrediente> listadosCiegos()
        {
            throw new NotImplementedException();
        }

        public List<BE_Empleado> Listar()
        {
            return MPP_Empleado.DevolverInstancia().Listar();
        }

        public BE_Empleado ListarObjeto(BE_Empleado empleado, DataSet ds = null)
        {
            return MPP_Empleado.DevolverInstancia().ListarObjeto(empleado);
        }

        public bool Modificar(BE_Empleado empleado)
        {
            return MPP_Empleado.DevolverInstancia().Modificar(empleado);
        }

        public void verificarStock()
        {
            throw new NotImplementedException();
        }
        public bool Existe(BE_Empleado empleado)
        {
            return MPP_Empleado.DevolverInstancia().Existe(empleado);
        }
        
    }
}
