namespace Ecommerce.Application.Exceptions
{
    public class NotFindException : ApplicationException
    {
        public NotFindException(string? message) : base(message)
        {
        }
    }
}
