using Ecommerce.Application.Interfaces;
using FluentValidation;

namespace Ecommerce.Application.Functions.Products.Commands.UpdateProduct
{
    internal class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        private readonly IProductRepository _productRepository;
        private readonly ITaxRepository _taxRepository;

        public UpdateProductCommandValidator(IProductRepository productRepository, ITaxRepository taxRepository)
        {
            _taxRepository = taxRepository;
            _productRepository = productRepository;

            RuleFor(x => x.Id)
                .MustAsync(async (id, CancellationToken) => await checkExistAsync(id))
                .WithMessage("Not find Product with Id {PropertyValue}");

            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .MinimumLength(2)
                .MaximumLength(50)
                .WithMessage("{PropertyName} Length is beewten 2 and 50");

            RuleFor(x => x.Price)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0)
                .WithMessage("{PropertyName} must be more then 0");

            RuleFor(x => x.TaxId)
                .MustAsync(async (id, CancellationToken) => await CheckTaxExist(id))
                .WithMessage("Not find tax with Id {PropertyValue}");
            _taxRepository = taxRepository;
        }

        private async Task<bool> CheckTaxExist(int id)
        {
            var tax = await _taxRepository.GetByIdAsync(id);
            if (tax == null)
                return false;
            return true;
        }

        private async Task<bool> checkExistAsync(int id)
        {
            var tax = await _productRepository.GetByIdAsync(id);
            if (tax == null)
                return false;

            return true;
        }
    }
}
