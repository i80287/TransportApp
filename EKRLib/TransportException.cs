using System;
using System.Runtime.Serialization;

namespace EKRLib
{
    /// <summary>
    /// Represents a class for the <see cref="EKRLib"/> library special exceptions.
    /// </summary>
    public class TransportException : Exception
    {
        /// <summary>
        /// Initializes a new <see cref="TransportException"/> with empty message.
        /// </summary>
        public TransportException()
            : base()
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
        public TransportException(string message, Exception inner)
            : base(message, inner)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TransportException"/> class with serialized data.
        /// </summary>
        /// <param name="info">
        /// The System.Runtime.Serialization.SerializationInfo that holds
        /// the serialized object data about the exception being thrown.
        /// </param>
        /// <param name="context">
        /// The System.Runtime.Serialization.StreamingContext that contains
        /// contextual information about the source or destination.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if info is null.
        /// </exception>
        /// <exception cref="SerializationException">
        /// Thrown if the class name is null or <see cref="Exception.HResult"/> is zero (0).
        /// </exception>
        protected TransportException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
