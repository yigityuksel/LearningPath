using System;
using System.Runtime.Serialization;

namespace OnionArchitecture.Core.Exceptions
{
    public class PasswordUsedBeforeException : Exception
    {
        public PasswordUsedBeforeException()
        {
        }

        public PasswordUsedBeforeException(string message) : base(message)
        {
        }

        public PasswordUsedBeforeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected PasswordUsedBeforeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}