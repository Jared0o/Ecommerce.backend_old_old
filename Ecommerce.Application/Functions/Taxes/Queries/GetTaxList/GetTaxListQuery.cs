using MediatR;

namespace Ecommerce.Application.Functions.Taxes.Queries.GetTaxList
{
    public class GetTaxListQuery : IRequest<IReadOnlyList<GetTaxListQueryResponse>>
    {
    }
}
