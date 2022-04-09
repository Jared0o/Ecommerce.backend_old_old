using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Api.Models.Taxes
{
    public class UpdateTaxDto
    {
        public string? Name { get; set; }
        public int? Value { get; set; }

    }
}
