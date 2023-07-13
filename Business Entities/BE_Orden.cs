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
        public StatusOrden Status { get; set; } 
        public BE_Pedido ID_Pedido { get; set; }
        public BE_Mesa ID_Mesa { get; set; }
        public BE_Empleado ID_Empleado { get; set; }
        public bool Finalizada { get; set; } = false;
        public bool Activo { get; set; } = true;

        public StatusOrden DefinirStatusInicial()
        {
            if (ID_Pedido.ListadeBebida.Count == 0)
                return StatusOrden.En_Espera_Platos;
            else
                return StatusOrden.En_Espera_Bebidas;
        }
    }
    public enum StatusOrden
    {
        En_Espera_Bebidas,
        Preparando_Bebidas,
        Bebidas_Listas,
        Bebidas_Entregadas,
        En_Espera_Platos,
        Preparando_Platos,
        Platos_Listos,
        Platos_Entregados,
        Orden_Entregada
    }
}
