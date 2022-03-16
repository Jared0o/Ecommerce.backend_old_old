using AutoMapper;
using Ecommerce.Application.Exceptions;
using Ecommerce.Application.Functions.Users.Responses;
using Ecommerce.Application.Interfaces.Services;
using Ecommerce.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Application.Functions.Users.Commands.RegisterUser
{
    internal class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, UserBaseDto>
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly ITokenService _token;

        public RegisterUserCommandHandler(IMapper mapper, UserManager<User> userManager, ITokenService token)
        {
            _mapper = mapper;
            _userManager = userManager;
            _token = token;
        }

        public async Task<UserBaseDto> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var validator = new RegisterUserCommandValidator();
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validatorResult.IsValid)
                throw new ValidateException(validatorResult);

            var user = _mapper.Map<User>(request);
            user.UserName = request.Email;

            var registerResult = await _userManager.CreateAsync(user, request.Password);
            if (!registerResult.Succeeded)
                throw new UserRegisterException(registerResult.Errors);

            var resultRoles = await _userManager.AddToRoleAsync(user, BaseRoleEnum.User.ToString());

            if(!resultRoles.Succeeded)
                throw new UserRegisterException(resultRoles.Errors);

            var token = await _token.CreateTokenAsync(user);

            return new UserBaseDto { Email = user.Email, Name = user.FirstName + ' ' + user.LastName, Token = token };
        }
    }
}
