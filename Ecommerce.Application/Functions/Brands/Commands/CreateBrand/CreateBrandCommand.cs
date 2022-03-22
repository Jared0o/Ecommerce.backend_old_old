using Ecommerce.Application.Functions.Brands.Responses;
using MediatR;

namespace Ecommerce.Application.Functions.Brands.Commands.CreateBrand
{
    public  class CreateBrandCommand : IRequest<BrandBaseResponse>
    {
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
