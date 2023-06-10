using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Entities
{
   public abstract class BE_Permiso
    {
        public string Codigo { get; set; }
        public string Descripción { get; set; }
        public bool Otorgado { get; set; }
        public abstract List<BE_Permiso> ListaPermisos();
        public abstract void AgregarPermiso(BE_Permiso permiso);
        public override string ToString()
        {
            return $"{Codigo ?? "[Sin Código]"}-{Descripción ?? "[Sin Descripción]"}";
        }
    }
}
