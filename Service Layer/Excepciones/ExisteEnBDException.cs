using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Service_Layer
{
    public class ExisteEnBDException : RestaurantException
    {
        public ExisteEnBDException()
        {
        }

        public ExisteEnBDException(string message) : base(message)
        {
        }

        public ExisteEnBDException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ExisteEnBDException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
