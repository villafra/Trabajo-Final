using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Service_Layer
{
    public class RestaurantException : ApplicationException
    {
        public RestaurantException()
        {
        }

        public RestaurantException(string message) : base(message)
        {
        }

        public RestaurantException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected RestaurantException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
