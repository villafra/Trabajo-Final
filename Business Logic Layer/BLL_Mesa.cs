﻿using System;
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

        public BE_Mesa ListarObjeto(BE_Mesa mesa)
        {
            return oMPP_Mesa.ListarObjeto(mesa);
        }

        public bool Modificar(BE_Mesa mesa)
        {
            return oMPP_Mesa.Modificar(mesa);
        }

        public void VerificarStatus()
        {
            throw new NotImplementedException();
        }
    }
}
