using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Functions.Carts.Responses
{
    public class CartBaseResponse
    {
        public int Id { get; set; }
        public IReadOnlyList<CartProductsBaseResponse> ProductsInCart { get; set; }
    }
}
