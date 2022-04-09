using Ecommerce.Application.Functions.Users.Responses;
using MediatR;

namespace Ecommerce.Application.Functions.Users.Commands.RegisterUser
{
    public class RegisterUserCommand : IRequest<UserBaseDto>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
