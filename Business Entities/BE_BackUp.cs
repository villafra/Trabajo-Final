using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraction_Layer;

namespace Business_Entities
{
    public class BE_BackUp:IEntidable
    {
        public int Codigo { get; set; }
        public string NombreArchivo { get; set; }
        public string NombreUsuario { get; set; }
        public string Accion { get; set; }
        public DateTime FechaHora { get; set; }
       
    }
}
