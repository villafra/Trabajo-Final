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
    public class MPP_Compra:IGestionable<BE_Compra>
    {
        Xml_Database Acceso;

        public bool Baja(BE_Compra compra)
        {
            throw new NotImplementedException();
        }

        public bool Guardar(BE_Compra compra)
        {
            throw new NotImplementedException();
        }

        public List<BE_Compra> Listar()
        {
            throw new NotImplementedException();
        }

        public BE_Compra ListarObjeto(BE_Compra compra)
        {
            throw new NotImplementedException();
        }
    }
}
