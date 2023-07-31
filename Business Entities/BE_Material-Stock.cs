using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraction_Layer;

namespace Business_Entities
{
    public class BE_Material_Stock : IEntidable,IStockeable<BE_Ingrediente>
    {
        public int Codigo { get; set; }
        public BE_Ingrediente Material { get; set; }
        public decimal Stock { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string Lote { get; set; }
        public DateTime? FechaVencimiento { get; set; }

    }
}
