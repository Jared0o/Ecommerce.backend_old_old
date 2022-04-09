using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Api.Models.Categories
{
    public class UpdateCategoryDto
    {
        [Required]
        [MinLength(2)]
        [MaxLength(15)]
        public string Name { get; set; }
        [Required]
        [MaxLength(255)]
        public string Description { get; set; }
        [Required]
        public bool IsActive { get; set; }

    }
}
