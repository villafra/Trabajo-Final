using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction_Layer
{
    public interface IStockeable
    {
        int Stock { get; set; }
        decimal CostoUnitario { get; set; }
        void AgregarStock(int Cantidad);
    }
}
