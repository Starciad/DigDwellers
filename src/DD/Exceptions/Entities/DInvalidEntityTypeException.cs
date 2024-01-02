using System;

namespace DD.Exceptions.Entities
{
    internal class DInvalidEntityTypeException : Exception
    {
        public DInvalidEntityTypeException(string message) : base(message)
        {
        }

        public DInvalidEntityTypeException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
