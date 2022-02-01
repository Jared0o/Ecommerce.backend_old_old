using Ecommerce.Domain.Common;

namespace Ecommerce.Domain.Entities
{
    public class ProductCategory : AuditableEntity
    {
        public Category Category { get; set; }
        public Product Product { get; set; }
    }
}
