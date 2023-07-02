using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraction_Layer;

namespace Business_Entities
{
    public class BE_CostoBebida : BE_Costo
    {
        public BE_Bebida Material { get; set; }

    }
}
