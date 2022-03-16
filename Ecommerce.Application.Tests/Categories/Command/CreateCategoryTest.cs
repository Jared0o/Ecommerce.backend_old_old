using AutoMapper;
using Ecommerce.Application.Functions.Categories.Commands.CreateCategory;
using Ecommerce.Application.Functions.Categories.Responses;
using Ecommerce.Application.Interfaces;
using Ecommerce.Application.Mapper;
using Ecommerce.Application.Tests.Mocks;
using Moq;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Ecommerce.Application.Tests.Categories.Command
{
    public class CreateCategoryTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<ICategoryRepository> _mockCategoryRepository;

        public CreateCategoryTest()
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
        public async Task Create_Category_All_Data_Is_Valid()
        {
            var handler = new CreateCategoryCommandHandler(_mockCategoryRepository.Object, _mapper);

            var categoryCount = (await _mockCategoryRepository.Object.GetAllAsync()).Count;

            var response = await handler.Handle(new CreateCategoryCommand() { Name = "Nowa", Description = "Kategoria z Testów"}, CancellationToken.None);

            var allCategories = await _mockCategoryRepository.Object.GetAllAsync();

            response.ShouldBeOfType<CategoryBaseDto>();
            allCategories.Count.ShouldBe(categoryCount + 1);
            response.Id.ShouldBe(categoryCount+1);
            response.IsActive.ShouldBeFalse();
        }
    }
}
