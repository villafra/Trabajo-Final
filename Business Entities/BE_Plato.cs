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
        public Tipo_Plato Tipo { get; set; }
        public Clasificación Clase { get; set; }
        public decimal CostoUnitario { get; set; }
        public bool Activo { get; set; } = true;
        public List<BE_Ingrediente> ListaIngredientes { get; set; }

        public string DevolverNombre()
        {
            string clase = this.GetType().Name;
            return clase.Substring(clase.IndexOf("_") + 1, clase.Length - clase.IndexOf("_") - 1);
        }
        public override string ToString()
        {
            return Codigo + "-" + Nombre;
        }
    }
    public enum Tipo_Plato
    {
        Entrada,
        Plato_Principal,
        Guarnición,
        Postre
    }
    public enum Clasificación
    {
        Regular,
        Vegetariano,
        Vegano,
        Sin_TACC
    }
}
