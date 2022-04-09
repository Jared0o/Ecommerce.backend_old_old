using AutoMapper;
using Ecommerce.Api.Models.Auth;
using Ecommerce.Application.Functions.Auth.Queries.LoginUser;
using Ecommerce.Application.Functions.Users.Commands.RegisterUser;
using Ecommerce.Application.Functions.Auth.Queries.GetUserByEmailFromToken;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;


namespace Ecommerce.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public AuthController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserTokenResponse>> Register(UserRegister userRegister)
        {
            var request = _mapper.Map<RegisterUserCommand>(userRegister);
            var response = await _mediator.Send(request);
            var token = _mapper.Map<UserTokenResponse>(response);

            return Ok(token);
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserTokenResponse>> Login(UserLogin userlogin)
        {
            var request = _mapper.Map<LoginUserQuery>(userlogin);
            var response = await _mediator.Send(request);
            var token = _mapper.Map<UserTokenResponse>(response);
            return Ok(token);
        }

        [Authorize(Policy = "AdminRoleRequire")]
        [HttpGet("current-user-info")]
        public async Task<ActionResult<UserTokenResponse>> GetCurrentUser()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var response = await _mediator.Send(new GetUserByEmailFromTokenQuery(email));

            var token = _mapper.Map<UserTokenResponse>(response);
            return Ok(token);
        }
    }
}
