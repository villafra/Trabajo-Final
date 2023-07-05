
using Abstraction_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Entities
{
    public class BE_Pedido  : IEntidable
    {
        public int Codigo { get; set; }
        public DateTime FechaInicio { get; set; }
        public bool Customizado { get; set; }
        public string Aclaraciones { get; set; }
        public string Status { get; set; }
        public decimal Monto_Total { get; set; }
        public List<BE_Plato> ListadePlatos { get; set; }
        public List<BE_Bebida> ListadeBebida { get; set; }
        public BE_Pago ID_Pago { get; set; }
        public BE_Mozo ID_Mozo { get; set; }
        public bool Activo { get; set; } = true;
    }
   
}
