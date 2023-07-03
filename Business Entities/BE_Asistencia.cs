using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraction_Layer;

namespace Business_Entities
{
    public class BE_Asistencia : IEntidable, ICloneable
    {
        public int Codigo { get; set; }
        public BE_Novedad Novedad { get; set; }
        public DateTime Fecha { get; set; }
        public bool Asistencia { get; set; }
        public TimeSpan HoraIngreso { get; set; }
        public TimeSpan HoraEgreso { get; set; }
        public Inasistencia Motivo { get; set; } = Inasistencia.Asistencia;

        public object Clone()
        {
            BE_Asistencia clon = (BE_Asistencia)MemberwiseClone();
            return clon;
        }
        public override string ToString()
        {
            return this.Fecha.ToString("dd/MM/yyyy") + "-" + this.Motivo.ToString();
        }
    }

    public enum Inasistencia
    {
        Asistencia,
        Vacaciones,
        Enfermedad,
        Licencia,
        Tramite_Personal,
        Día_Compensatorio,
        Día_Estudio,
        Duelo,
        Familiar_Enfermo,
        Asuntos_Legales,
        Casamiento,
    }
}
