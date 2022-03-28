using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Interfaces
{
    public interface ICartRepository : IBaseRepository<Cart>
    {
        public Task<Cart> GetByUserIdAsync(int id);
    }
}
