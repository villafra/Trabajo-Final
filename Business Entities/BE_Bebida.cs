﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraction_Layer;

namespace Business_Entities
{
    public class BE_Bebida : IEntidable,IStockeable
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public decimal Presentacion { get; set; }
        public decimal Stock { get; set; }
        public decimal CostoUnitario { get; set; }
        public string UnidadMedida { get; set; }
        public int VidaUtil { get; set; }
        public void ActualizarStatus()
        {
            throw new NotImplementedException();
        }

        public void AgregarStock(int Cantidad)
        {
            throw new NotImplementedException();
        }

        public DateTime DevolverFechaVencimiento()
        {
            throw new NotImplementedException();
        }
    }
}
