using Ecommerce.Domain.Common;
using Ecommerce.Domain.Entities.Identity;

namespace Ecommerce.Domain.Entities
{
    public class Order : AuditableEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int AdressId { get; set; }
        public Adress Adress { get; set; }

        public virtual IEnumerable<OrderProducts> Products { get; set; }
    }
}
