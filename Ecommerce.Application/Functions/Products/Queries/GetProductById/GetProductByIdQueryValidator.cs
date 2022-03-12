using Ecommerce.Application.Interfaces;
using FluentValidation;

namespace Ecommerce.Application.Functions.Products.Queries.GetProductById
{
    internal class GetProductByIdQueryValidator : AbstractValidator<GetProductByIdQuery>
    {
        private readonly IProductRepository _productRepository;

        public GetProductByIdQueryValidator(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            RuleFor(x => x.Id)
                .MustAsync(async (id, CancellationToken) => await CheckProductExist(id))
                .WithMessage("Not find product with id {PropertyValue}");
        }


        private async Task<bool> CheckProductExist(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
                return false;

            return true;
        }
    }
}
