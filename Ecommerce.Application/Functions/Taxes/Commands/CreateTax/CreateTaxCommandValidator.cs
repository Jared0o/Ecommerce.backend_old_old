using FluentValidation;

namespace Ecommerce.Application.Functions.Taxes.Commands.CreateTax
{
    public class CreateTaxCommandValidator : AbstractValidator<CreateTaxCommand>
    {
        public CreateTaxCommandValidator()
        {
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
    }
}
