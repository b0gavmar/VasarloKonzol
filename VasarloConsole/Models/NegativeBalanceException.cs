
namespace VasarloConsole.Models
{
    [Serializable]
    internal class NegativeBalanceException : Exception
    {
        public NegativeBalanceException()
        {
        }

        public NegativeBalanceException(string? message) : base(message)
        {
        }

        public NegativeBalanceException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}