using Ecommerce.Application.Functions.Carts.Responses;
using MediatR;

namespace Ecommerce.Application.Functions.Carts.Commands.AddProductToCart
{
    public class AddProductToCartCommand : IRequest<CartBaseResponse>
    {
        public string UserEmail { get; set; }
        public int ProductId { get; set; }
        public int ProductVariantId { get; set; }
        public int Quantity { get; set; }

        public AddProductToCartCommand(string userEmail, int productId, int productVariantId, int quantity)
        {
            UserEmail = userEmail;
            ProductId = productId;
            ProductVariantId = productVariantId;
            Quantity = quantity;
        }
    }
}
