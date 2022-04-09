using Ecommerce.Application.Interfaces;
using FluentValidation;

namespace Ecommerce.Application.Functions.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
    {

        public UpdateCategoryCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();

            RuleFor(x => x.Name)
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
