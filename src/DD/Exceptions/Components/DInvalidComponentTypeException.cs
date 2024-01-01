using System;

namespace DD.Exceptions.Components
{
    internal sealed class DInvalidComponentTypeException : Exception
    {
        internal DInvalidComponentTypeException()
        {
        }

        internal DInvalidComponentTypeException(string message)
            : base(message)
        {
        }

        internal DInvalidComponentTypeException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
