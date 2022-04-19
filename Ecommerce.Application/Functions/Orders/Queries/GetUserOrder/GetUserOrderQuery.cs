using Ecommerce.Application.Functions.Orders.Responses;
using MediatR;

namespace Ecommerce.Application.Functions.Orders.Queries.GetUserOrder
{
    public class GetUserOrderQuery : IRequest<OrderBaseResponse>
    {
        public string UserEmail { get; set; }
        public int OrderId { get; set; }

        public GetUserOrderQuery(string userEmail, int orderId)
        {
            UserEmail = userEmail;
            OrderId = orderId;
        }
    }
}
