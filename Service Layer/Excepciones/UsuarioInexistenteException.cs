using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Service_Layer.Excepciones
{
    public class UsuarioInexistenteException : RestaurantException
    {
        public UsuarioInexistenteException()
        {
        }

        public UsuarioInexistenteException(string message) : base(message)
        {
        }

        public UsuarioInexistenteException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UsuarioInexistenteException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
