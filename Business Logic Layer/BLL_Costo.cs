using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_Entities;
using Abstraction_Layer;
using Mapper;
using System.Data;

namespace Business_Logic_Layer
{
    public class BLL_Costo : IGestionable<BE_Costo>
    {
        public bool Baja(BE_Costo Costo)
        {
            return MPP_Costo.DevolverInstancia().Baja(Costo);
        }

        public bool Guardar(BE_Costo Costo)
        {
            return MPP_Costo.DevolverInstancia().Guardar(Costo);
        }

        public List<BE_Costo> Listar()
        {
            return MPP_Costo.DevolverInstancia().Listar();
        }

        public BE_Costo ListarObjeto(BE_Costo Costo, DataSet ds = null)
        {
            return MPP_Costo.DevolverInstancia().ListarObjeto(Costo);
        }

        public bool Modificar(BE_Costo Costo)
        {
            return MPP_Costo.DevolverInstancia().Modificar(Costo);
        }
    }
}
