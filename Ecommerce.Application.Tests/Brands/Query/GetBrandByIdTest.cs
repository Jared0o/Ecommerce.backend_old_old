using AutoMapper;
using Ecommerce.Application.Functions.Brands.Queries.GetBrandById;
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

namespace Ecommerce.Application.Tests.Brands.Query
{
    public class GetBrandByIdTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IBrandRepository> _mockBrandRepository;
        private readonly Mock<UserManager<User>> _mockUserManager;
        public GetBrandByIdTest()
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
        public async Task Get_Brand_By_Id_Query_Is_Valid()
        {
            var id = 1;

            var handler = new GetBrandByIdQueryHandler(_mockBrandRepository.Object, _mapper);

            var response = await handler.Handle(new GetBrandByIdQuery(id), CancellationToken.None);

            response.ShouldBeOfType<BrandBaseResponse>();
            response.Id.ShouldBe(id);
        }
    }
}
