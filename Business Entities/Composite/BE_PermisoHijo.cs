using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Entities
{
    public class BE_PermisoHijo : BE_Permiso
    {
        public override void AgregarPermiso(BE_Permiso permiso)
        {
            throw new NotImplementedException("Un permiso Hijo No puede ser Padre.");
        }

        public override List<BE_Permiso> ListaPermisos()
        {
            return new List<BE_Permiso>() { this };
        }
    }
}
