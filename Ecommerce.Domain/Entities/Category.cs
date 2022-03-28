using Ecommerce.Domain.Common;

namespace Ecommerce.Domain.Entities
{
    public class Category : AuditableEntity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public int? ParentCategoryId { get; set; }
        public Category? ParentCategory { get; set; }

        public virtual IEnumerable<Product> Products { get; set; }
        public virtual IEnumerable<Category> ChildCategories { get; set; }

    }
}
