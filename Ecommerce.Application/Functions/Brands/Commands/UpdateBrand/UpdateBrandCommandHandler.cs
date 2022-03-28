using AutoMapper;
using Ecommerce.Application.Exceptions;
using Ecommerce.Application.Functions.Brands.Responses;
using Ecommerce.Application.Interfaces;
using Ecommerce.Domain.Entities;
using MediatR;

namespace Ecommerce.Application.Functions.Brands.Commands.UpdateBrand
{
    public class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommand, BrandBaseResponse>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;

        public UpdateBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }
        public async Task<BrandBaseResponse> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateBrandCommandValidator();
            var validatorResult = await validator.ValidateAsync(request);
            if (!validatorResult.IsValid)
                throw new ValidateException(validatorResult);

            var brand = await _brandRepository.GetByIdAsync(request.Id);
            if (brand == null)
                throw new NotFindException($"Not find brand with Id {request.Id}");

            var brandToUpdate = _mapper.Map<Brand>(request);

            brandToUpdate = await _brandRepository.UpdateAsync(brandToUpdate);

            var response = _mapper.Map<BrandBaseResponse>(brandToUpdate);

            return response;
        }
    }
}
