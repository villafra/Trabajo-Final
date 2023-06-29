using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Entities
{
    public class BE_MesaCombinada : BE_Mesa
    {
        public BE_Mesa Mesa1 { get; set; }
        public BE_Mesa Mesa2 { get; set; }


    }
}
