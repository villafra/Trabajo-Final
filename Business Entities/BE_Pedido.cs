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
        public BE_Plato ID_Plato { get; set; }
        public BE_Bebida ID_Bebida { get; set; }
        public BE_Pago ID_Pago { get; set; }
        
    }
}
