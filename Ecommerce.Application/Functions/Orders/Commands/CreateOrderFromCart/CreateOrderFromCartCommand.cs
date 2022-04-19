using Ecommerce.Application.Functions.Orders.Responses;
using MediatR;

namespace Ecommerce.Application.Functions.Orders.Commands.CreateOrderFromCart
{
    public class CreateOrderFromCartCommand : IRequest<OrderBaseResponse>
    {
        public string UserEmail { get; set; }
        public int AdressId { get; set; }

        public CreateOrderFromCartCommand(string userEmail, int adressId)
        {
            UserEmail = userEmail;
            AdressId = adressId;
        }
    }

}
