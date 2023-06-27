using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_Entities;
using Abstraction_Layer;
using Mapper;

namespace Business_Logic_Layer
{
    public class BLL_Costo : IGestionable<BE_Costo>
    {
        MPP_Costo oMPP_Costo;
        public bool Baja(BE_Costo Costo)
        {
            oMPP_Costo = new MPP_Costo();
            return oMPP_Costo.Baja(Costo);
        }

        public bool Guardar(BE_Costo Costo)
        {
            oMPP_Costo = new MPP_Costo();
            return oMPP_Costo.Guardar(Costo);
        }

        public List<BE_Costo> Listar()
        {
            oMPP_Costo = new MPP_Costo();
            return oMPP_Costo.Listar();
        }

        public BE_Costo ListarObjeto(BE_Costo Costo)
        {
            oMPP_Costo = new MPP_Costo();
            return oMPP_Costo.ListarObjeto(Costo);
        }

        public bool Modificar(BE_Costo Costo)
        {
            oMPP_Costo = new MPP_Costo();
            return oMPP_Costo.Modificar(Costo);
        }
    }
}
