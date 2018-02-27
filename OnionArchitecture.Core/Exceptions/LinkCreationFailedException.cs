using System;
using System.Runtime.Serialization;

namespace OnionArchitecture.Core.Exceptions
{
    public class LinkCreationFailedException : Exception
    {
        public LinkCreationFailedException()
        {
        }

        public LinkCreationFailedException(string message) : base(message)
        {
        }

        public LinkCreationFailedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected LinkCreationFailedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}