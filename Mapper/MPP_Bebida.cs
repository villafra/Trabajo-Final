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
    public class MPP_Bebida:IGestionable<BE_Bebida>
    {
        Xml_Database Acceso;
        List<BE_TuplaXML> ListadoXML;

        public MPP_Bebida()
        {
            ListadoXML = new List<BE_TuplaXML>();
        }

        public bool Baja(BE_Bebida bebida)
        {
            throw new NotImplementedException();
        }

        public bool Guardar(BE_Bebida bebida)
        {
            throw new NotImplementedException();
        }

        public List<BE_Bebida> Listar()
        {
            throw new NotImplementedException();
        }

        public BE_Bebida ListarObjeto(BE_Bebida bebida)
        {
            throw new NotImplementedException();
        }

        public bool Modificar(BE_Bebida bebida)
        {
            throw new NotImplementedException();
        }
    }
}
