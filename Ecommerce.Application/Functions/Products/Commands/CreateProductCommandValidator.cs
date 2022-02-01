using Ecommerce.Application.Interfaces;
using FluentValidation;

namespace Ecommerce.Application.Functions.Products.Commands
{
    internal class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        private readonly ITaxRepository _taxRepository;

        public CreateProductCommandValidator(ITaxRepository taxRepository)
        {
            _taxRepository = taxRepository;

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
        }

        private async Task<bool> CheckTaxExist(int id)
        {
            var tax = await _taxRepository.GetByIdAsync(id);
            if (tax == null)
                return false;
            return true;    
        }
    }
}
