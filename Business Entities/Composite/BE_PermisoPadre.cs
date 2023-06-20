using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Entities
{
    public class BE_PermisoPadre : BE_Permiso
    {
        public List<BE_Permiso> _permisos;

        public BE_PermisoPadre()
        {
            _permisos = new List<BE_Permiso>();
        }

        public override void AgregarPermiso(BE_Permiso permiso)
        {
            _permisos.Add(permiso);
        }

        public override List<BE_Permiso> ListaPermisos()
        {
            return _permisos;
        }
    }
}
