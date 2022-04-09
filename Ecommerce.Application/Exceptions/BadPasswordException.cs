namespace Ecommerce.Application.Exceptions
{
    public class BadPasswordException : ApplicationException
    {
        public BadPasswordException(string message) : base(message)
        {

        }
    }
}
