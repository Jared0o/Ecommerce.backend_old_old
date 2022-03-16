using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Application.Exceptions
{
    public class UserRegisterException : ApplicationException
    {
        public IEnumerable<IdentityError> Errors;

        public UserRegisterException(IEnumerable<IdentityError> errors)
        {
            Errors = errors;
        }
    }
}
