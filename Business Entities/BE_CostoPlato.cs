using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Entities
{
    public class BE_CostoPlato: BE_Costo
    {
        public TipoMaterial Tipo { get; set; }
        public BE_Plato ID_Plato { get; set; }
    }
}
