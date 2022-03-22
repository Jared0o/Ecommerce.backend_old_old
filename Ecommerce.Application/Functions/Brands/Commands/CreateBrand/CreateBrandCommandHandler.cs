using AutoMapper;
using Ecommerce.Application.Exceptions;
using Ecommerce.Application.Functions.Brands.Responses;
using Ecommerce.Application.Interfaces;
using Ecommerce.Domain.Entities;
using MediatR;

namespace Ecommerce.Application.Functions.Brands.Commands.CreateBrand
{
    public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, BrandBaseResponse>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;

        public CreateBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }
        public async Task<BrandBaseResponse> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateBrandCommandValidator();
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validatorResult.IsValid)
                throw new ValidateException(validatorResult);

            var brand = _mapper.Map<Brand>(request);

            brand = await _brandRepository.AddAsync(brand);

            var response = _mapper.Map<BrandBaseResponse>(brand);

            return response;
        }
    }
}
