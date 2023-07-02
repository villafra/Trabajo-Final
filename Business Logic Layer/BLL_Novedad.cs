using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_Entities;
using Mapper;
using Abstraction_Layer;

namespace Business_Logic_Layer
{
    public class BLL_Novedad : IGestionable<BE_Novedad>
    {
        MPP_Novedad oMPP_Novedad;

        public BLL_Novedad()
        {
            oMPP_Novedad = new MPP_Novedad();
        }

        public bool Baja(BE_Novedad Novedad)
        {
            return oMPP_Novedad.Baja(Novedad);
        }

        public bool Guardar(BE_Novedad Novedad)
        {
            return oMPP_Novedad.Guardar(Novedad);
        }

        public List<BE_Novedad> Listar()
        {
            return oMPP_Novedad.Listar();
        }

        public BE_Novedad ListarObjeto(BE_Novedad Novedad)
        {
            return oMPP_Novedad.ListarObjeto(Novedad);
        }

        public bool Modificar(BE_Novedad Novedad)
        {
            return oMPP_Novedad.Modificar(Novedad);
        }
    }
}
