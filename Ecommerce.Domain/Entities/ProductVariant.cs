using Ecommerce.Domain.Common;

namespace Ecommerce.Domain.Entities
{
    public class ProductVariant : AuditableEntity
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public string VariantName { get; set; }
        public string? VariantDescription { get; set; }
        public int InStock { get; set; }
        public float Price { get; set; }
        public string? Sku { get; set; }
        public bool IsActive { get; set; }
        public bool IsDefault{ get; set; }


        //For EFCORE
        public ProductVariant()
        {

        }



        public ProductVariant(int productId, string variantName, string variantDescription, bool isActive)
        {
            ProductId = productId;
            VariantName = variantName;
            VariantDescription = variantDescription;
            IsActive = isActive;
        }
    }
}
