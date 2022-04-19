using AutoMapper;
using Ecommerce.Application.Exceptions;
using Ecommerce.Application.Functions.Orders.Responses;
using Ecommerce.Application.Interfaces;
using Ecommerce.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Application.Functions.Orders.Queries.GetUserOrdersList
{
    internal class GetUserOrdersQueryHandler : IRequestHandler<GetUserOrdersQuery, IReadOnlyList<OrderBaseResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;
        private readonly UserManager<User> _userManager;

        public GetUserOrdersQueryHandler(IMapper mapper, IOrderRepository orderRepository, UserManager<User> userManager)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
            _userManager = userManager;
        }
        public async Task<IReadOnlyList<OrderBaseResponse>> Handle(GetUserOrdersQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetUserOrdersQueryValidator();
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validatorResult.IsValid)
                throw new ValidateException(validatorResult);

            var user = await _userManager.FindByEmailAsync(request.UserEmail);
            if (user == null)
                throw new AuthenticationByEmailException("Not find user, try log in again");

            var orders = await _orderRepository.GetUserOrdersAsync(user.Id);

            var response = _mapper.Map<IReadOnlyList<OrderBaseResponse>>(orders);

            return response;
        }
    }
}
