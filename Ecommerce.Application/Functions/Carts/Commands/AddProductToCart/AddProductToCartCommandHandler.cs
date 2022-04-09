using AutoMapper;
using Ecommerce.Application.Exceptions;
using Ecommerce.Application.Functions.Carts.Responses;
using Ecommerce.Application.Interfaces;
using Ecommerce.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Application.Functions.Carts.Commands.AddProductToCart
{
    internal class AddProductToCartCommandHandler : IRequestHandler<AddProductToCartCommand, CartBaseResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICartRepository _cartRepository;
        private readonly UserManager<User> _userManager;
        private readonly IProductRepository _productRepository;
        private readonly IProductVariantRepository _productVariantRepository;

        public AddProductToCartCommandHandler(IMapper mapper, ICartRepository cartRepository, ICartProductsRepository cartProductsRepository, UserManager<User> userManager, IProductRepository productRepository, IProductVariantRepository productVariantRepository)
        {
            _mapper = mapper;
            _cartRepository = cartRepository;
            _userManager = userManager;
            _productRepository = productRepository;
            _productVariantRepository = productVariantRepository;
        }
        public async Task<CartBaseResponse> Handle(AddProductToCartCommand request, CancellationToken cancellationToken)
        {
            var validator = new AddProductToCartCommandValidator();
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validatorResult.IsValid)
                throw new ValidateException(validatorResult);

            var user = await _userManager.FindByEmailAsync(request.UserEmail);
            if (user == null)
                throw new AuthenticationByEmailException($"Not find user with Email: {request.UserEmail} try log in again");

            var cart = await _cartRepository.GetByUserIdAsync(user.Id);

            var product = await _productRepository.GetByIdAsync(request.ProductId);
            if (product == null)
                throw new NotFindException($"Product with id not exist {request.ProductId}");

            var productVariant = await _productVariantRepository.GetByIdAsync(request.ProductVariantId);
            if(productVariant == null)
                throw new NotFindException($"Not find variant for product Id {request.ProductId}");

            if (productVariant.ProductId != product.Id)
                throw new VariantNotForProductException($"Variant {productVariant.VariantName} is not for product {product.Name}");

            if (productVariant.InStock == 0 && productVariant.InStock < request.Quantity)
                throw new NotInStockException("To little stock");

            await _cartRepository.AddProductToCartAsync(productVariant, cart, request.Quantity);

            var response = await _cartRepository.GetByUserIdAsync(user.Id);

            return _mapper.Map<CartBaseResponse>(response);

        }
    }
}
