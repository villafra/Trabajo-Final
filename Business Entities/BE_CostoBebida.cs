using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Entities
{
    public class BE_CostoBebida:BE_Costo
    {
        public TipoMaterial Tipo { get; set; }
        public BE_Bebida ID_Bebida { get; set; }
    }
}
