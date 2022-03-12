using Ecommerce.Application.Functions.Taxes.Responses;
using MediatR;

namespace Ecommerce.Application.Functions.Taxes.Queries.GetTaxList
{
    public class GetTaxListQuery : IRequest<IReadOnlyList<TaxBaseDto>>
    {
    }
}
