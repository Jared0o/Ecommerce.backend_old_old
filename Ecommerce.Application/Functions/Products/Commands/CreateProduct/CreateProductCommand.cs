using Ecommerce.Application.Functions.Products.Responses;
using MediatR;

namespace Ecommerce.Application.Functions.Products.Commands
{
    public class CreateProductCommand : IRequest<ProductBaseDto>
    {
        public string Name { get; set; }
        public int? TaxId { get; set; }
        public string? Description { get; set; }
        public int? BrandId { get; set; }
        public int? CategoryId { get; set; }

        public CreateProductCommand(string name, int? taxId, string? description, int? brandId, int? categoryId)
        {
            Name = name;
            TaxId = taxId;
            Description = description;
            BrandId = brandId;
            CategoryId = categoryId;
        }
    }
}
