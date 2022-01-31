using Ecommerce.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Entities
{
    public class ProductCategory : AuditableEntity
    {
        public Category Category { get; set; }
        public Product Product { get; set; }
    }
}
