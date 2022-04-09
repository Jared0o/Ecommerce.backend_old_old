using AutoMapper;
using Ecommerce.Application.Functions.Categories.Commands.UpdateCategory;
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
    public class UpdateCategoryTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<ICategoryRepository> _mockCategoryRepository;
        public UpdateCategoryTest()
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
        public async Task Updated_Categories_All_Data_Is_Valid()
        {
            var handler = new UpdateCategoryCommandHandler(_mapper, _mockCategoryRepository.Object);

            var response = await handler.Handle(new UpdateCategoryCommand(2, "Gry Specjalne", "Specjalna kategoria", false), CancellationToken.None);

            response.ShouldBeOfType<CategoryBaseDto>();
            response.Id.ShouldBe(2);
            response.Name.ShouldBe("Gry Specjalne");
            response.IsActive.ShouldBeFalse();
        }

    }
}
