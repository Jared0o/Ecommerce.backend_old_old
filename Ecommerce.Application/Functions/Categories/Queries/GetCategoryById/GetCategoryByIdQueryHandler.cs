using AutoMapper;
using Ecommerce.Application.Exceptions;
using Ecommerce.Application.Interfaces;
using MediatR;

namespace Ecommerce.Application.Functions.Categories.Queries.GetCategoryById
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, GetCategoryByIdQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public GetCategoryByIdQueryHandler(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }
        public async Task<GetCategoryByIdQueryResponse> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetCategoryByIdQueryValidator();
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validatorResult.IsValid)
                throw new ValidateException(validatorResult);

            var category = await _categoryRepository.GetByIdAsync(request.Id);

            if (category == null)
                throw new NotFindException($"Not Find category with id {request.Id}");

            var response = _mapper.Map<GetCategoryByIdQueryResponse>(category);

            return response;
        }
    }
}
