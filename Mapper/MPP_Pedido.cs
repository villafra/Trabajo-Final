﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_Entities;
using Abstraction_Layer;
using Data_Access_Layer;

namespace Mapper
{
    public class MPP_Pedido:IGestionable<BE_Pedido>
    {
        Xml_Database Acceso;

        public bool Baja(BE_Pedido pedido)
        {
            throw new NotImplementedException();
        }

        public bool Guardar(BE_Pedido pedido)
        {
            throw new NotImplementedException();
        }

        public List<BE_Pedido> Listar()
        {
            throw new NotImplementedException();
        }

        public BE_Pedido ListarObjeto(BE_Pedido pedido)
        {
            throw new NotImplementedException();
        }
    }
}
