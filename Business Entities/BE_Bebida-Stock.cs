using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraction_Layer;

namespace Business_Entities
{
    public class BE_Bebida_Stock : IEntidable,IStockeable<BE_Bebida>
    {
        public int Codigo { get; set; }
        public BE_Bebida Material { get; set; }
        public decimal Stock { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string Lote { get; set; }
        public DateTime? FechaVencimiento { get; set; }
    }
}
