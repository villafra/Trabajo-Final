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
    public class MPP_Mesa:IGestionable<BE_Mesa>
    {
        Xml_Database Acceso;

        public bool Baja(BE_Mesa Objeto)
        {
            throw new NotImplementedException();
        }

        public bool Guardar(BE_Mesa Objeto)
        {
            throw new NotImplementedException();
        }

        public List<BE_Mesa> Listar()
        {
            throw new NotImplementedException();
        }

        public BE_Mesa ListarObjeto(BE_Mesa Objeto)
        {
            throw new NotImplementedException();
        }
    }
}
