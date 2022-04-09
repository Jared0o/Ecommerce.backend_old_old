using Ecommerce.Api.Models.Cart;
using Ecommerce.Application.Functions.Carts.Commands.AddProductToCart;
using Ecommerce.Application.Functions.Carts.Queries.GetCartByUserEmail;
using Ecommerce.Application.Functions.Carts.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Ecommerce.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize(Policy = "UserRoleRequire")]

    public class CartController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CartController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<CartBaseResponse>> GetUserCart()
        {
            var userEmail = User.FindFirstValue(ClaimTypes.Email);

            var response = await _mediator.Send(new GetCartByUserEmailQuery(userEmail));

            return Ok(response);

        }
        [HttpPost]
        public async Task<ActionResult<CartBaseResponse>> AddProductToCart([FromBody] AddProductToCartDto body)
        {
            var userEmail = User.FindFirstValue(ClaimTypes.Email);

            var response = await _mediator.Send(new AddProductToCartCommand(userEmail, body.ProductId, body.ProductVariantId, body.Quantity));

            return Ok(response);
        }
    }
}
