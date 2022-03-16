using Ecommerce.Application.Functions.Users.Commands.RegisterUser;
using Ecommerce.Application.Functions.Users.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserBaseDto>> Register(RegisterUserCommand request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);
        }
    }
}
