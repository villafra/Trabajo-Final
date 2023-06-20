using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction_Layer
{
    public interface IMovimentable<T,M> where T : IEntidable where M : IEntidable
    {
        decimal DevolverStock(T Objeto, bool thislote = true);
        bool AgregarStock(T Objeto, M compra);
        DateTime DevolverFechaVencimiento(T Objeto);
    }

}
