using AutoMapper;
using Ecommerce.Application.Interfaces;
using MediatR;

namespace Ecommerce.Application.Functions.Categories.Queries.GetCategoryList
{
    public class GetCategoryListQueryHandler : IRequestHandler<GetCategoryListQuery, List<GetCategoryListQueryResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public GetCategoryListQueryHandler(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task<List<GetCategoryListQueryResponse>> Handle(GetCategoryListQuery request, CancellationToken cancellationToken)
        {
            var categories = await _categoryRepository.GetAllAsync();

            return _mapper.Map<List<GetCategoryListQueryResponse>>(categories);
        }
    }
}
