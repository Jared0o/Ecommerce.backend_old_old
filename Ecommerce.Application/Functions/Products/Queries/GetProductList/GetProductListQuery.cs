using Ecommerce.Application.Functions.Products.Responses;
using MediatR;

namespace Ecommerce.Application.Functions.Products.Queries.GetProductList
{
    public class GetProductListQuery : IRequest<IReadOnlyList<ProductBaseDto>>
    {
    }
}
