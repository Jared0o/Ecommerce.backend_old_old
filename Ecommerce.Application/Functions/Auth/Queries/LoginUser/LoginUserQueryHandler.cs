using Ecommerce.Application.Exceptions;
using Ecommerce.Application.Functions.Users.Responses;
using Ecommerce.Application.Interfaces.Services;
using Ecommerce.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Application.Functions.Auth.Queries.LoginUser
{
    public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, UserBaseDto>
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ITokenService _tokenService;

        public LoginUserQueryHandler(UserManager<User> userManager, SignInManager<User> signInManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }
        public async Task<UserBaseDto> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
            var validator = new LoginUserQueryValidator();
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validatorResult.IsValid)
                throw new ValidateException(validatorResult);

            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
                throw new AuthenticationByEmailException($"Not find user with Email {request.Email}");

            var checkPassword = await _signInManager.CheckPasswordSignInAsync(user, request.Password, true);
            if (checkPassword.IsLockedOut)
                throw new BadPasswordException("Account was blocked, please try again later or contact with us aa@aa.com.pl");

            if (!checkPassword.Succeeded)
                throw new BadPasswordException("Password is incorrect");

            var token = await _tokenService.CreateTokenAsync(user);

            return new UserBaseDto(user.Email, token, user.FirstName + " " + user.LastName);
        }
    }
}
