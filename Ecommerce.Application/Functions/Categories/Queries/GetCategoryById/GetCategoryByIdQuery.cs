using Ecommerce.Application.Functions.Categories.Responses;
using MediatR;

namespace Ecommerce.Application.Functions.Categories.Queries.GetCategoryById
{
    public class GetCategoryByIdQuery : IRequest<CategoryBaseDto>
    {
        public int Id { get; set; }
    }
}
