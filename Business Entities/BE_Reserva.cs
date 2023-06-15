using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraction_Layer;

namespace Business_Entities
{
    public class BE_Reserva : IEntidable
    {
        public int Codigo { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFin { get; set; }
        public bool Recurrencia { get; set; }
        public DateTime FechaFin { get; set; }
        public string TipoRecurrencia { get; set; }
        public BE_Pedido ID_Pedido { get; set; }
        public bool Activo { get; set; } = true;
    }

    
}
