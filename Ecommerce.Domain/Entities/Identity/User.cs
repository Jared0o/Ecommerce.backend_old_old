using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Domain.Entities.Identity
{
    public class User : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual IEnumerable<UserRole> UserRoles { get; set; }
        public virtual IEnumerable<Adress> Adresses { get; set; }
        public virtual IEnumerable<Order> Orders { get; set; } 
    }
}
