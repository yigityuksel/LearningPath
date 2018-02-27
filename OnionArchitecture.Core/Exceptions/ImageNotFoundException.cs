using System;
using System.Runtime.Serialization;

namespace OnionArchitecture.Core.Exceptions
{
    public class ImageNotFoundException : Exception
    {
        public ImageNotFoundException()
        {
        }

        public ImageNotFoundException(string message) : base(message)
        {
        }

        public ImageNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ImageNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}