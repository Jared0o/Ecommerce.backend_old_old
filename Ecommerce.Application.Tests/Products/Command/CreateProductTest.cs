using AutoMapper;
using Ecommerce.Application.Functions.Products.Commands;
using Ecommerce.Application.Functions.Products.Responses;
using Ecommerce.Application.Interfaces;
using Ecommerce.Application.Mapper;
using Ecommerce.Application.Tests.Mocks;
using Moq;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Ecommerce.Application.Tests.Products.Command
{
    public class CreateProductTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IProductRepository> _mockProductRepository;

        public CreateProductTest()
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
        public async Task Create_Product_All_Data_Is_Valid()
        {
            var handler = new CreateProductCommandHandler(_mapper, _mockProductRepository.Object);

            var productCount = (await _mockProductRepository.Object.GetAllAsync()).Count;

            var response = await handler.Handle(new CreateProductCommand("Nowy", 1, "Opis", 1, 1), CancellationToken.None);

            var allProducts = await _mockProductRepository.Object.GetAllAsync();

            response.ShouldBeOfType<ProductBaseDto>();
            allProducts.Count.ShouldBe(productCount+1);
            response.Id.ShouldBe(productCount+1);
            response.IsActive.ShouldBeFalse();
        }
    }
}
