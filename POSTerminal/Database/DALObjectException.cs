using System;
using System.Runtime.Serialization;

namespace POSTerminal.Database
{
    [Serializable]
    internal class DALObjectException : Exception
    {
        public DALObjectException()
        {
        }

        public DALObjectException(string message) : base(message)
        {
        }

        public DALObjectException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DALObjectException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}