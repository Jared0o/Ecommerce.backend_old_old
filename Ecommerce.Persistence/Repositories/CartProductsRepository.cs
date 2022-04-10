using Ecommerce.Application.Interfaces;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Persistence.Repositories
{
    internal class CartProductsRepository : BaseRepository<CartProducts>, ICartProductsRepository
    {
        public CartProductsRepository(EcommerceContext context) : base(context)
        {
            
        }
        

    }
}
