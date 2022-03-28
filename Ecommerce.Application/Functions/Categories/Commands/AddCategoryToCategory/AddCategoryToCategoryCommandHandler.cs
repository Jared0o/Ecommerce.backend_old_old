using AutoMapper;
using Ecommerce.Application.Exceptions;
using Ecommerce.Application.Interfaces;
using MediatR;

namespace Ecommerce.Application.Functions.Categories.Commands.AddCategoryToCategory
{
    public class AddCategoryToCategoryCommandHandler : IRequestHandler<AddCategoryToCategoryCommand>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public AddCategoryToCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(AddCategoryToCategoryCommand request, CancellationToken cancellationToken)
        {
            var validator = new AddCategoryToCategoryCommandValidator();
            var validatorResult = await validator.ValidateAsync(request);
            if (!validatorResult.IsValid)
                throw new ValidateException(validatorResult);

            var childCategory = await _categoryRepository.GetByIdAsync(request.SubcategoryId);
            var parentCategory = await _categoryRepository.GetByIdAsync(request.ParentCategoryId);
            if (childCategory == null)
                throw new NotFindException($"Not find child category with Id {request.SubcategoryId}");
            if (parentCategory == null)
                throw new NotFindException($"Not find parent category with Id {request.ParentCategoryId}");

            if (parentCategory.ParentCategoryId == childCategory.Id)
                throw new ItemExistException($"{parentCategory.Name} category has parent of {childCategory.Name} category. I can't add {childCategory} to {parentCategory}");

            await _categoryRepository.UpdateParentCategoryAsync(childCategory, parentCategory);

            return Unit.Value;

        }
    }
}
