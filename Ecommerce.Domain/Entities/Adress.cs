using Ecommerce.Domain.Common;
using Ecommerce.Domain.Entities.Identity;

namespace Ecommerce.Domain.Entities
{
    public class Adress : AuditableEntity
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string ZipCode { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
