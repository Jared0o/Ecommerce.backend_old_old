using AutoMapper;
using Ecommerce.Application.Exceptions;
using Ecommerce.Application.Functions.Categories.Responses;
using Ecommerce.Application.Interfaces;
using Ecommerce.Domain.Entities;
using MediatR;

namespace Ecommerce.Application.Functions.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, CategoryBaseDto>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public UpdateCategoryCommandHandler(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }
        public async Task<CategoryBaseDto> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            

            var validator = new UpdateCategoryCommandValidator();
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid)
                throw new ValidateException(validatorResult);

            var category = _mapper.Map<Category>(request);

            category = await _categoryRepository.UpdateAsync(category);

            var response = _mapper.Map<CategoryBaseDto>(category);

            return response;
        }
    }
}
