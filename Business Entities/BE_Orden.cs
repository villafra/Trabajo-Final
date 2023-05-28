using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraction_Layer;

namespace Business_Entities
{
    public class BE_Orden : IEntidable
    {
        public int Codigo { get; set; }
        public int Pasos_Orden { get; set; }
        public string Status { get; set; }
        public BE_Pedido ID_Pedido { get; set; }
        public BE_Mesa ID_Mesa { get; set; }
        public BE_Empleado ID_Empleado { get; set; }

    }
}
