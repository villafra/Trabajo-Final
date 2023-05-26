using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraction_Layer;
using Business_Entities;

namespace Business_Logic_Layer
{
    public abstract class BLL_Empleado : IGestionable<BE_Empleado>
    {
        public bool Baja(BE_Empleado Objeto)
        {
            throw new NotImplementedException();
        }

        public bool Guardar(BE_Empleado Objeto)
        {
            throw new NotImplementedException();
        }

        public List<BE_Ingrediente> listadosCiegos()
        {
            throw new NotImplementedException();
        }

        public List<BE_Empleado> Listar()
        {
            throw new NotImplementedException();
        }

        public BE_Empleado ListarObjeto(BE_Empleado Objeto)
        {
            throw new NotImplementedException();
        }

        public void verificarStock()
        {
            throw new NotImplementedException();
        }
        
    }
}
