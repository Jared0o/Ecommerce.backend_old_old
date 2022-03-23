using Ecommerce.Application.Functions.Brands.Responses;
using MediatR;

namespace Ecommerce.Application.Functions.Brands.Queries.GetBrands
{
    public class GetBrandsListQuery : IRequest<IReadOnlyList<BrandBaseResponse>>
    {
    }
}
