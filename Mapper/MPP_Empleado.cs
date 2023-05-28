using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_Entities;
using Abstraction_Layer;
using Data_Access_Layer;

namespace Mapper
{
    public class MPP_Empleado:IGestionable<BE_Empleado>
    {
        Xml_Database Acceso;

        public bool Baja(BE_Empleado empleado)
        {
            throw new NotImplementedException();
        }

        public bool Guardar(BE_Empleado empleado)
        {
            throw new NotImplementedException();
        }

        public List<BE_Empleado> Listar()
        {
            throw new NotImplementedException();
        }

        public BE_Empleado ListarObjeto(BE_Empleado empleado)
        {
            throw new NotImplementedException();
        }

        public bool Modificar(BE_Empleado Objeto)
        {
            throw new NotImplementedException();
        }
    }
}
