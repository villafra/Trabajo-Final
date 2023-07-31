using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Entities
{
    public class BE_CompraBebida : BE_Compra
    {
        public BE_Bebida ID_Material { get; set; }

        public override string ToString()
        {
            return ID_Material.ToString();
        }
    }
}
