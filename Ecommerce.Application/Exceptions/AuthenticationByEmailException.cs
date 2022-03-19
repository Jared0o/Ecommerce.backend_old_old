using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Exceptions
{
    public class AuthenticationByEmailException : ApplicationException
    {
        public AuthenticationByEmailException(string message) : base(message)
        {
        }
    }
}
