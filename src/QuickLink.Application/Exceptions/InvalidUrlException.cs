namespace QuickLink.Application.Exceptions
{
    public sealed class InvalidUrlException(string message) : Exception(message)
    {
    }
}
