using System;
using System.Collections.Generic;
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
        MPP_Empleado oMPP_Empleado;

        public BLL_Empleado()
        {
            oMPP_Empleado = new MPP_Empleado();
        }

        public bool Baja(BE_Empleado empleado)
        {
            return oMPP_Empleado.Baja(empleado);
        }

        public bool Guardar(BE_Empleado empleado)
        {
            return oMPP_Empleado.Guardar(empleado);
        }

        public List<BE_Ingrediente> listadosCiegos()
        {
            throw new NotImplementedException();
        }

        public List<BE_Empleado> Listar()
        {
            return oMPP_Empleado.Listar();
        }

        public BE_Empleado ListarObjeto(BE_Empleado empleado)
        {
            return oMPP_Empleado.ListarObjeto(empleado);
        }

        public bool Modificar(BE_Empleado empleado)
        {
            return oMPP_Empleado.Modificar(empleado);
        }

        public void verificarStock()
        {
            throw new NotImplementedException();
        }
        
    }
}
