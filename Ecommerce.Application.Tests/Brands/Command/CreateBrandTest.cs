using AutoMapper;
using Ecommerce.Application.Functions.Brands.Commands.CreateBrand;
using Ecommerce.Application.Functions.Brands.Responses;
using Ecommerce.Application.Interfaces;
using Ecommerce.Application.Mapper;
using Ecommerce.Application.Tests.Mocks;
using Ecommerce.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Moq;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Ecommerce.Application.Tests.Brands.Command
{
    public class CreateBrandTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IBrandRepository> _mockBrandRepository;
        private readonly Mock<UserManager<User>> _mockUserManager;
        public CreateBrandTest()
        {
            _mockBrandRepository = BrandRepositoryMock.GetBrandsRepository();
            _mockUserManager = UserManagerMock.MockUserManager();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        [Trait("Brand", "Brand")]
        public async Task Create_Brand_All_Data_Is_Valid()
        {
            var brandRequest = new CreateBrandCommand()
            {
                Name = "New Brand",
                Description = "New Brand Desc"
            };
            var handler = new CreateBrandCommandHandler(_mockBrandRepository.Object, _mapper);
            var brandsCount = (await _mockBrandRepository.Object.GetAllAsync()).Count;

            var response = await handler.Handle(brandRequest, CancellationToken.None);

            response.ShouldBeOfType<BrandBaseResponse>();
            response.Id.ShouldBe(brandsCount + 1);
        }
    }
}
