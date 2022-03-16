using AutoMapper;
using Ecommerce.Application.Functions.Products.Queries.GetProductList;
using Ecommerce.Application.Functions.Products.Responses;
using Ecommerce.Application.Interfaces;
using Ecommerce.Application.Mapper;
using Ecommerce.Application.Tests.Mocks;
using Moq;
using Shouldly;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Ecommerce.Application.Tests.Products.Query
{
    public  class GetProductsList
    {
        private readonly IMapper _mapper;
        private readonly Mock<IProductRepository> _mockProductRepository;
        public GetProductsList()
        {
            _mockProductRepository = ProductRepositoryMock.GetProductReposiotory();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        [Trait("Product", "Product")]
        public async Task Get_Products_List()
        {
            var handler = new GetProductListQueryHandler(_mapper, _mockProductRepository.Object);

            var result = await handler.Handle(new GetProductListQuery(), CancellationToken.None);

            result.ShouldBeOfType<List<ProductBaseDto>>();

            result.Count.ShouldBe(3);
        }
    }
}
