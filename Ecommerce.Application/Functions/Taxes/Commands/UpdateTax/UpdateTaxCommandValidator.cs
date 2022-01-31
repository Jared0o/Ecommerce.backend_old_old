using Ecommerce.Application.Interfaces;
using FluentValidation;

namespace Ecommerce.Application.Functions.Taxes.Commands.UpdateTax
{
    public class UpdateTaxCommandValidator : AbstractValidator<UpdateTaxCommand>
    {
        private readonly ITaxRepository _taxRepository;

        public UpdateTaxCommandValidator(ITaxRepository taxRepository)
        {
            _taxRepository = taxRepository;
            RuleFor(x => x.Id)
                .MustAsync(async (id, CancellationToken) => await CheckExistAsync(id))
                .WithMessage("Not find Tax with Id {PropertyValue}");

            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .MinimumLength(2)
                .MaximumLength(10)
                .WithMessage("{PropertName} Length is beewten 2 and 15");

            RuleFor(x => x.Value)
                .NotNull()
                .NotEmpty()
                .GreaterThanOrEqualTo(0)
                .LessThanOrEqualTo(99)
                .WithMessage("Tax {PropertName} must be beewten 0 and 99");
        }

        private async Task<bool> CheckExistAsync(int id)
        {
            var tax = _taxRepository.GetByIdAsync(id);
            if (tax == null)
                return false;

            return true;
        }
    }
}
