using System;

namespace DD.Exceptions.Components
{
    internal sealed class DDuplicateComponentsException : Exception
    {
        internal DDuplicateComponentsException()
        {
        }

        internal DDuplicateComponentsException(string message)
            : base(message)
        {
        }

        internal DDuplicateComponentsException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
