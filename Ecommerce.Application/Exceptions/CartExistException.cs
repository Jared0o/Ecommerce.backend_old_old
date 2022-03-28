namespace Ecommerce.Application.Exceptions
{
    public class CartExistException : ApplicationException
    {
        public CartExistException(string message) : base(message)
        {

        }
    }
}
