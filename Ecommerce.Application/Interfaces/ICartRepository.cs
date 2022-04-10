using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Entities.Identity;

namespace Ecommerce.Application.Interfaces
{
    public interface ICartRepository : IBaseRepository<Cart>
    {
        public Task<Cart> GetByUserIdAsync(int id);
        public Task AddProductToCartAsync(ProductVariant productVariant, Cart cart, int quantity);
        public Task DeleteProductsInCartAsync(int cartId);
    }
}
