using Ecommerce.Api.Models.Categories;
using Ecommerce.Application.Functions.Categories.Commands.CreateCategory;
using Ecommerce.Application.Functions.Categories.Commands.UpdateCategory;
using Ecommerce.Application.Functions.Categories.Queries.GetCategoryById;
using Ecommerce.Application.Functions.Categories.Queries.GetCategoryList;
using Ecommerce.Application.Functions.Categories.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<CategoryBaseDto>>> GetAllCategories()
        {
            var response = await _mediator.Send(new GetCategoryListQuery());
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<CategoryBaseDto>> CreateCategory([FromBody]CreateCategoryDto createCategoryDto)
        {
            var request = new CreateCategoryCommand(createCategoryDto.Name, createCategoryDto.Description);
            var response = await _mediator.Send(request);
            return Ok(response); 
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryBaseDto>> GetCategory([FromRoute] int id)
        {
            var response = await _mediator.Send(new GetCategoryByIdQuery(id));
            return Ok(response);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<CategoryBaseDto>> UpdateCategory([FromRoute]int id, [FromBody] UpdateCategoryDto body)
        {
            var response = await _mediator.Send(new UpdateCategoryCommand(id, body.Name, body.Description, body.IsActive));
            return Ok(response);
        }

    }
}
