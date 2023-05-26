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
    public class MPP_Reserva:IGestionable<BE_Reserva>
    {
        Xml_Database Acceso;

        public bool Baja(BE_Reserva Objeto)
        {
            throw new NotImplementedException();
        }

        public bool Guardar(BE_Reserva Objeto)
        {
            throw new NotImplementedException();
        }

        public List<BE_Reserva> Listar()
        {
            throw new NotImplementedException();
        }

        public BE_Reserva ListarObjeto(BE_Reserva Objeto)
        {
            throw new NotImplementedException();
        }
    }
}
