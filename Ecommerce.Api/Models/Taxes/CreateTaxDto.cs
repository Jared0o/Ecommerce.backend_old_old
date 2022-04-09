using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Api.Models.Taxes
{
    public class CreateTaxDto
    {
        [Required]
        [MinLength(2)]
        [MaxLength(10)]
        public string Name { get; set; }
        [Required]
        public int Value { get; set; }
    }
}
