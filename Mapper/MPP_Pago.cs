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
    public class MPP_Pago:IGestionable<BE_Pago>
    {
        Xml_Database Acceso;

        public bool Baja(BE_Pago pago)
        {
            throw new NotImplementedException();
        }

        public bool Guardar(BE_Pago pago)
        {
            throw new NotImplementedException();
        }

        public List<BE_Pago> Listar()
        {
            throw new NotImplementedException();
        }

        public BE_Pago ListarObjeto(BE_Pago pago)
        {
            throw new NotImplementedException();
        }
    }
}
