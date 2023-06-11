using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraction_Layer;

namespace Business_Entities
{
    public class BE_Horario : IEntidable
    {
        public int Codigo { get; set; }
        public DateTime Día { get; set; }
        public int Hora { get; set; }
        public bool Disponible { get; set; }
        public BE_Reserva ID_Reserva { get; set; }
    }
}
