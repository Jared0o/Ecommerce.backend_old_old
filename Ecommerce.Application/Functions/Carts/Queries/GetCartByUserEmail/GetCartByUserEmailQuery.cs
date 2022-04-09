using Ecommerce.Application.Functions.Carts.Responses;
using MediatR;

namespace Ecommerce.Application.Functions.Carts.Queries.GetCartByUserEmail
{
    public class GetCartByUserEmailQuery : IRequest<CartBaseResponse>
    {
        public string UserEmail { get; set; }

        public GetCartByUserEmailQuery(string userEmail)
        {
            UserEmail = userEmail;
        }
    }
}
