using Ecommerce.Application.Interfaces;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Persistence.Repositories
{
    internal class CartRepository : BaseRepository<Cart>, ICartRepository
    {
        public CartRepository(EcommerceContext context) : base(context)
        {
        }

        public Task<Cart> GetByUserIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
