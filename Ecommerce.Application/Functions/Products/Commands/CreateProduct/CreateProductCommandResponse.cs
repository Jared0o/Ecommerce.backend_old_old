using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Functions.Products.Commands
{
    public class CreateProductCommandResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public int TaxId { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public string Sku { get; set; }
        public string Brand { get; set; }
        public string isDisable { get; set; }
    }
}