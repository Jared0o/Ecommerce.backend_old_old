using Ecommerce.Api.Models.Products;
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
        public async Task<ActionResult<ProductBaseDto>> AddProductAsync([FromBody]CreateProductDto body)
        {
            var response = await _mediator.Send(new CreateProductCommand(body.Name, body.TaxId, body.Description, body.BrandId, body.CategoryId));
            return Ok(response);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<ProductBaseDto>> UpdateProductAsync([FromRoute]int id, [FromBody] UpdateProductDto body)
        {
            var response = await _mediator.Send(new UpdateProductCommand(id, body.Name, body.TaxId, body.Description, body.BrandId, body.CategoryId, body.IsActive));

            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductBaseDto>>> GetProductsAsync()
        {
            var response = await _mediator.Send(new GetProductListQuery());

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductBaseDto>> GetProductByIdAsync([FromRoute]int id)
        {
            var response = await _mediator.Send(new GetProductByIdQuery(id));

            return Ok(response);
        }
    }
}
