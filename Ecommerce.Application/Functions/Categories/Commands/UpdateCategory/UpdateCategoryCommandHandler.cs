using AutoMapper;
using Ecommerce.Application.Exceptions;
using Ecommerce.Application.Interfaces;
using Ecommerce.Domain.Entities;
using MediatR;

namespace Ecommerce.Application.Functions.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, UpdateCategoryCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public UpdateCategoryCommandHandler(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }
        public async Task<UpdateCategoryCommandResponse> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            

            var validator = new UpdateCategoryCommandValidator(_categoryRepository);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid)
                throw new ValidateException(validatorResult);

            var category = _mapper.Map<Category>(request);

            category = await _categoryRepository.UpdateAsync(category);

            var response = _mapper.Map<UpdateCategoryCommandResponse>(category);

            return response;
        }
    }
}
