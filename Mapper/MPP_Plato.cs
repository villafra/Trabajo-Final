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
    public class MPP_Plato : IGestionable<BE_Plato>
    {
        Xml_Database Acceso;
        public bool Baja(BE_Plato Objeto)
        {
            throw new NotImplementedException();
        }

        public bool Guardar(BE_Plato Objeto)
        {
            throw new NotImplementedException();
        }

        public List<BE_Plato> Listar()
        {
            throw new NotImplementedException();
        }

        public BE_Plato ListarObjeto(BE_Plato Objeto)
        {
            throw new NotImplementedException();
        }
    }
}
