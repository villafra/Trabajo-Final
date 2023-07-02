using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraction_Layer;

namespace Business_Entities
{
    public class BE_Asistencia : IEntidable
    {
        public int Codigo { get; set; }
        public DateTime Fecha { get; set; }
        public BE_Empleado Empleado { get; set; }
        public bool Asistencia { get; set; }
        public TimeSpan HoraIngreso { get; set; }
        public TimeSpan HoraEgreso { get; set; }
        public Inasistencia Motivo { get; set; }
       
    }

    public enum Inasistencia
    {
        Vacaciones,
        Enfermedad,
        Licencia,
        Tramite_Personal,
        Día_Compensatorio,
        Día_Estudio,

    }
}
