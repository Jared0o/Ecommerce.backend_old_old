using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Entities.Identity;

namespace Ecommerce.Application.Interfaces
{
    public interface IAdressRepository : IBaseRepository<Adress>
    {
        Task<IReadOnlyList<Adress>> GetUserAdressesAsync(User user);
        Task<Adress> GetUserAdresssByIdAsync(User user, int adressId);
    }
}
