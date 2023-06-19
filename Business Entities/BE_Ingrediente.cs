using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraction_Layer;

namespace Business_Entities
{
    public class BE_Ingrediente : IEntidable
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public TipoIng Tipo { get; set; }
        public bool Refrigeracion { get; set; }
        public UM UnidadMedida { get; set; }
        public bool Activo { get; set; } = true;
        public int VidaUtil { get; set; }
        public StatusIng Status { get; set; } = StatusIng.Reservado;
        public decimal CostoUnitario { get; set; }

        public string DevolverNombre()
        {
            string clase = typeof(BE_Ingrediente).Name;
            return clase.Substring(clase.IndexOf("_") + 1, clase.Length - clase.IndexOf("_") - 1);
        }
        public enum TipoIng
        {
            Vegetal,
            Carne,
            Rio_Mar,
            Lácteo,
            Fruta,
            Grano_Cereal,
            Especia_Condimento,
            Hierba,
            Fruto_Seco,
            Aceite,
            Salsa,
            Aderezo,
            Dulce_Azucar,
            Líquido
        }
        public enum StatusIng
        {
            Disponible,
            Agotado,
            Caducado,
            Reservado,
            Bloqueado,
            En_Espera
        }
        public enum UM
        {
            KG,
            L,
            UN,

        }
    }
}
