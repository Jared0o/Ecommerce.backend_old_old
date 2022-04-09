using Ecommerce.Application.Interfaces;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Persistence.Repositories
{
    internal class CartRepository : BaseRepository<Cart>, ICartRepository
    {
        public CartRepository(EcommerceContext context) : base(context)
        {
        }

        public async Task AddProductToCartAsync(ProductVariant productVariant, Cart cart, int quantity)
        {
            await _context.CartProducts.AddAsync(new CartProducts(cart.Id, productVariant.Id, quantity));
            await _context.SaveChangesAsync();
        }

        public async Task<Cart> GetByUserIdAsync(int id)
        {
            var cart = await _context.Carts.FirstOrDefaultAsync(x => x.UserId == id);
            return cart;
        }
    }
}
