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
    public class BLL_Bebida : IGestionable<BE_Bebida>, IMovimentable<BE_Bebida>
    {
        MPP_Bebida oMPP_Bebida;
        public BLL_Bebida()
        {
            oMPP_Bebida = new MPP_Bebida();
        }

        public void ActualizarStatus(BE_Bebida bebida, BE_Bebida.Tipo_Bebida tipo)
        {
            bebida.Tipo = tipo;
            Modificar(bebida);
        }

        public void AgregarStock(BE_Bebida bebida,  int Cantidad)
        {
            bebida.Stock += Cantidad;
            Modificar(bebida);
        }

        public bool Baja(BE_Bebida bebida)
        {
            return oMPP_Bebida.Baja(bebida);
        }

        public DateTime DevolverFechaVencimiento(BE_Bebida bebida)
        {
            return bebida.FechaCreacion.AddDays(bebida.VidaUtil);
        }

        public decimal DevolverStock(BE_Bebida bebida)
        {
            return bebida.Stock;
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

        public BE_Bebida.Tipo_Bebida VerificarStatus(BE_Bebida bebida)
        {
            return bebida.Tipo;
        }

    }
}
