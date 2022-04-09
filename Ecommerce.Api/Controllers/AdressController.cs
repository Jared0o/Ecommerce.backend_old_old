using AutoMapper;
using Ecommerce.Api.Models.Adresses;
using Ecommerce.Application.Functions.Adresses.Commands;
using Ecommerce.Application.Functions.Adresses.Commands.UpdateAdress;
using Ecommerce.Application.Functions.Adresses.Queries.GetUserAdressById;
using Ecommerce.Application.Functions.Adresses.Queries.GetUserAdresses;
using Ecommerce.Application.Functions.Adresses.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Ecommerce.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize(Policy = "UserRoleRequire")]
    public class AdressController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public AdressController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<AdressBaseDto>>> GetUserAdresses()
        {
            var userEmail = User.FindFirstValue(ClaimTypes.Email);
            var response = await _mediator.Send(new GetUserAdressesQuery(userEmail));

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AdressBaseDto>> GetUserAdressById([FromRoute]int id)
        {
            var userEmail = User.FindFirstValue(ClaimTypes.Email);
            var response = await _mediator.Send(new GetUserAdressByIdQuery(id, userEmail));

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<AdressBaseDto>> CreateUserAdress([FromBody] CreateAdressDto body)
        {
            var newAdress = _mapper.Map<CreateAdressCommand>(body);

            var userEmail = User.FindFirstValue(ClaimTypes.Email);
            newAdress.UserEmail = userEmail;

            var response = await _mediator.Send(newAdress);

            return Ok(response);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<AdressBaseDto>> UpdateUserAdress([FromRoute]int id, [FromBody]UpdateAdressDto body)
        {
            var updatedAdress = _mapper.Map<UpdateAdressCommand>(body);

            var userEmail = User.FindFirstValue(ClaimTypes.Email);
            updatedAdress.UserEmail = userEmail;
            updatedAdress.Id = id;

            var response = await _mediator.Send(updatedAdress);

            return Ok(response);
        }

    }
}
