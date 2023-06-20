using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction_Layer
{
    public interface IStockeable<T> where T:IEntidable
    {
        decimal Stock { get; set; }
        T Material { get; set; }
        DateTime? FechaCreacion { get; set; }
        string Lote { get; set; }
    }
}
