using System;
using System.Runtime.Serialization;

namespace GS.Tools
{
    [Serializable]
    internal class LogException : Exception
    {
        public LogException()
        {
        }

        public LogException(string message) : base(message)
        {
        }

        public LogException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected LogException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}