using Ecommerce.Application.Functions.Taxes.Commands.CreateTax;
using Ecommerce.Application.Functions.Taxes.Commands.UpdateTax;
using Ecommerce.Application.Functions.Taxes.Queries.GetTaxById;
using Ecommerce.Application.Functions.Taxes.Queries.GetTaxList;
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
        public async Task<ActionResult<IReadOnlyList<GetTaxListQueryResponse>>> GetTaxesAsync()
        {
            var response = await _mediator.Send(new GetTaxListQuery());

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetTaxByIdQueryResponse>> GetTaxAsync([FromRoute] GetTaxByIdQuery request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<CreateTaxCommandResponse>> CreateTax(CreateTaxCommand request)
        {
            var response = _mediator.Send(request);

            return Ok(response);
        }

        [HttpPatch]
        public async Task<ActionResult<UpdateTaxCommandResponse>> UpdateTax(UpdateTaxCommand request)
        {
            var response = _mediator.Send(request);

            return Ok(response);
        }
    }
}
