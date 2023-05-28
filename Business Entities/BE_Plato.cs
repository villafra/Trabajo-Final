using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraction_Layer;

namespace Business_Entities
{
    public class BE_Plato : IEntidable
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public string Clase { get; set; }
        public string Status { get; set; }
        public decimal CostoUnitario { get; set; }
        public bool Activo { get; set; }
        public List<BE_Ingrediente> ListaIngredientes { get; set; }
        
    }
}
