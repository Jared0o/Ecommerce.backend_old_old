using Ecommerce.Domain.Common;

namespace Ecommerce.Domain.Entities
{
    public class Tax : AuditableEntity
    {
        public string Name { get; set; }
        public int Value { get; set; }
    }
}