using System;
using System.Runtime.Serialization;

namespace OnionArchitecture.Core.Exceptions
{
    public class SameUserNameExistException : Exception
    {
        public SameUserNameExistException()
        {
        }

        public SameUserNameExistException(string message) : base(message)
        {
        }

        public SameUserNameExistException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected SameUserNameExistException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}