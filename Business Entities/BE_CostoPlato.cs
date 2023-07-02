using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraction_Layer;
namespace Business_Entities
{
    public class BE_CostoPlato: BE_Costo 
    {
        public  BE_Plato Material { get; set; }
       
    }
}
