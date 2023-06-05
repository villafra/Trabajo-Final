using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_Entities;

namespace Business_Logic_Layer
{
    public class BLL_Bebida_Alcoholica:BLL_Bebida
    {
        public decimal devolverABV(BE_Bebida_Alcoholica bebida)
        {
            return bebida.ABV;
        }
    }
}
