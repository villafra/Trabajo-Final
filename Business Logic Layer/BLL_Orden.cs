using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_Entities;
using Abstraction_Layer;

namespace Business_Logic_Layer
{
    public class BLL_Orden : IGestionable<BE_Orden>
    {
        public bool Baja(BE_Orden Objeto)
        {
            throw new NotImplementedException();
        }

        public bool Guardar(BE_Orden Objeto)
        {
            throw new NotImplementedException();
        }

        public List<BE_Orden> Listar()
        {
            throw new NotImplementedException();
        }

        public BE_Orden ListarObjeto(BE_Orden Objeto)
        {
            throw new NotImplementedException();
        }

        public void dividirPasos()
        {
            throw new NotImplementedException();
        }

        public bool actualizarStatus()
        {
            throw new NotImplementedException();
        }

        public bool entregarOrden()
        {
            throw new NotImplementedException();
        }

        public DateTime obtenerTiempoPedido()
        {
            throw new NotImplementedException();
        }

        public void obtenerItemsPedido()
        {
            throw new NotImplementedException();
        }
    }
}
