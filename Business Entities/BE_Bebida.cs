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
        public Tipo_Bebida Tipo { get; set; }
        public decimal Presentacion { get; set; }
        public decimal CostoUnitario { get; set; }
        public UM UnidadMedida { get; set; }
        public int VidaUtil { get; set; }
        public bool GestionLote { get; set; }
        public bool Activo { get; set; } = true;


        public string DevolverNombre()
        {
            string clase = this.GetType().Name;
            return clase.Substring(clase.IndexOf("_") + 1, clase.Length - clase.IndexOf("_") - 1);
        }
        public override string ToString()
        {
            return Nombre;
        }
    }
    public enum Tipo_Bebida
    {
        Agua = 1,
        Jugo = 2,
        Licuado = 3,
        Gaseosa = 4,
        Cerveza = 5,
        Vino = 6,
        Trago = 7,
        Aperitivo = 8,
    }
}
