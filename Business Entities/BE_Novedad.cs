using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraction_Layer;


namespace Business_Entities
{
    public class BE_Novedad:IEntidable
    {
        public int Codigo { get; set; }
        public BE_Empleado Empleado { get; set; }
        public int VacacionesDisponibles { get; set; }
        public List<BE_Asistencia> listadoAsistencia { get; set; }
        public bool Activo { get; set; }


    }
}
