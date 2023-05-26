using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction_Layer
{
    public interface IMovimentable
    {
        int DevolverStock();
        void AgregarStock(int Cantidad);
        void ActualizarStatus();
        void VerificarStatus();
        DateTime DevolverFechaVencimiento();
    }
}
