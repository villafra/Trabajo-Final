using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraction_Layer;

namespace Business_Entities
{
    public class BE_Mesa : IEntidable
    {
        public int Codigo { get; set; }
        public int Capacidad { get; set; }
        public string Ubicación { get; set; }
        public int OcupaciónActual { get; set; }
        public string Status { get; set; }
        public BE_Empleado ID_Empleado { get; set; }
    }
}
