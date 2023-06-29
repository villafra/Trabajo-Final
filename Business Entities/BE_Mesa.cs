using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraction_Layer;

namespace Business_Entities
{
    public class BE_Mesa : IEntidable
    {
        public int Codigo { get; set; }
        public int Capacidad { get; set; }
        public Ubicacion Ubicación { get; set; }
        public int OcupaciónActual { get; set; } = 0;
        public StatusMesa Status { get; set; }
        public BE_Empleado ID_Empleado { get; set; }
        public bool Activo { get; set; } = true;

        public override string ToString()
        {
            return Codigo.ToString() + "-" + Capacidad.ToString();
        }
    }

    public enum Ubicacion
    {
        Comedor_Principal,
        Terraza,
        Deck,
        Patio_Trasero
    }
    public enum StatusMesa
    {
        Libre,
        Reservada,
        Ocupada,
        No_Disponible
    }
}
