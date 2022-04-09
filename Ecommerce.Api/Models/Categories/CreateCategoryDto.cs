using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Api.Models.Categories
{
    public class CreateCategoryDto
    {
        [Required]
        [MinLength(2)]
        [MaxLength(15)]
        public string Name { get; set; }
        [MaxLength(250)]
        public string? Description { get; set; }
    }
}
