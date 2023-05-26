using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraction_Layer;
using Business_Entities;

namespace Business_Logic_Layer
{
    public class BLL_Bebida : IGestionable<BE_Bebida>, IMovimentable
    {
        public void ActualizarStatus()
        {
            throw new NotImplementedException();
        }

        public void AgregarStock(int Cantidad)
        {
            throw new NotImplementedException();
        }

        public bool Baja(BE_Bebida Objeto)
        {
            throw new NotImplementedException();
        }

        public DateTime DevolverFechaVencimiento()
        {
            throw new NotImplementedException();
        }

        public int DevolverStock()
        {
            throw new NotImplementedException();
        }

        public bool Guardar(BE_Bebida Objeto)
        {
            throw new NotImplementedException();
        }

        public List<BE_Bebida> Listar()
        {
            throw new NotImplementedException();
        }

        public BE_Bebida ListarObjeto(BE_Bebida Objeto)
        {
            throw new NotImplementedException();
        }

        public void VerificarStatus()
        {
            throw new NotImplementedException();
        }

    }
}
