namespace EKRLib
{
    /// <summary>
    /// Represents a class for the <see cref="EKRLib"/> library special exceptions.
    /// </summary>
    public sealed class TransportException : System.Exception
    {
        /// <summary>
        /// Initializes a new <see cref="TransportException"/> with empty message.
        /// </summary>
        public TransportException()
        {
        }

        /// <summary>
        /// Initializes a new <see cref="TransportException"/> with <paramref name="message"/> message.
        /// </summary>
        /// <param name="message">Exception message.</param>
        public TransportException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new <see cref="TransportException"/> with <paramref name="message"/> message
        /// and inner exception <paramref name="inner"/> for the stack trace.
        /// </summary>
        /// <param name="message">Exception message.</param>
        /// <param name="inner">Inner exception for the stack trace.</param>
        public TransportException(string message, System.Exception inner)
            : base(message, inner)
        {
        }
    }
}