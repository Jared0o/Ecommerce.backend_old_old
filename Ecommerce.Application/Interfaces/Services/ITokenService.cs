using Ecommerce.Domain.Entities.Identity;

namespace Ecommerce.Application.Interfaces.Services
{
    public interface ITokenService
    {
        public Task<string> CreateTokenAsync(User user);
    }
}
