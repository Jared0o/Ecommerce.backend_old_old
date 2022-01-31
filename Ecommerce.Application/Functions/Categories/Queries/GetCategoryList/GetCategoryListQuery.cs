using MediatR;

namespace Ecommerce.Application.Functions.Categories.Queries.GetCategoryList
{
    public class GetCategoryListQuery : IRequest<List<GetCategoryListQueryResponse>>
    {
    }
}
