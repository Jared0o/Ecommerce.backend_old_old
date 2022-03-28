using AutoMapper;
using Ecommerce.Application.Functions.Categories.Commands.AddCategoryToCategory;
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
    public class AddCategoryToCategoryTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<ICategoryRepository> _mockCategoryRepository;

        public AddCategoryToCategoryTest()
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
        public async Task Can_add_category_to_category_Data_Is_Valid()
        {
            var childId = 1;
            var parentId = 2;

            var handler = new AddCategoryToCategoryCommandHandler(_mockCategoryRepository.Object, _mapper);

            await handler.Handle(new AddCategoryToCategoryCommand(parentId, childId), CancellationToken.None);
        }
    }
}
