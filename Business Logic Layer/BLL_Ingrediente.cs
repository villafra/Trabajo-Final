using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraction_Layer;
using Business_Entities;
using Mapper;


namespace Business_Logic_Layer
{
    public class BLL_Ingrediente : IGestionable<BE_Ingrediente>
    {
        public bool Baja(BE_Ingrediente ingrediente)
        {
            return MPP_Ingrediente.DevolverInstancia().Baja(ingrediente);
        }

        public bool Guardar(BE_Ingrediente ingrediente)
        {
            return MPP_Ingrediente.DevolverInstancia().Guardar(ingrediente);
        }

        public List<BE_Ingrediente> Listar()
        {
            return MPP_Ingrediente.DevolverInstancia().Listar();
        }
        public BE_Ingrediente ListarObjeto(BE_Ingrediente ingrediente, DataSet ds = null)
        {
            return MPP_Ingrediente.DevolverInstancia().ListarObjeto(ingrediente);
        }

        public bool actualizarStatus()
        {
            throw new NotImplementedException();
        }

        public bool actualizarCosto()
        {
            throw new NotImplementedException();
        }

        public bool Modificar(BE_Ingrediente ingrediente)
        {
            return MPP_Ingrediente.DevolverInstancia().Modificar(ingrediente);
        }

        public bool Existe(BE_Ingrediente ingrediente)
        {
            return MPP_Ingrediente.DevolverInstancia().Existe(ingrediente);
        }
    }
}
