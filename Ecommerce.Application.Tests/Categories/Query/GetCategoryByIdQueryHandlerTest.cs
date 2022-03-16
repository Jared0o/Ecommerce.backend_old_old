using AutoMapper;
using Ecommerce.Application.Functions.Categories.Queries.GetCategoryById;
using Ecommerce.Application.Functions.Categories.Responses;
using Ecommerce.Application.Interfaces;
using Ecommerce.Application.Mapper;
using Ecommerce.Application.Tests.Mocks;
using Moq;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Ecommerce.Application.Tests.Categories.Query
{
    public class GetCategoryByIdQueryHandlerTest
    {

        private readonly IMapper _mapper;
        private readonly Mock<ICategoryRepository> _mockCategoryRepository;
        public GetCategoryByIdQueryHandlerTest()
        {
            _mockCategoryRepository = CategoryRepositoryMock.GetCategoryRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        [Trait("Category", "Category")]
        public async Task Get_Category_By_Id_Test()
        {
            var id = 2;
            var handler = new GetCategoryByIdQueryHandler(_mapper, _mockCategoryRepository.Object);

            var result = await handler.Handle(new GetCategoryByIdQuery() { Id = id }, CancellationToken.None);

            result.ShouldBeOfType<CategoryBaseDto>();

            result.Id.ShouldBe(id);
        }
    }
}
