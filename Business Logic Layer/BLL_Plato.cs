using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraction_Layer;
using Business_Entities;

namespace Business_Logic_Layer
{
    public class BLL_Plato : IGestionable<BE_Plato>,IMovimentable
    {
        public void ActualizarStatus()
        {
            throw new NotImplementedException();
        }

        public void AgregarStock(int Cantidad)
        {
            throw new NotImplementedException();
        }

        public bool Baja(BE_Plato Objeto)
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

        public bool Guardar(BE_Plato Objeto)
        {
            throw new NotImplementedException();
        }

        public List<BE_Plato> Listar()
        {
            throw new NotImplementedException();
        }

        public BE_Plato ListarObjeto(BE_Plato Objeto)
        {
            throw new NotImplementedException();
        }

        public void VerificarStatus()
        {
            throw new NotImplementedException();
        }
    }
}
