using AutoMapper;
using Ecommerce.Application.Functions.Categories.Queries.GetCategoryList;
using Ecommerce.Application.Functions.Categories.Responses;
using Ecommerce.Application.Interfaces;
using Ecommerce.Application.Mapper;
using Ecommerce.Application.Tests.Mocks;
using Moq;
using Shouldly;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Ecommerce.Application.Tests.Categories.Query
{
    public class GetCategoryListQueryHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<ICategoryRepository> _mockCategoryRepository;
        public GetCategoryListQueryHandlerTest()
        {

            _mockCategoryRepository = CategoryRepositoryMock.GetCategoryRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();

        }

        [Fact]
        public async Task GetCategoryListTest()
        {
            var handler = new GetCategoryListQueryHandler(_mapper, _mockCategoryRepository.Object);
            var result = await handler.Handle(new GetCategoryListQuery(), CancellationToken.None);

            result.ShouldBeOfType<List<CategoryBaseDto>>();
            
            result.Count.ShouldBe(5);
        }
    }
}
