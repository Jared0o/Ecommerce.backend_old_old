using FluentValidation;

namespace Ecommerce.Application.Functions.Categories.Commands.AddCategoryToCategory
{
    public class AddCategoryToCategoryCommandValidator : AbstractValidator<AddCategoryToCategoryCommand>
    {
        public AddCategoryToCategoryCommandValidator()
        {
            RuleFor(x => x.ParentCategoryId).NotEmpty().NotNull();
            RuleFor(x => x.SubcategoryId).NotEmpty().NotNull();
        }
    }
}
