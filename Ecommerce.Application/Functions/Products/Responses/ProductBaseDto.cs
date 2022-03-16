namespace Ecommerce.Application.Functions.Products.Responses
{
    public class ProductBaseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public int? TaxId { get; set; }
        public string? Description { get; set; }
        public int? BrandId { get; set; }
        public bool IsActive { get; set; }
        public int? CategoryId { get; set; }
    }
}
