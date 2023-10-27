using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TemaShopping.Exceptions
{
    [Serializable]
    internal class InvalidProductNumberException : Exception
    {
        public InvalidProductNumberException() { }

        public InvalidProductNumberException(string? message) : base(message) { }

        public InvalidProductNumberException(string? message, Exception? innerException) : base(message, innerException) { }

        protected InvalidProductNumberException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
