using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction_Layer
{
    public interface IMovimentable<T> where T : IEntidable
    {
        decimal DevolverStock(T Objeto);
        void AgregarStock(T Objeto, int Cantidad);
        DateTime DevolverFechaVencimiento(T Objeto);
    }

}
