using Ecommerce.Domain.Common;

namespace Ecommerce.Domain.Entities
{
    public class CategoryInCategory : AuditableEntity
    {
        public int ParentCategoryId { get; set; }
        public Category ParentCategory { get; set; }
        public int SubcategoryId { get; set; }
        public Category Subcategory { get; set; }
    }
}
