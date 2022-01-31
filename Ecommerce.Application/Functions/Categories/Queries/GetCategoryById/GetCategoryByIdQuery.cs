using MediatR;

namespace Ecommerce.Application.Functions.Categories.Queries.GetCategoryById
{
    public class GetCategoryByIdQuery : IRequest<GetCategoryByIdQueryResponse>
    {
        public int Id { get; set; }

    }
}
