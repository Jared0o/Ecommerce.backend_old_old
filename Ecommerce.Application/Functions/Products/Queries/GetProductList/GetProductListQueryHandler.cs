using AutoMapper;
using Ecommerce.Application.Functions.Products.Responses;
using Ecommerce.Application.Interfaces;
using MediatR;

namespace Ecommerce.Application.Functions.Products.Queries.GetProductList
{
    public class GetProductListQueryHandler : IRequestHandler<GetProductListQuery, IReadOnlyList<ProductBaseDto>>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public GetProductListQueryHandler(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<IReadOnlyList<ProductBaseDto>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetAllAsync();

            var response = _mapper.Map<IReadOnlyList<ProductBaseDto>>(products);

            return response;
        }


    }
}
