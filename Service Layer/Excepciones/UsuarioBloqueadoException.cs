using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Service_Layer
{
    public class UsuarioBloqueadoException : RestaurantException
    {
        public UsuarioBloqueadoException()
        {
        }

        public UsuarioBloqueadoException(string message) : base(message)
        {
        }

        public UsuarioBloqueadoException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UsuarioBloqueadoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
