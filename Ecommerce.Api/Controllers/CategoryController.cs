﻿using Ecommerce.Application.Functions.Categories.Commands.CreateCategory;
using Ecommerce.Application.Functions.Categories.Commands.UpdateCategory;
using Ecommerce.Application.Functions.Categories.Queries.GetCategoryById;
using Ecommerce.Application.Functions.Categories.Queries.GetCategoryList;
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
        public async Task<ActionResult<List<GetCategoryListQueryResponse>>> GetAllCategories()
        {
            var response = await _mediator.Send(new GetCategoryListQuery());
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<CreateCategoryCommandResponse>> CreateCategory(CreateCategoryCommand request)
        {
            var response = await _mediator.Send(request);
            return Ok(response); 
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<GetCategoryByIdQueryResponse>> GetCategory([FromRoute] GetCategoryByIdQuery request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpPatch]
        public async Task<ActionResult<UpdateCategoryCommandResponse>> UpdateCategory([FromBody] UpdateCategoryCommand request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
