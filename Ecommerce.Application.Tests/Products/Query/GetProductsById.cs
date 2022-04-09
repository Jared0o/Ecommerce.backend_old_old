using AutoMapper;
using Ecommerce.Application.Functions.Products.Queries.GetProductById;
using Ecommerce.Application.Functions.Products.Responses;
using Ecommerce.Application.Interfaces;
using Ecommerce.Application.Mapper;
using Ecommerce.Application.Tests.Mocks;
using Moq;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Ecommerce.Application.Tests.Products.Query
{
    public class GetProductsById
    {
        private readonly IMapper _mapper;
        private readonly Mock<IProductRepository> _mockProductRepository;
        public GetProductsById()
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
        public async Task Get_Product_By_Id()
        {
            var id = 2;
            var handler = new GetProductByIdQueryHandler(_mapper, _mockProductRepository.Object);

            var result = await handler.Handle(new GetProductByIdQuery(id), CancellationToken.None);

            result.ShouldBeOfType<ProductBaseDto>();
            result.Id.ShouldBe(id);
        }
    }
}
