namespace Ecommerce.Api.Models.Products
{
    public class UpdateProductDto
    {
        public string? Name { get; set; }
        public int? TaxId { get; set; }
        public string? Description { get; set; }
        public int? BrandId { get; set; }
        public int? CategoryId { get; set; }
        public bool? IsActive { get; set; }
    }
}
