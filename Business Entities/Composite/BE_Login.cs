using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraction_Layer;

namespace Business_Entities
{
    public class BE_Login:IEntidable
    {
        public int Codigo { get; set; }
        public BE_Empleado Empleado { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }
        public int CantidadIntentos { get; set; }
        public BE_Permiso Permiso { get; set; }
        public bool Activo { get; set; }
        public bool Bloqueado { get; set; }

        public override string ToString()
        {
            if (Empleado != null) return Empleado.Nombre + " " + Empleado.Apellido;
            else return "admin";

        }
    }
}
