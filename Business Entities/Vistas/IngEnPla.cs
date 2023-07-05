using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Entities
{
    public class IngEnPla
    {
        public int Codigo { get; set; }
        public BE_Ingrediente Ingrediente { get; set; }
        public decimal Cantidad { get; set; }
        public string Alt { get; set; }
    }
}
