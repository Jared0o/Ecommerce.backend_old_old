using FluentValidation;

namespace Ecommerce.Application.Functions.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor( x=> x.Name)
                .NotEmpty()
                .NotNull()
                .MinimumLength(2)
                .MaximumLength(15)
                .WithMessage("{PropertName} Length is beewten 2 and 15");

            RuleFor(x => x.Description)
                .MaximumLength(250);
        }
    }
}
