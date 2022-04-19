using Ecommerce.Application.Functions.Orders.Commands.CreateOrderFromCart;
using Ecommerce.Application.Functions.Orders.Queries.GetUserOrder;
using Ecommerce.Application.Functions.Orders.Queries.GetUserOrdersList;
using Ecommerce.Application.Functions.Orders.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Ecommerce.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize(Policy = "UserRoleRequire")]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> CreateOrderFromCart()
        {
            var userEmail = User.FindFirstValue(ClaimTypes.Email);
            var response = await _mediator.Send(new CreateOrderFromCartCommand(userEmail, 2));

            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<OrderBaseResponse>>> GetUserOrders()
        {
            var userEmail = User.FindFirstValue(ClaimTypes.Email);
            var response = await _mediator.Send(new GetUserOrdersQuery(userEmail));

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderBaseResponse>> GetUserOrder([FromRoute]int id)
        {
            var userEmail = User.FindFirstValue(ClaimTypes.Email);
            var response = await _mediator.Send(new GetUserOrderQuery(userEmail, id));

            return Ok(response);
        }
    }
}
