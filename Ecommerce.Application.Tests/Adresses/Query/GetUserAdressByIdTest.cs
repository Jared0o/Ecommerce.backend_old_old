using AutoMapper;
using Ecommerce.Application.Functions.Adresses.Queries.GetUserAdressById;
using Ecommerce.Application.Functions.Adresses.Responses;
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

namespace Ecommerce.Application.Tests.Adresses
{
    public class GetUserAdressByIdTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IAdressRepository> _mockAdressRepository;
        private readonly Mock<UserManager<User>> _mockUserManager;
        public GetUserAdressByIdTest()
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
        public async Task Get_User_Adress_By_Id_Query_Is_Valid()
        {
            var userEmail = "janxyzkowalskiasd@asd.pl";
            var adressId = 1;

            var handler = new GetUserAdressByIdQueryHandler(_mockAdressRepository.Object, _mapper, _mockUserManager.Object);

            var response = await handler.Handle(new GetUserAdressByIdQuery(adressId, userEmail), CancellationToken.None);

            response.ShouldBeOfType<AdressBaseDto>();
            response.Id.ShouldBe(adressId);
            response.City.ShouldBe("Łódź");
        }
    }
}
