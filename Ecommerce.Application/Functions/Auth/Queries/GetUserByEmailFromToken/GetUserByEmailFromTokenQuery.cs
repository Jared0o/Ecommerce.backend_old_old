using Ecommerce.Application.Functions.Users.Responses;
using MediatR;

namespace Ecommerce.Application.Functions.Auth.Queries.GetUserByEmailFromToken
{
    public class GetUserByEmailFromTokenQuery : IRequest<UserBaseDto>
    {
        public string Email { get; set; }

        public GetUserByEmailFromTokenQuery(string email)
        {
            Email = email;
        }
    }
}
