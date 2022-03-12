using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
