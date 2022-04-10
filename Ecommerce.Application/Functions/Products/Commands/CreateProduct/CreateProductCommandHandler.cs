using AutoMapper;
using Ecommerce.Application.Exceptions;
using Ecommerce.Application.Functions.Products.Responses;
using Ecommerce.Application.Interfaces;
using Ecommerce.Domain.Entities;
using MediatR;

namespace Ecommerce.Application.Functions.Products.Commands
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductBaseDto>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        private readonly IProductVariantRepository _productVariantRepository;

        public CreateProductCommandHandler(IMapper mapper, IProductRepository productRepository, IProductVariantRepository productVariantRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
            _productVariantRepository = productVariantRepository;
        }

        public async Task<ProductBaseDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateProductCommandValidator();
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid)
                throw new ValidateException(validatorResult);

            var product = _mapper.Map<Product>(request);
            product.Slug = product.Name.Trim().Replace(" ", "-").ToLower();

            product = await _productRepository.AddAsync(product);

            var response = _mapper.Map<ProductBaseDto>(product);

            var productVariant = new ProductVariant(response.Id, response.Name, response.Description, response.IsActive);
            productVariant.IsDefault = true;

            await _productVariantRepository.AddAsync(productVariant);

            return response;
        }
    }
}
