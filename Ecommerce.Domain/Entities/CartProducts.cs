using Ecommerce.Domain.Common;

namespace Ecommerce.Domain.Entities
{
    public class CartProducts : AuditableEntity
    {
        public int CartId { get; set; }
        public Cart Cart { get; set; }
        public int ProductVariantId { get; set; }
        public ProductVariant ProductVariant { get; set; }
        public int Quantity { get; set; }

        //For EFCORE
        public CartProducts()
        {
                
        }
        public CartProducts(int cartId, int productVariantId, int quantity)
        {
            CartId = cartId;
            ProductVariantId = productVariantId;
            Quantity = quantity;
        }
    }
}
