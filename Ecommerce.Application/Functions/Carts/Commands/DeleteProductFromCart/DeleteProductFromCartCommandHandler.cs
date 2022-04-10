using AutoMapper;
using Ecommerce.Application.Exceptions;
using Ecommerce.Application.Functions.Carts.Responses;
using Ecommerce.Application.Interfaces;
using Ecommerce.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Application.Functions.Carts.Commands.DeleteProductFromCart
{
    internal class DeleteProductFromCartCommandHandler : IRequestHandler<DeleteProductFromCartCommand, CartBaseResponse>
    {
        private readonly ICartRepository _cartRepository;
        private readonly ICartProductsRepository _cartProductsRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public DeleteProductFromCartCommandHandler(ICartRepository cartRepository, ICartProductsRepository cartProductsRepository, IMapper mapper, UserManager<User> userManager)
        {
            _cartRepository = cartRepository;
            _cartProductsRepository = cartProductsRepository;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<CartBaseResponse> Handle(DeleteProductFromCartCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteProductFromCartCommandValidator();
            var validatorResult = await validator.ValidateAsync(request);
            if (!validatorResult.IsValid)
                throw new ValidateException(validatorResult);

            var user = await _userManager.FindByEmailAsync(request.UserEmail);
            if (user == null)
                throw new AuthenticationByEmailException($"Not find user with Email: {request.UserEmail} lets try log in again");

            var cart = await _cartRepository.GetByUserIdAsync(user.Id);

            var productInCart = await _cartProductsRepository.GetByIdAsync(request.CartProductId);

            if (productInCart == null || productInCart.CartId != cart.Id)
                throw new NotFindException($"Not find this product in your cart.");

            productInCart.Quantity -= 1;

            if(productInCart.Quantity <= 0)
                await _cartProductsRepository.DeleteAsync(productInCart);
            else
                await _cartProductsRepository.UpdateAsync(productInCart);


            cart = await _cartRepository.GetByUserIdAsync(user.Id);

            return _mapper.Map<CartBaseResponse>(cart);

        }
    }
}
