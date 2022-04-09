using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Api.Models.Products
{
    public class CreateProductDto
    {
        [Required]
        public string Name { get; set; }
        public int? TaxId { get; set; }
        [MaxLength(255)]
        public string? Description { get; set; }
        public int? BrandId { get; set; }
        public int? CategoryId { get; set; }
    }
}
