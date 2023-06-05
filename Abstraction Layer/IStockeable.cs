﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction_Layer
{
    public interface IStockeable
    {
        decimal Stock { get; set; }
        decimal CostoUnitario { get; set; }
        string UnidadMedida { get; set; }
        DateTime FechaCreacion { get; set; }
        int VidaUtil { get; set; }

    }
}
