using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_Entities;
using Abstraction_Layer;

namespace Business_Logic_Layer
{
    public class BLL_Compra : IGestionable<BE_Compra>
    {
        public bool Baja(BE_Compra Objeto)
        {
            throw new NotImplementedException();
        }

        public bool Guardar(BE_Compra Objeto)
        {
            throw new NotImplementedException();
        }

        public List<BE_Compra> Listar()
        {
            throw new NotImplementedException();
        }

        public BE_Compra ListarObjeto(BE_Compra Objeto)
        {
            throw new NotImplementedException();
        }

        public bool recepcionarCompra()
        {
            throw new NotImplementedException();
        }

        public BE_Compra devolverCompra(long nroCompra)
        {
            throw new NotImplementedException();
        }
    }
}
