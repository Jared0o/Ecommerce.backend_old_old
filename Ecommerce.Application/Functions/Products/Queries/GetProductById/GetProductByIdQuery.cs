using Ecommerce.Application.Functions.Products.Responses;
using MediatR;

namespace Ecommerce.Application.Functions.Products.Queries.GetProductById
{
    public class GetProductByIdQuery : IRequest<ProductBaseDto>
    {
        public int Id { get; set; }

        public GetProductByIdQuery(int id)
        {
            Id = id;
        }
    }
}
