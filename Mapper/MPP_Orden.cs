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
    public class MPP_Orden:IGestionable<BE_Orden>
    {
        Xml_Database Acceso;

        public bool Baja(BE_Orden Objeto)
        {
            throw new NotImplementedException();
        }

        public bool Guardar(BE_Orden Objeto)
        {
            throw new NotImplementedException();
        }

        public List<BE_Orden> Listar()
        {
            throw new NotImplementedException();
        }

        public BE_Orden ListarObjeto(BE_Orden Objeto)
        {
            throw new NotImplementedException();
        }
    }
}
