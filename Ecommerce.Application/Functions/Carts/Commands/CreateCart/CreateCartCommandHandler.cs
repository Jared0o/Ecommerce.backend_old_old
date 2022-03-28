using AutoMapper;
using Ecommerce.Application.Exceptions;
using Ecommerce.Application.Functions.Carts.Responses;
using Ecommerce.Application.Interfaces;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Application.Functions.Carts.Commands
{
    public class CreateCartCommandHandler : IRequestHandler<CreateCartCommand, CartBaseResponse>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public CreateCartCommandHandler(ICartRepository cartRepository, IMapper mapper, UserManager<User> userManager)
        {
            _cartRepository = cartRepository;
            _mapper = mapper;
            _userManager = userManager;
        }
        public async Task<CartBaseResponse> Handle(CreateCartCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateCartCommandValidator();
            var validatorResult = await validator.ValidateAsync(request);
            if (!validatorResult.IsValid)
                throw new ValidateException(validatorResult);

            var user = await _userManager.FindByEmailAsync(request.UserEmail);

            if (user == null)
                throw new AuthenticationByEmailException($"Not Find User With Email {request.UserEmail}");

            var cart = await _cartRepository.GetByUserIdAsync(user.Id);

            if (cart != null)
                throw new CartExistException($"Cart For user {request.UserEmail} exists");

            var newUsercart = await _cartRepository.AddAsync(new Cart(user.Id));

            var response = _mapper.Map<CartBaseResponse>(newUsercart);

            return response;
        }
    }
}
