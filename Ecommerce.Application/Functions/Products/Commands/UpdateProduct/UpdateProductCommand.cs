using Ecommerce.Application.Functions.Products.Responses;
using MediatR;

namespace Ecommerce.Application.Functions.Products.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest<ProductBaseDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? TaxId { get; set; }
        public string? Description { get; set; }
        public int? BrandId { get; set; }
        public int? CategoryId { get; set; }
        public bool IsActive { get; set; }
    }
}
