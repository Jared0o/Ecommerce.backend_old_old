using AutoMapper;
using Ecommerce.Application.Functions.Adresses.Commands.UpdateAdress;
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
    public class UpdateAdressTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IAdressRepository> _mockCategoryRepository;
        private readonly Mock<UserManager<User>> _mockUserManager;
        public UpdateAdressTest()
        {
            _mockCategoryRepository = AdressRepositoryMock.GetAdressRepository();
            _mockUserManager = UserManagerMock.MockUserManager();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        [Trait("Adress", "Adress")]
        public async Task Update_Adress_All_Data_Is_Valid()
        {
            var adress = new UpdateAdressCommand() { Id = 1, Name = "Marek", Country = "Hiszpania", City = "Łódź", Street = "xyzasdw", HouseNumber = "21", ZipCode = "00001", Email = "xyz@za.pl", Telephone = "987654321", UserEmail = "janxyzkowalskiasd@asd.pl" };
            var handler = new UpdateAdressCommandHandler(_mockCategoryRepository.Object, _mapper, _mockUserManager.Object);

            var response = await handler.Handle(adress, CancellationToken.None);

            response.ShouldBeOfType<AdressBaseDto>();
            response.Id.ShouldBe(1);
            response.Name.ShouldBe("Marek");
        }
    }
}
