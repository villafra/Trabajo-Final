using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraction_Layer;

namespace Business_Entities
{
    public abstract class BE_Costo : IEntidable
    {
        public int Codigo { get; set; }
        public DateTime DíaCosteo { get; set; }
        public decimal TamañoLoteCosteo { get; set; }
        public decimal MateriaPrima { get; set; }
        public decimal HorasHombre { get; set; }
        public decimal Energía { get; set; }
        public decimal OtrosGastos { get; set; }
        public bool Activo { get; set; } = true;
        public TipoMaterial Tipo { get; set; }
        public decimal DevolverCosto(decimal cantidad)
        {
            return   ((this.MateriaPrima + this.HorasHombre + this.Energía
                + this.OtrosGastos) / this.TamañoLoteCosteo) * cantidad;
        }

    }

    public enum TipoMaterial
    {
        Ingrediente=1,
        Bebida=2,
        Bebida_Preparada=3,
        Plato=4
    }
}
