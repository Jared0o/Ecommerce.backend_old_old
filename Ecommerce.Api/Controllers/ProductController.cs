using Ecommerce.Application.Functions.Products.Commands;
using Ecommerce.Application.Functions.Products.Commands.UpdateProduct;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<CreateProductCommandResponse>> AddProductAsync([FromBody]CreateProductCommand request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpPatch]
        public async Task<ActionResult<UpdateProductCommandResponse>> UpdateProductAsync([FromBody] UpdateProductCommand request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);
        }
    }
}
