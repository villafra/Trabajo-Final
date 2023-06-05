using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraction_Layer;
using Business_Entities;

namespace Business_Logic_Layer
{
    public class BLL_Bebida_Preparada: BLL_Bebida
    {
        public decimal devolverABV(BE_Bebida_Preparada bebida)
        {
            return bebida.ABV;
        }

        public List<BE_Ingrediente> devolverIngredientes(BE_Bebida_Preparada bebida)
        {
            return bebida.ListaIngredientes;
        }
    }
}
