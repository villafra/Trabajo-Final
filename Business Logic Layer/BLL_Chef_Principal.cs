using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_Entities;
using Abstraction_Layer;

namespace Business_Logic_Layer
{
    public class BLL_Chef_Principal : BLL_Empleado
    {
        
        public List<BE_Orden> verificarOrdenesLiberadas()
        {
            throw new NotImplementedException();
        }

        public void prepararOrden()
        {
            throw new NotImplementedException();
        }

        public void despacharOrden()
        {
            throw new NotImplementedException();
        }
    }
}
