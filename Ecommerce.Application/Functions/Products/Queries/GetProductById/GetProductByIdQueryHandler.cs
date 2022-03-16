using AutoMapper;
using Ecommerce.Application.Exceptions;
using Ecommerce.Application.Functions.Products.Responses;
using Ecommerce.Application.Interfaces;
using MediatR;

namespace Ecommerce.Application.Functions.Products.Queries.GetProductById
{
    public  class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductBaseDto>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public GetProductByIdQueryHandler(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }
        public async Task<ProductBaseDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetProductByIdQueryValidator();
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validatorResult.IsValid)
                throw new ValidateException(validatorResult);

            var product = await _productRepository.GetByIdAsync(request.Id);

            var response = _mapper.Map<ProductBaseDto>(product);

            return response;
        }
    }
}
