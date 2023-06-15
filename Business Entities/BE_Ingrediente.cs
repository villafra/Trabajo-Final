using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraction_Layer;

namespace Business_Entities
{
    public class BE_Ingrediente: IEntidable,IStockeable
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public bool Refrigeracion { get; set; }
        public decimal Stock { get; set; }
        public string UnidadMedida { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string Lote { get; set; }
        public bool Activo { get; set; } = true;
        public int VidaUtil { get; set; }
        public string Status { get; set; }
        public decimal CostoUnitario { get; set; }

        public string DevolverNombre()
        {
            string clase = typeof(BE_Ingrediente).Name;
            return clase.Substring(clase.IndexOf("_") + 1, clase.Length - clase.IndexOf("_") - 1);
        }
    }
}
