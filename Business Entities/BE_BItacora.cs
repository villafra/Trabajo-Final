using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Entities
{
    public class BE_Bitacora
    {
        public int CodigoUsuario { get; set; }
        public string Empleado { get; set; }
        public Accion Acción { get; set; }
        public DateTime FechaHora { get; set; }

    }

    public enum Accion
    {
        Login,
        Logout
    }
}
