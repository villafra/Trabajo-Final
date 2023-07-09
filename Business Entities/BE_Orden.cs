using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraction_Layer;

namespace Business_Entities
{
    public class BE_Orden : IEntidable
    {
        public int Codigo { get; set; }
        public int Pasos_Orden { get; set; }
        public StatusOrden Status { get; set; } = StatusOrden.En_Espera;
        public BE_Pedido ID_Pedido { get; set; }
        public BE_Mesa ID_Mesa { get; set; }
        public BE_Empleado ID_Empleado { get; set; }
        public bool Activo { get; set; } = true;
    }
    public enum StatusOrden
    {
        En_Espera,
        Preparando_Bebidas,
        Bebidas_Listas,
        Bebidas_Entregadas,
        Preparando_Platos,
        Platos_Listos,
        Platos_Entregados,
        Orden_Entregada
    }
}
