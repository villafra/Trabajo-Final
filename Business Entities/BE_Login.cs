using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraction_Layer;

namespace Business_Entities
{
    public class BE_Login:IEntidable
    {
        public int Codigo { get; set; }
        public BE_Empleado Empleado { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }
        public string eMail { get; set; }
        public int CantidadIntentos { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime HoraIngreso { get; set; }
    }
}
