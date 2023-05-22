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
        public List<string> Telefono { get; set; }
        public List<string> Mail { get; set; }
        public List<BE_Plato> ListadePlatos { get; set; }
        public List<BE_Bebida> ListadeBebidas { get; set; }
        public List<BE_Reserva> ListaReservas { get; set; }

    }
}
