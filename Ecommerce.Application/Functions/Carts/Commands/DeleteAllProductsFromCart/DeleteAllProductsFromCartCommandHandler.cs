using AutoMapper;
using Ecommerce.Application.Exceptions;
using Ecommerce.Application.Functions.Carts.Responses;
using Ecommerce.Application.Interfaces;
using Ecommerce.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Application.Functions.Carts.Commands.DeleteAllProductsFromCart
{
    public class DeleteAllProductsFromCartCommandHandler : IRequestHandler<DeleteAllProductsFromCartCommand, CartBaseResponse>
    {
        private readonly ICartRepository _cartRepository;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public DeleteAllProductsFromCartCommandHandler(ICartRepository cartRepository, UserManager<User> userManager, IMapper mapper)
        {
            _cartRepository = cartRepository;
            _userManager = userManager;
            _mapper = mapper;
        }
        public async Task<CartBaseResponse> Handle(DeleteAllProductsFromCartCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteAllProductsFromCartCommandValidator();
            var validatorResult = await validator.ValidateAsync(request);
            if (!validatorResult.IsValid)
                throw new ValidateException(validatorResult);

            var user = await _userManager.FindByEmailAsync(request.UserEmail);
            if (user == null)
                throw new AuthenticationByEmailException($"Not find user with Email: {request.UserEmail} log in again");

            var cart = await _cartRepository.GetByUserIdAsync(user.Id);

            await _cartRepository.DeleteProductsInCartAsync(cart.Id);

            cart = await _cartRepository.GetByUserIdAsync(user.Id);

            return _mapper.Map<CartBaseResponse>(cart);
        }
    }
}
