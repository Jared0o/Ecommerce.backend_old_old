using AutoMapper;
using Ecommerce.Application.Functions.Products.Commands.UpdateProduct;
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
    public class UpdateProductTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IProductRepository> _mockProductRepository;

        public UpdateProductTest()
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
        public async Task Updated_Product_All_Data_Is_Valid()
        {
            var handle = new UpdateProductCommandHandler(_mapper, _mockProductRepository.Object);

            var response = await handle.Handle(new UpdateProductCommand(2, "nowa nazwa", 2, "Opis", 1, 1, true), CancellationToken.None);

            response.ShouldBeOfType<ProductBaseDto>();
            response.Id.ShouldBe(2);
            response.Name.ShouldBe("nowa nazwa");
            response.IsActive.ShouldBeTrue();
        }
    }
}
