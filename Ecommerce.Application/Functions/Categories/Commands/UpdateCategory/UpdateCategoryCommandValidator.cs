using Ecommerce.Application.Interfaces;
using FluentValidation;

namespace Ecommerce.Application.Functions.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
    {
        private readonly ICategoryRepository _categoryRepository;

        public UpdateCategoryCommandValidator(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;

            RuleFor(x => x.Id)
                .MustAsync(async (id, CancellationToken) => await CheckExistAsync(id))
                .WithMessage("Not find category with Id {PropertyValue}");

            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .MinimumLength(2)
                .MaximumLength(15)
                .WithMessage("{PropertName} Length is beewten 2 and 15");

            RuleFor(x => x.Description)
                .MaximumLength(250);
        }

        private async Task<bool> CheckExistAsync(int id)
        {
            var check = await _categoryRepository.GetByIdAsync(id);
            if (check == null)
                return false;

            return true;
        }
    }
}
