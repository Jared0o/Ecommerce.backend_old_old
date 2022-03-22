using FluentValidation;

namespace Ecommerce.Application.Functions.Brands.Commands.UpdateBrand
{
    public class UpdateBrandCommandValidator : AbstractValidator<UpdateBrandCommand>
    {
        public UpdateBrandCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty().NotNull()
            .MaximumLength(35);

            RuleFor(c => c.Description).MaximumLength(250);
        }
    }
}
