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
        public int Quantity { get; set; }

        //For EFCORE
        public OrderProducts()
        {

        }
        public OrderProducts(int orderId, Order order, int productVariantId, ProductVariant productVariant, float price, int taxValue, int quantity)
        {
            OrderId = orderId;
            Order = order;
            ProductVariantId = productVariantId;
            ProductVariant = productVariant;
            Price = price;
            TaxValue = taxValue;
            Quantity = quantity;
        }
    }
}
