namespace QuickLink.Application.Exceptions
{
    public sealed class InvalidUrlException : Exception
    {
        public InvalidUrlException(string message) : base(message) { }
    }
}
