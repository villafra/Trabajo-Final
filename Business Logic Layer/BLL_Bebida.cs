using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraction_Layer;
using Business_Entities;
using Mapper;

namespace Business_Logic_Layer
{
    public class BLL_Bebida : IGestionable<BE_Bebida>, IMovimentable
    {
        MPP_Bebida oMPP_Bebida;
        public BLL_Bebida()
        {
            oMPP_Bebida = new MPP_Bebida();
        }

        public void ActualizarStatus()
        {
            throw new NotImplementedException();
        }

        public void AgregarStock(int Cantidad)
        {
            throw new NotImplementedException();
        }

        public bool Baja(BE_Bebida bebida)
        {
            return oMPP_Bebida.Baja(bebida);
        }

        public DateTime DevolverFechaVencimiento()
        {
            throw new NotImplementedException();
        }

        public int DevolverStock()
        {
            throw new NotImplementedException();
        }

        public bool Guardar(BE_Bebida bebida)
        {
            return oMPP_Bebida.Guardar(bebida);
        }

        public List<BE_Bebida> Listar()
        {
            return oMPP_Bebida.Listar();
        }

        public BE_Bebida ListarObjeto(BE_Bebida bebida)
        {
            return oMPP_Bebida.ListarObjeto(bebida);
        }

        public bool Modificar(BE_Bebida bebida)
        {
            return oMPP_Bebida.Modificar(bebida);
        }

        public void VerificarStatus()
        {
            throw new NotImplementedException();
        }

    }
}
