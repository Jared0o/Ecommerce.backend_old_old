using Ecommerce.Application.Interfaces;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Entities.Identity;

namespace Ecommerce.Persistence.Repositories
{
    internal class AdressRepository : BaseRepository<Adress>, IAdressRepository
    {
        public AdressRepository(EcommerceContext context) : base(context)
        {
        }

        public Task<IReadOnlyList<Adress>> GetUserAdressesAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<Adress> GetUserAdresssByIdAsync(User user, int adressId)
        {
            throw new NotImplementedException();
        }
    }
}
