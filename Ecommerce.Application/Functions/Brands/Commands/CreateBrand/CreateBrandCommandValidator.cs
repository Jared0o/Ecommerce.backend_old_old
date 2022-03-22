using FluentValidation;

namespace Ecommerce.Application.Functions.Brands.Commands.CreateBrand
{
    public class CreateBrandCommandValidator : AbstractValidator<CreateBrandCommand>
    {
        public CreateBrandCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty().NotNull()
                .MaximumLength(35);

            RuleFor(c => c.Description).MaximumLength(250);
        }
    }
}
