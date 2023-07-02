using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_Entities;
using Mapper;
using Abstraction_Layer;
using System.Data;

namespace Business_Logic_Layer
{
    public class BLL_Novedad : IGestionable<BE_Novedad>
    {
        public bool Baja(BE_Novedad Novedad)
        {
            return MPP_Novedad.DevolverInstancia().Baja(Novedad);
        }

        public bool Guardar(BE_Novedad Novedad)
        {
            return MPP_Novedad.DevolverInstancia().Guardar(Novedad);
        }

        public List<BE_Novedad> Listar()
        {
            return MPP_Novedad.DevolverInstancia().Listar();
        }

        public BE_Novedad ListarObjeto(BE_Novedad Novedad, DataSet ds = null)
        {
            return MPP_Novedad.DevolverInstancia().ListarObjeto(Novedad);
        }

        public bool Modificar(BE_Novedad Novedad)
        {
            return MPP_Novedad.DevolverInstancia().Modificar(Novedad);
        }
    }
}
