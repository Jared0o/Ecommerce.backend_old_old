namespace Ecommerce.Application.Exceptions
{
    public class ItemExistException : ApplicationException
    {
        public ItemExistException(string message) : base(message)
        {

        }
    }
}
