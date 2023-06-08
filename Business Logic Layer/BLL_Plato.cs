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
    public class BLL_Plato : IGestionable<BE_Plato>,IMovimentable<BE_Plato>
    {
        MPP_Plato oMPP_Plato;
        public BLL_Plato()
        {
            oMPP_Plato = new MPP_Plato();
        }

        public void ActualizarStatus()
        {
            throw new NotImplementedException();
        }

        public void AgregarStock(BE_Plato plato, int Cantidad)
        {
            throw new NotImplementedException();
        }

        public bool Baja(BE_Plato plato)
        {
            return oMPP_Plato.Baja(plato);
        }

        public DateTime DevolverFechaVencimiento(BE_Plato plato)
        {
            throw new NotImplementedException();
        }

        public decimal DevolverStock(BE_Plato plato)
        {
            throw new NotImplementedException();
        }

        public bool Guardar(BE_Plato plato)
        {
            return oMPP_Plato.Guardar(plato);
        }

        public List<BE_Plato> Listar()
        {
            return oMPP_Plato.Listar();
        }

        public BE_Plato ListarObjeto(BE_Plato plato)
        {
            return oMPP_Plato.ListarObjeto(plato);
        }

        public bool Modificar(BE_Plato plato)
        {
            return oMPP_Plato.Modificar(plato);
        }

        public void VerificarStatus()
        {
            throw new NotImplementedException();
        }
    }
}
