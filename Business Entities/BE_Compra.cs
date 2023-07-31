using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraction_Layer;

namespace Business_Entities
{
    public abstract class BE_Compra : IEntidable
    {
        public int Codigo { get; set; }
        public MaterialCompra Material { get; set; }
        public decimal Cantidad { get; set; }
        public DateTime FechaCompra { get; set; }
        public DateTime FechaEntrega { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public decimal CantidadRecibida { get; set; }
        public string NroFactura { get; set; }
        public decimal Costo { get; set; }
        public StausComp Status { get; set; }
        public bool Activo { get; set; } = true;

    }

    public enum StausComp
    {
        En_Curso,
        Entregada,
        Devolucion,
        Rechazada
    }
    public enum MaterialCompra
    {
        Ingrediente = 1,
        Bebida = 2
    }

}
