using Ecommerce.Application.Functions.Categories.Responses;
using MediatR;

namespace Ecommerce.Application.Functions.Categories.Queries.GetCategoryList
{
    public class GetCategoryListQuery : IRequest<List<CategoryBaseDto>>
    {
    }
}
