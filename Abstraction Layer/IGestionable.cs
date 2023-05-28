using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction_Layer
{
    public interface IGestionable<T> where T : IEntidable
    {
        bool Guardar(T Objeto);
        bool Baja(T Objeto);
        bool Modificar(T Objeto);
        List<T> Listar();
        T ListarObjeto(T Objeto);
    }
}
