using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraction_Layer;
using Business_Entities;
using Mapper;

namespace Business_Logic_Layer
{
    public class BLL_Bebida : IGestionable<BE_Bebida>/*, IMovimentable<BE_Bebida>*/
    {
        public void ActualizarStatus(BE_Bebida bebida, Tipo_Bebida tipo)
        {
            bebida.Tipo = tipo;
            Modificar(bebida);
        }

        public void AgregarStock(BE_Material_Stock bebida,  int Cantidad)
        {
            bebida.Stock += Cantidad;
            //Modificar(bebida);
        }

        public bool Baja(BE_Bebida bebida)
        {
            return MPP_Bebida.DevolverInstancia().Baja(bebida);
        }

        public DateTime DevolverFechaVencimiento(BE_Material_Stock bebida)
        {
            return bebida.FechaCreacion.Value.AddDays(bebida.Material.VidaUtil);
        }

        public decimal DevolverStock(BE_Material_Stock bebida)
        {
            return bebida.Stock;
        }

        public bool Guardar(BE_Bebida bebida)
        {
            return MPP_Bebida.DevolverInstancia().Guardar(bebida);
        }

        public List<BE_Bebida> Listar()
        {
            return MPP_Bebida.DevolverInstancia().Listar();
        }
        public List<BE_Bebida_Preparada> ListarPreparadas()
        {
            return MPP_Bebida.DevolverInstancia().ListarPreparadas();
        }
        public BE_Bebida ListarObjeto(BE_Bebida bebida, DataSet ds = null)
        {
            return MPP_Bebida.DevolverInstancia().ListarObjeto(bebida);
        }

        public bool Modificar(BE_Bebida bebida)
        {
            return MPP_Bebida.DevolverInstancia().Modificar(bebida);
        }

        public Tipo_Bebida VerificarStatus(BE_Bebida bebida)
        {
            return bebida.Tipo;
        }

    }
}
