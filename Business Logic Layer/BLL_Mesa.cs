using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraction_Layer;
using Business_Entities;

namespace Business_Logic_Layer
{
    public class BLL_Mesa : IGestionable<BE_Mesa>, IMovimentable
    {
        public void ActualizarStatus()
        {
            throw new NotImplementedException();
        }

        public void AgregarStock(int Cantidad)
        {
            throw new NotImplementedException();
        }

        public bool Baja(BE_Mesa Objeto)
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

        public bool Guardar(BE_Mesa Objeto)
        {
            throw new NotImplementedException();
        }

        public List<BE_Mesa> Listar()
        {
            throw new NotImplementedException();
        }

        public BE_Mesa ListarObjeto(BE_Mesa Objeto)
        {
            throw new NotImplementedException();
        }

        public void VerificarStatus()
        {
            throw new NotImplementedException();
        }
    }
}
