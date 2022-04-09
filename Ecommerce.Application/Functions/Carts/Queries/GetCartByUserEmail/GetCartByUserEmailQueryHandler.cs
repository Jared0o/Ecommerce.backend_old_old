using AutoMapper;
using Ecommerce.Application.Exceptions;
using Ecommerce.Application.Functions.Carts.Responses;
using Ecommerce.Application.Interfaces;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Application.Functions.Carts.Queries.GetCartByUserEmail
{
    internal class GetCartByUserEmailQueryHandler : IRequestHandler<GetCartByUserEmailQuery, CartBaseResponse>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public GetCartByUserEmailQueryHandler(ICartRepository cartRepository, IMapper mapper, UserManager<User> userManager)
        {
            _cartRepository = cartRepository;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<CartBaseResponse> Handle(GetCartByUserEmailQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetCartByUserEmailQueryValidator();
            var validatorResult = await validator.ValidateAsync(request);
            if (!validatorResult.IsValid)
                throw new ValidateException(validatorResult);

            var user = await _userManager.FindByEmailAsync(request.UserEmail);
            if (user == null)
                throw new AuthenticationByEmailException($"Not Find User with email {request.UserEmail} log in again");

            var response = await _cartRepository.GetByUserIdAsync(user.Id);


            if(response == null)
            {
                var cart = new Cart(user.Id);
                response = await _cartRepository.AddAsync(cart);
            }
            
            return _mapper.Map<CartBaseResponse>(response);

        }
    }
}
