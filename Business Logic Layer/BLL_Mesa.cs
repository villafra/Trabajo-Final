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
    public class BLL_Mesa : IGestionable<BE_Mesa>, IMovimentable<BE_Mesa,BE_Compra>
    {
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
            return MPP_Mesa.DevolverInstancia().Baja(mesa);
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
            return MPP_Mesa.DevolverInstancia().Guardar(mesa);
        }

        public List<BE_Mesa> Listar()
        {
            return MPP_Mesa.DevolverInstancia().Listar();
        }
        public List<BE_Mesa> ListarLibres()
        {
            return MPP_Mesa.DevolverInstancia().ListarLibres();
        }
        public BE_Mesa ListarObjeto(BE_Mesa mesa, DataSet ds = null)
        {
            return MPP_Mesa.DevolverInstancia().ListarObjeto(mesa);
        }

        public bool Modificar(BE_Mesa mesa)
        {
            return MPP_Mesa.DevolverInstancia().Modificar(mesa);
        }
        public bool CombinarMesa(BE_Mesa mesa1, BE_Mesa mesa2)
        {
            BE_MesaCombinada mesa3 = new BE_MesaCombinada();
            mesa3.Capacidad = mesa1.Capacidad + mesa2.Capacidad;
            mesa3.Ubicación = mesa1.Ubicación;
            mesa3.Status = mesa1.Status;
            mesa3.Mesa1 = mesa1;
            mesa3.Mesa2 = mesa2;
            mesa1.Status = StatusMesa.No_Disponible;
            mesa2.Status = StatusMesa.No_Disponible;

            List<BE_Mesa> lista = new List<BE_Mesa>();
            lista.Add(mesa1);
            lista.Add(mesa2);

            return MPP_Mesa.DevolverInstancia().CombinarMesa(lista) & MPP_Mesa.DevolverInstancia().Guardar(mesa3);
        }

        public bool LiberarMesa(BE_Mesa oBE_Mesa)
        {
            oBE_Mesa.Status = StatusMesa.Libre;
            if (oBE_Mesa is BE_MesaCombinada)
            {
                return DescombinarMesa(oBE_Mesa as BE_MesaCombinada);
            }
            else return Modificar(oBE_Mesa);
        }

        public bool DescombinarMesa(BE_MesaCombinada mesa3)
        {
            BE_Mesa mesa1 = mesa3.Mesa1;
            BE_Mesa mesa2 = mesa3.Mesa2;
            mesa1 = ListarObjeto(mesa1);
            mesa2 = ListarObjeto(mesa2);
            mesa1.Status = StatusMesa.Libre;
            mesa2.Status = StatusMesa.Libre;

            List<BE_Mesa> lista = new List<BE_Mesa>();
            lista.Add(mesa1);
            lista.Add(mesa2);

            return MPP_Mesa.DevolverInstancia().CombinarMesa(lista) & MPP_Mesa.DevolverInstancia().Baja(mesa3);
        }
        public void VerificarStatus()
        {
            throw new NotImplementedException();
        }
    }
}
