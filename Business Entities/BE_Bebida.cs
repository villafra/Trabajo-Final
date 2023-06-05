using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraction_Layer;

namespace Business_Entities
{
    public class BE_Bebida : IEntidable
    { 

        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public decimal Presentacion { get; set; }
        public decimal Stock { get; set; }
        public decimal CostoUnitario { get; set; }
        public string UnidadMedida { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int VidaUtil { get; set; }

        public string DevolverNombre()
        {
            string clase = this.GetType().Name;
            return clase.Substring(clase.IndexOf("_") + 1, clase.Length - clase.IndexOf("_") - 1);
        }

        public enum Tipo_Bebida
        {
            Agua,
            Jugo,
            Gaseosa,
            Cerveza,
            Vino,
            Trago,
            Aperitivo,
        }
    }
}
