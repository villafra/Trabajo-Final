using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraction_Layer;

namespace Business_Entities
{
    public class BE_Cliente : IEntidable
    {
        public int Codigo { get; set; }
        public long DNI { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Telefono { get; set; }
        public string Mail { get; set; }
        public List<BE_Plato> ListadePlatos { get; set; }
        public List<BE_Bebida> ListadeBebidas { get; set; }
        public List<BE_Reserva> ListaReservas { get; set; }
        public bool Activo { get; set; } = true;
        public string DevolverNombre()
        {
            string clase = typeof(BE_Cliente).Name;
            return clase.Substring(clase.IndexOf("_") + 1, clase.Length - clase.IndexOf("_") - 1);
        }

    }
}
