using FluentValidation;

namespace Ecommerce.Application.Functions.Carts.Commands
{
    internal class CreateCartCommandValidator : AbstractValidator<CreateCartCommand>
    {
        public CreateCartCommandValidator()
        {
            RuleFor(x => x.UserEmail)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .EmailAddress().WithMessage("{PropertyName} must be valid");
        }
    }
}
