using Ecommerce.Domain.Common;

namespace Ecommerce.Domain.Entities
{
    public class OrderProducts : AuditableEntity
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int ProductVariantId { get; set; }
        public ProductVariant ProductVariant { get; set; }
        public float Price { get; set; }
        public int TaxValue { get; set; }
        public int quantity { get; set; }
    }
}
