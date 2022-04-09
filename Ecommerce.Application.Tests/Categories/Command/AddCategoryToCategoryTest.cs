using AutoMapper;
using Ecommerce.Application.Interfaces;
using Ecommerce.Application.Mapper;
using Ecommerce.Application.Tests.Mocks;
using Moq;
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

    }
}
