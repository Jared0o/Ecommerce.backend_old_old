using Ecommerce.Application.Functions.Users.Responses;
using MediatR;

namespace Ecommerce.Application.Functions.Auth.Queries.LoginUser
{
    public class LoginUserQuery : IRequest<UserBaseDto> 
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public LoginUserQuery(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
