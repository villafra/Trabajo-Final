using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Entities
{
    public class BE_Bebida_Preparada:BE_Bebida
    {
        public decimal ABV { get; set; }
        public List<BE_Ingrediente> ListaIngredientes { get; set; }
    }
}
