using Ecommerce.Api.Models.Taxes;
using Ecommerce.Application.Functions.Taxes.Commands.CreateTax;
using Ecommerce.Application.Functions.Taxes.Commands.UpdateTax;
using Ecommerce.Application.Functions.Taxes.Queries.GetTaxById;
using Ecommerce.Application.Functions.Taxes.Queries.GetTaxList;
using Ecommerce.Application.Functions.Taxes.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TaxController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TaxController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<TaxBaseDto>>> GetTaxesAsync()
        {
            var response = await _mediator.Send(new GetTaxListQuery());

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaxBaseDto>> GetTaxAsync([FromRoute] int id)
        {
            var response = await _mediator.Send(new GetTaxByIdQuery(id));

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<TaxBaseDto>> CreateTaxAsync([FromBody]CreateTaxDto body)
        {
            var response = await _mediator.Send(new CreateTaxCommand(body.Name, body.Value));

            return Ok(response);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<TaxBaseDto>> UpdateTaxAsync([FromRoute]int id, [FromBody]UpdateTaxDto body)
        {
            var response = await _mediator.Send(new UpdateTaxCommand(id, body.Name, body.Value));

            return Ok(response);
        }
    }
}
