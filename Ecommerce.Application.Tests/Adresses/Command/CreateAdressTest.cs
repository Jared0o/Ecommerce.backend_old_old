using AutoMapper;
using Ecommerce.Application.Functions.Adresses.Commands;
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
    public class CreateAdressTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IAdressRepository> _mockAdressRepository;
        private readonly Mock<UserManager<User>> _mockUserManager;
        public CreateAdressTest()
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
        public async Task Create_Adress_All_Data_Is_Valid()
        {
            var adressRequest = new CreateAdressCommand()
            {
                Name = "Janek", Country = "Polska", City = "Warszawa", Street = "xyzasdw", HouseNumber = "21", ZipCode = "00001", Email = "xyz@za.pl", Telephone = "123456789", UserEmail = "janxyzkowalskiasd@asd.pl"
            };

            var handler = new CreateAdressCommandHandler(_mockUserManager.Object, _mapper, _mockAdressRepository.Object);

            var adressesCount = (await _mockAdressRepository.Object.GetAllAsync()).Count;

            var response = await handler.Handle(adressRequest, CancellationToken.None);

            var allAdresses = await _mockAdressRepository.Object.GetAllAsync();

            response.ShouldBeOfType<AdressBaseDto>();
            allAdresses.Count.ShouldBe(adressesCount + 1);
            response.Id.ShouldBe(adressesCount + 1);
        }
    }
}
