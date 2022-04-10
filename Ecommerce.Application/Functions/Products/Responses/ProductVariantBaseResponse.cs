namespace Ecommerce.Application.Functions.Products.Responses
{
    public class ProductVariantBaseResponse
    {
        public ProductBaseDto Product { get; set; }
        public string VariantName { get; set; }
        public string? VariantDescription { get; set; }
        public int InStock { get; set; }
        public float Price { get; set; }
        public string? Sku { get; set; }
        public bool IsActive { get; set; }
        public bool IsDefault { get; set; }
    }
}
