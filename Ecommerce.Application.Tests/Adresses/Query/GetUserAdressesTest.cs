using AutoMapper;
using Ecommerce.Application.Functions.Adresses.Queries.GetUserAdresses;
using Ecommerce.Application.Functions.Adresses.Responses;
using Ecommerce.Application.Interfaces;
using Ecommerce.Application.Mapper;
using Ecommerce.Application.Tests.Mocks;
using Ecommerce.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Moq;
using Shouldly;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Ecommerce.Application.Tests.Adresses.Query
{
    public  class GetUserAdressesTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IAdressRepository> _mockAdressRepository;
        private readonly Mock<UserManager<User>> _mockUserManager;
        public GetUserAdressesTest()
        {
            _mockAdressRepository = AdressRepositoryMock.GetAdressRepository();
            _mockUserManager = UserManagerMock.MockUserManager();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        [Trait("Adress", "Adress")]
        public async Task Get_User_Adresses_Query_Is_Valid()
        {
            var userEmail = "janxyzkowalskiasd@asd.pl";

            var handler = new GetUserAdressesQueryHandler(_mockAdressRepository.Object, _mapper, _mockUserManager.Object);

            IReadOnlyList<AdressBaseDto> response = await handler.Handle(new GetUserAdressesQuery(userEmail), CancellationToken.None);

            response[0].ShouldBeOfType<AdressBaseDto>();
            response.Count.ShouldBe(2);
        }
    }
}
