using AutoMapper;
using Ecommerce.Application.Functions.Brands.Queries.GetBrands;
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
    public class GetBrandsListTest
    {

        private readonly IMapper _mapper;
        private readonly Mock<IBrandRepository> _mockBrandRepository;
        private readonly Mock<UserManager<User>> _mockUserManager;
        public GetBrandsListTest()
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
        public async Task Get_Brands_ReadOnlyList_Query_Is_Valid()
        {
            var handler = new GetBrandsListQueryHandler(_mockBrandRepository.Object, _mapper);

            var response = await handler.Handle(new GetBrandsListQuery(), CancellationToken.None);

            response[0].ShouldBeOfType<BrandBaseResponse>();
            response.Count.ShouldBe(4);
        }
    }
}
