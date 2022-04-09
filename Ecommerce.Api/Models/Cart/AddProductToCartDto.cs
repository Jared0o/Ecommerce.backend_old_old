using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Api.Models.Cart
{
    public class AddProductToCartDto
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int ProductVariantId { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
