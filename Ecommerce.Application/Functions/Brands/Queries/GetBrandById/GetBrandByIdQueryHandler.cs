using AutoMapper;
using Ecommerce.Application.Exceptions;
using Ecommerce.Application.Functions.Brands.Responses;
using Ecommerce.Application.Interfaces;
using MediatR;

namespace Ecommerce.Application.Functions.Brands.Queries.GetBrandById
{
    public class GetBrandByIdQueryHandler : IRequestHandler<GetBrandByIdQuery, BrandBaseResponse>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;

        public GetBrandByIdQueryHandler(IBrandRepository brandRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }
        public async Task<BrandBaseResponse> Handle(GetBrandByIdQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetBrandByIdQueryValidator();
            var validatorResult = await validator.ValidateAsync(request);
            if (!validatorResult.IsValid)
                throw new ValidateException(validatorResult);

            var brand = _brandRepository.GetByIdAsync(request.Id);
            if (brand == null)
                throw new NotFindException($"Not Find brand with Id {request.Id}");

            var response = _mapper.Map<BrandBaseResponse>(brand);

            return response;
        }
    }
}
