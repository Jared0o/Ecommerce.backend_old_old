using Ecommerce.Application.Interfaces;
using FluentValidation;

namespace Ecommerce.Application.Functions.Products.Queries.GetProductById
{
    internal class GetProductByIdQueryValidator : AbstractValidator<GetProductByIdQuery>
    {

        public GetProductByIdQueryValidator( )
        {
        }

    }
}
