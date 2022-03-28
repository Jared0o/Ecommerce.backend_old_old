using Ecommerce.Application.Functions.Carts.Responses;
using MediatR;

namespace Ecommerce.Application.Functions.Carts.Commands
{
    public class CreateCartCommand : IRequest<CartBaseResponse>
    {
        public string UserEmail { get; set; }
        public CreateCartCommand(string email)
        {
            UserEmail = email;
        }
    }
}
