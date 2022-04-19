using Ecommerce.Application.Functions.Orders.Responses;
using MediatR;

namespace Ecommerce.Application.Functions.Orders.Queries.GetUserOrdersList
{
    public class GetUserOrdersQuery : IRequest<IReadOnlyList<OrderBaseResponse>>
    {
        public string UserEmail { get; set; }

        public GetUserOrdersQuery(string userEmail)
        {
            UserEmail = userEmail;
        }
    }
}
