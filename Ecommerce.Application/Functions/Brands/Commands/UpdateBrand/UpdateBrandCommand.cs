using Ecommerce.Application.Functions.Brands.Responses;
using MediatR;

namespace Ecommerce.Application.Functions.Brands.Commands.UpdateBrand
{
    public class UpdateBrandCommand : IRequest<BrandBaseResponse>
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool? IsActive { get; set; }
    }
}
