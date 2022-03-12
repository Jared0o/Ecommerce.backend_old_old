using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Domain.Entities.Identity
{
    public class Role : IdentityRole<int>
    {
        public virtual IEnumerable<UserRole> UserRoles { get; set; }
    }
}
