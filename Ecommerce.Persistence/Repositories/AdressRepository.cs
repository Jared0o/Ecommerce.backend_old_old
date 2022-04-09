using Ecommerce.Application.Interfaces;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Persistence.Repositories
{
    internal class AdressRepository : BaseRepository<Adress>, IAdressRepository
    {
        public AdressRepository(EcommerceContext context) : base(context)
        {
        }

        public async Task<IReadOnlyList<Adress>> GetUserAdressesAsync(User user)
        {
            var userAdresses = await _context.Adresses.Where(x=> x.UserId == user.Id).ToListAsync();
            return userAdresses;
        }

        public async Task<Adress> GetUserAdresssByIdAsync(User user, int adressId)
        {
            var userAdress = await _context.Adresses.Where(x => x.UserId == user.Id).FirstOrDefaultAsync(x => x.Id == adressId);
            return userAdress;
        }
    }
}
