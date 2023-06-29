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
    public class BLL_Mesa : IGestionable<BE_Mesa>, IMovimentable<BE_Mesa,BE_Compra>
    {
        MPP_Mesa oMPP_Mesa;

        public BLL_Mesa()
        {
            oMPP_Mesa = new MPP_Mesa();
        }

        public void ActualizarStatus()
        {
            throw new NotImplementedException();
        }

        public bool AgregarStock(BE_Mesa mesa, BE_Compra compra)
        {
            throw new NotImplementedException();
        }

        public bool Baja(BE_Mesa mesa)
        {
            return oMPP_Mesa.Baja(mesa);
        }

        public DateTime DevolverFechaVencimiento(BE_Mesa mesa)
        {
            throw new NotImplementedException();
        }

        public decimal DevolverStock(BE_Mesa mesa, bool conlote)
        {
            throw new NotImplementedException();
        }

        public bool Guardar(BE_Mesa mesa)
        {
            return oMPP_Mesa.Guardar(mesa);
        }

        public List<BE_Mesa> Listar()
        {
            return oMPP_Mesa.Listar();
        }
        public List<BE_Mesa> ListarLibres()
        {
            return oMPP_Mesa.ListarLibres();
        }
        public BE_Mesa ListarObjeto(BE_Mesa mesa)
        {
            return oMPP_Mesa.ListarObjeto(mesa);
        }

        public bool Modificar(BE_Mesa mesa)
        {
            return oMPP_Mesa.Modificar(mesa);
        }
        public bool CombinarMesa(BE_Mesa mesa1, BE_Mesa mesa2)
        {
            BE_Mesa mesa3 = new BE_Mesa();
            mesa3.Capacidad = mesa1.Capacidad + mesa2.Capacidad;
            mesa3.Ubicación = mesa1.Ubicación;
            mesa3.Status = mesa1.Status;
            mesa1.Status = StatusMesa.No_Disponible;
            mesa2.Status = StatusMesa.No_Disponible;

            List<BE_Mesa> lista = new List<BE_Mesa>();
            lista.Add(mesa1);
            lista.Add(mesa2);

            return oMPP_Mesa.CombinarMesa(lista) & oMPP_Mesa.Guardar(mesa3);
        }
        public void VerificarStatus()
        {
            throw new NotImplementedException();
        }
    }
}
