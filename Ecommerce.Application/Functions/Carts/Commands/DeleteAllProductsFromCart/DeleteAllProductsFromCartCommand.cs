using Ecommerce.Application.Functions.Carts.Responses;
using MediatR;

namespace Ecommerce.Application.Functions.Carts.Commands.DeleteAllProductsFromCart
{
    public class DeleteAllProductsFromCartCommand : IRequest<CartBaseResponse>
    {
        public string UserEmail { get; set; }

        public DeleteAllProductsFromCartCommand(string userEmail)
        {
            UserEmail = userEmail;
        }
    }


}
