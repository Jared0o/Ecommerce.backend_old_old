using AutoMapper;
using Ecommerce.Application.Functions.Brands.Responses;
using Ecommerce.Application.Interfaces;
using MediatR;

namespace Ecommerce.Application.Functions.Brands.Queries.GetBrands
{
    public class GetBrandsListQueryHandler : IRequestHandler<GetBrandsListQuery, IReadOnlyList<BrandBaseResponse>>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;

        public GetBrandsListQueryHandler(IBrandRepository brandRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }
        public async Task<IReadOnlyList<BrandBaseResponse>> Handle(GetBrandsListQuery request, CancellationToken cancellationToken)
        {
            var brands = await _brandRepository.GetAllAsync();

            var response = _mapper.Map<IReadOnlyList<BrandBaseResponse>>(brands);

            return response;
        }
    }
}
