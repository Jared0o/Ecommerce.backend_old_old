using AutoMapper;
using Ecommerce.Application.Exceptions;
using Ecommerce.Application.Functions.Products.Responses;
using Ecommerce.Application.Interfaces;
using Ecommerce.Domain.Entities;
using MediatR;

namespace Ecommerce.Application.Functions.Products.Commands.UpdateProduct
{
    internal class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ProductBaseDto>
    {
        private readonly IMapper _mapper;
        private readonly ITaxRepository _taxRepository;
        private readonly IProductRepository _productRepository;

        public UpdateProductCommandHandler(IMapper mapper, ITaxRepository taxRepository, IProductRepository productRepository)
        {
            _mapper = mapper;
            _taxRepository = taxRepository;
            _productRepository = productRepository;
        }

        public async Task<ProductBaseDto> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateProductCommandValidator(_productRepository, _taxRepository);
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validatorResult.IsValid)
                throw new ValidateException(validatorResult);

            var product = _mapper.Map<Product>(request);

            product.Slug = product.Name.Trim().Replace(" ", "-").ToLower();

            product = await _productRepository.UpdateAsync(product);

            var response = _mapper.Map<ProductBaseDto>(product);

            return response;

        }
    }
}
