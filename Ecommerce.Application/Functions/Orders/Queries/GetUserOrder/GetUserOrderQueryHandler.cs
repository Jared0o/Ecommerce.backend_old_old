using AutoMapper;
using Ecommerce.Application.Exceptions;
using Ecommerce.Application.Functions.Orders.Responses;
using Ecommerce.Application.Interfaces;
using Ecommerce.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Application.Functions.Orders.Queries.GetUserOrder
{
    internal class GetUserOrderQueryHandler : IRequestHandler<GetUserOrderQuery, OrderBaseResponse>
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;
        private readonly UserManager<User> _userManager;

        public GetUserOrderQueryHandler(IMapper mapper, IOrderRepository orderRepository, UserManager<User> userManager )
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
            _userManager = userManager;
        }
        public async Task<OrderBaseResponse> Handle(GetUserOrderQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetUserOrderQueryValidator();
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validatorResult.IsValid)
                throw new ValidateException(validatorResult);

            var user = await _userManager.FindByEmailAsync(request.UserEmail);
            if (user == null)
                throw new AuthenticationByEmailException("Not find user, log in again");

            var order = await _orderRepository.GetUserOrderAsync(user.Id, request.OrderId);

            var response = _mapper.Map<OrderBaseResponse>(order);

            if (response == null)
                throw new NotFindException($"Not find order with id {request.OrderId}");

            return response;
        }
    }
}
