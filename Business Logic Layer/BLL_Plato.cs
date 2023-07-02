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
    public class BLL_Plato : IGestionable<BE_Plato>,IMovimentable<BE_Plato,BE_Compra>
    {
        public void ActualizarStatus()
        {
            throw new NotImplementedException();
        }

        public bool AgregarStock(BE_Plato plato, BE_Compra compra)
        {
            throw new NotImplementedException();
        }

        public bool Baja(BE_Plato plato)
        {
            return MPP_Plato.DevolverInstancia().Baja(plato);
        }

        public DateTime DevolverFechaVencimiento(BE_Plato plato)
        {
            throw new NotImplementedException();
        }

        public decimal DevolverStock(BE_Plato plato, bool conlote)
        {
            throw new NotImplementedException();
        }

        public bool Guardar(BE_Plato plato)
        {
            return MPP_Plato.DevolverInstancia().Guardar(plato);
        }

        public List<BE_Plato> Listar()
        {
            return MPP_Plato.DevolverInstancia().Listar();
        }

        public BE_Plato ListarObjeto(BE_Plato plato, DataSet ds = null)
        {
            return MPP_Plato.DevolverInstancia().ListarObjeto(plato);
        }

        public bool Modificar(BE_Plato plato)
        {
            return MPP_Plato.DevolverInstancia().Modificar(plato);
        }

        public void VerificarStatus()
        {
            throw new NotImplementedException();
        }
    }
}
