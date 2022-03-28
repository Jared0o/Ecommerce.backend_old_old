namespace Ecommerce.Application.Functions.Brands.Responses
{
    public class BrandBaseResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
    }
}
