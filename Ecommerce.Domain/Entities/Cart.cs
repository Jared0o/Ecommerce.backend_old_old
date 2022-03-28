using Ecommerce.Domain.Common;
using Ecommerce.Domain.Entities.Identity;

namespace Ecommerce.Domain.Entities
{
    public class Cart : AuditableEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public IEnumerable<CartProducts> ProductsInCart { get; set; }

        public Cart() {}

        public Cart(int userId)
        {
            UserId = userId;
        }
    }
}
