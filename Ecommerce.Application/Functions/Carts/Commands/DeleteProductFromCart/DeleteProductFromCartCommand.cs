using Ecommerce.Application.Functions.Carts.Responses;
using MediatR;

namespace Ecommerce.Application.Functions.Carts.Commands.DeleteProductFromCart
{
    public class DeleteProductFromCartCommand : IRequest<CartBaseResponse>
    {
        public int CartProductId { get; set; }
        public string UserEmail { get; set; }

        public DeleteProductFromCartCommand(int cartProductId, string userEmail)
        {
            CartProductId = cartProductId;
            UserEmail = userEmail;
        }
    }
}
