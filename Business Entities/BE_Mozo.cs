using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Entities
{
    public class BE_Mozo:BE_Empleado
    {
        public List<BE_Pedido> PedidosTomados{ get; set; }

    }
}
