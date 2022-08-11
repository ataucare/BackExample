using System.Runtime.Serialization;

namespace Api.Core.Exceptions
{
    public class EmailSendedException : Exception
    {
        public EmailSendedException()
        {
        }

        public EmailSendedException(string message)
            : base(message)
        {
        }

        public EmailSendedException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected EmailSendedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
