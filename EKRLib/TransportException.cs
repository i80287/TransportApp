namespace EKRLib
{
    public sealed class TransportException : System.Exception
    {
        public TransportException()
        {
        }

        public TransportException(string message)
            : base(message)
        {
        }

        public TransportException(string message, System.Exception inner)
            : base(message, inner)
        {
        }
    }
}