using Ecommerce.Application.Interfaces;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Persistence.Repositories
{
    internal class BrandRepository : BaseRepository<Brand>, IBrandRepository
    {
        public BrandRepository(EcommerceContext context) : base(context)
        {
        }
    }
}
