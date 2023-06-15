using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraction_Layer;

namespace Business_Entities
{
    public class BE_Compra : IEntidable
    {
        public int Codigo { get; set; }
        public BE_Ingrediente ID_Ingrediente { get; set; }
        public decimal Cantidad { get; set; }
        public DateTime FechaCompra { get; set; }
        public DateTime FechaEntrega { get; set; }
        public decimal CantidadRecibida { get; set; }
        public decimal Costo { get; set; }
        public bool Activo { get; set; } = true;
    }
}
