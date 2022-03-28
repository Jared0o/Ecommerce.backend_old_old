using Ecommerce.Application.Interfaces;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Persistence.Repositories
{
    internal class OrderProductRepository : BaseRepository<OrderProducts>, IOrderProductsRepository
    {
        public OrderProductRepository(EcommerceContext context) : base(context)
        {
        }
    }
}
