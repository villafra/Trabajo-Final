using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraction_Layer;

namespace Business_Entities
{
    public class BE_Pago : IEntidable
    {
        public int Codigo { get; set; }
        public string Tipo { get; set; }
        public bool Activo { get; set; } = true;

        public override string ToString()
        {
            return Codigo + "-" + Tipo;
        }
    }
}
