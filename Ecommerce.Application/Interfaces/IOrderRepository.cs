using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Entities.Identity;

namespace Ecommerce.Application.Interfaces
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        public Task<Order> CreateOrderFromCartAsync(int cartId, int adressId);
        public Task<IReadOnlyList<Order>> GetUserOrdersAsync(int userId);
        public Task<Order> GetUserOrderAsync(int userId, int orderId);
    }
}
