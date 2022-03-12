using Ecommerce.Application.Functions.Products.Commands;
using Ecommerce.Application.Functions.Products.Commands.UpdateProduct;
using Ecommerce.Application.Functions.Products.Queries.GetProductById;
using Ecommerce.Application.Functions.Products.Queries.GetProductList;
using Ecommerce.Application.Functions.Products.Responses;
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
        public async Task<ActionResult<ProductBaseDto>> AddProductAsync([FromBody]CreateProductCommand request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpPatch]
        public async Task<ActionResult<ProductBaseDto>> UpdateProductAsync([FromBody] UpdateProductCommand request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductBaseDto>>> GetProductsAsync()
        {
            var response = await _mediator.Send(new GetProductListQuery());

            return Ok(response);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<ProductBaseDto>> GetProductByIdAsync([FromRoute]GetProductByIdQuery request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);
        }
    }
}
