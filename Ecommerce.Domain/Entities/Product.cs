using Ecommerce.Domain.Common;

namespace Ecommerce.Domain.Entities
{
    public class Product : AuditableEntity
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public int? TaxId { get; set; }
        public Tax? Tax { get; set; }

        public string? Description { get; set; }
        public int? BrandId { get; set; }
        public Brand? Brand { get; set; }
        public bool IsActive { get; set; }
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        public IEnumerable<ProductVariant> Variants { get; set; }
    }
}
