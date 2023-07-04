using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraction_Layer;

namespace Business_Entities
{
    public class BE_BebidaReceta:IEntidable
    {
        public int Codigo { get; set; }
        public BE_Bebida_Preparada Bebida { get; set; }
        public BE_Ingrediente Ingrediente { get; set; }
        public string Alternativa { get; set; }

        public override string ToString()
        {
            return Codigo + "-" + Alternativa;
        }
    }
}
