using System;
using System.Runtime.Serialization;

namespace OnionArchitecture.Core.Exceptions
{
    public class LinkExpiredException : Exception
    {
        public LinkExpiredException()
        {
        }

        public LinkExpiredException(string message) : base(message)
        {
        }

        public LinkExpiredException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected LinkExpiredException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}