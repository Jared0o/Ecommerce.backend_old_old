using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Exceptions
{
    public class NotInStockException : ApplicationException
    {
        
        public NotInStockException(string message) : base(message)
        {

        }
    }
}
