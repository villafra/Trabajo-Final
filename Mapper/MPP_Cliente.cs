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
    public class MPP_Cliente:IGestionable<BE_Cliente>
    {
        Xml_Database Acceso;

        public bool Baja(BE_Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public bool Guardar(BE_Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public List<BE_Cliente> Listar()
        {
            throw new NotImplementedException();
        }

        public BE_Cliente ListarObjeto(BE_Cliente cliente)
        {
            throw new NotImplementedException();
        }
    }
}
