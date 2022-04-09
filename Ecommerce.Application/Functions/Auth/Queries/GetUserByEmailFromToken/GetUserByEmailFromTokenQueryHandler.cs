using Ecommerce.Application.Exceptions;
using Ecommerce.Application.Functions.Users.Responses;
using Ecommerce.Application.Interfaces.Services;
using Ecommerce.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Application.Functions.Auth.Queries.GetUserByEmailFromToken
{
    public class GetUserByEmailFromTokenQueryHandler : IRequestHandler<GetUserByEmailFromTokenQuery, UserBaseDto>
    {
        private readonly UserManager<User> _userManager;
        private readonly ITokenService _tokenService;

        public GetUserByEmailFromTokenQueryHandler(UserManager<User> userManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        public async Task<UserBaseDto> Handle(GetUserByEmailFromTokenQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetUserByEmailFromTokenQueryValidator();
            var validatorResult = await validator.ValidateAsync(request);
            if (!validatorResult.IsValid)
                throw new ValidateException(validatorResult);

            var user = await _userManager.FindByEmailAsync(request.Email);

            var token = await _tokenService.CreateTokenAsync(user);

            return new UserBaseDto(user.Email, token, user.FirstName + " " + user.LastName);
        }
    }
}
