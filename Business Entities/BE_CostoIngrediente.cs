using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Entities
{
    public class BE_CostoIngrediente:BE_Costo
    {
        public TipoMaterial Tipo { get; set; }
        public BE_Ingrediente ID_Ingrediente { get; set; }
    }
}
