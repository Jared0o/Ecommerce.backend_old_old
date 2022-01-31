using Ecommerce.Domain.Common;

namespace Ecommerce.Domain.Entities
{
    public class Product : AuditableEntity
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public Tax Tax { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public string Sku { get; set; }
        public string Brand { get; set; }
        public bool isDisable { get; set; }

        //Listy
        public IEnumerable<ProductCategory> ProductCategories  { get; set; }
    }
}
