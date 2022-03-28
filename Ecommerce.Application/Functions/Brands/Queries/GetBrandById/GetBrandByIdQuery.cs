using Ecommerce.Application.Functions.Brands.Responses;
using MediatR;

namespace Ecommerce.Application.Functions.Brands.Queries.GetBrandById
{
    public class GetBrandByIdQuery : IRequest<BrandBaseResponse>
    {
        public int Id { get; set; }
        public GetBrandByIdQuery(int id)
        {
            Id = id;
        }
    }
}
