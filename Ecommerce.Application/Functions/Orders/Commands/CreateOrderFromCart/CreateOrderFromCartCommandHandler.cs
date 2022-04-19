using AutoMapper;
using Ecommerce.Application.Exceptions;
using Ecommerce.Application.Functions.Orders.Responses;
using Ecommerce.Application.Interfaces;
using Ecommerce.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Application.Functions.Orders.Commands.CreateOrderFromCart
{
    internal class CreateOrderFromCartCommandHandler : IRequestHandler<CreateOrderFromCartCommand, OrderBaseResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICartRepository _cartRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IAdressRepository _adressRepository;
        private readonly UserManager<User> _userManager;

        public CreateOrderFromCartCommandHandler(IMapper mapper, ICartRepository cartRepository, IOrderRepository orderRepository, IAdressRepository adressRepository, UserManager<User> userManager)
        {
            _mapper = mapper;
            _cartRepository = cartRepository;
            _orderRepository = orderRepository;
            _adressRepository = adressRepository;
            _userManager = userManager;
        }
        public async Task<OrderBaseResponse> Handle(CreateOrderFromCartCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateOrderFromCartCommandValidator();
            var validatorResult = await validator.ValidateAsync(request);
            if (!validatorResult.IsValid)
                throw new ValidateException(validatorResult);

            var user = await _userManager.FindByEmailAsync(request.UserEmail);
            if (user == null)
                throw new AuthenticationByEmailException("Not find user, lets try log in again.");

            var adress = await _adressRepository.GetUserAdresssByIdAsync(user.Id, request.AdressId);
            if (adress == null)
                throw new NotFindException("Not find this adress, try again");

            var cart = await _cartRepository.GetByUserIdAsync(user.Id);
            if (cart.ProductsInCart.Count() == 0)
                throw new NotFindException($"Not find products in cart");

            var order = await _orderRepository.CreateOrderFromCartAsync(cart.Id, request.AdressId); 

            return new OrderBaseResponse() { Id = 2 };
        }
    }
}
