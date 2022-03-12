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

        [HttpGet("{Id}")]
        public async Task<ActionResult<TaxBaseDto>> GetTaxAsync([FromRoute] GetTaxByIdQuery request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<TaxBaseDto>> CreateTaxAsync(CreateTaxCommand request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpPatch]
        public async Task<ActionResult<TaxBaseDto>> UpdateTaxAsync(UpdateTaxCommand request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);
        }
    }
}
