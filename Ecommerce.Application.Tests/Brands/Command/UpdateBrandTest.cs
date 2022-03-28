using AutoMapper;
using Ecommerce.Application.Functions.Brands.Commands.UpdateBrand;
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
    public class UpdateBrandTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IBrandRepository> _mockBrandRepository;
        private readonly Mock<UserManager<User>> _mockUserManager;
        public UpdateBrandTest()
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
        public async Task Update_Brand_All_Data_Is_Valid()
        {
            var brand = new UpdateBrandCommand() { Id = 1, Name = "Updated Brand 1", Description = "Updated Brand 1 Desc" };

            var handler = new UpdateBrandCommandHandler(_mockBrandRepository.Object, _mapper);

            var response = await handler.Handle(brand, CancellationToken.None);

            response.ShouldBeOfType<BrandBaseResponse>();
            response.Id.ShouldBe(1);
            response.Name.ShouldBe("Updated Brand 1");
        } 
    }
}
