using AutoMapper;
using Ecommerce.Application.Functions.Brands.Responses;
using MediatR;

namespace Ecommerce.Application.Functions.Brands.Commands.UpdateBrand
{
    public class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommand, BrandBaseResponse>
    {
        private readonly IBaseRepository _baseRepository;
        private readonly IMapper _mapper;

        public UpdateBrandCommandHandler(IBaseRepository baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }
        public Task<BrandBaseResponse> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
