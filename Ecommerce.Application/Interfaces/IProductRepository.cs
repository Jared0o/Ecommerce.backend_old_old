using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Interfaces
{
    public interface IProductRepository : IAsyncRepository<Product>
    {
    }
}
