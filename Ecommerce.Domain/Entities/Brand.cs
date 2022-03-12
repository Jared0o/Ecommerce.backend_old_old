using Ecommerce.Domain.Common;

namespace Ecommerce.Domain.Entities
{
    public class Brand : AuditableEntity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
    }
}
