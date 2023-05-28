using System;
using System.Collections.Generic;
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
        MPP_Ingrediente oMPP_Ingrediente;

        public BLL_Ingrediente()
        {
            oMPP_Ingrediente = new MPP_Ingrediente();
        }

        public bool Baja(BE_Ingrediente ingrediente)
        {
            return oMPP_Ingrediente.Baja(ingrediente);
        }

        public bool Guardar(BE_Ingrediente ingrediente)
        {
            return oMPP_Ingrediente.Guardar(ingrediente);
        }

        public List<BE_Ingrediente> Listar()
        {
            return oMPP_Ingrediente.Listar();
        }

        public BE_Ingrediente ListarObjeto(BE_Ingrediente ingrediente)
        {
            return oMPP_Ingrediente.ListarObjeto(ingrediente);
        }

        public DateTime devolverFechaVencimiento()
        {
            throw new NotImplementedException();
        }

        public bool actualizarStatus()
        {
            throw new NotImplementedException();
        }

        public bool actualizarCosto()
        {
            throw new NotImplementedException();
        }
    }
}
