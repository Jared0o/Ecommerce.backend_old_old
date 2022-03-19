using Ecommerce.Application.Interfaces;
using Ecommerce.Domain.Entities;
using Moq;
using System.Collections.Generic;


namespace Ecommerce.Application.Tests.Mocks
{
    internal class AdressRepositoryMock
    {
        public static Mock<IAdressRepository> GetAdressRepository()
        {
            var adresses = GetAdresses();

            var mockAdressRepository = new Mock<IAdressRepository>();

            mockAdressRepository.Setup(repo => repo.AddAsync(It.IsAny<Adress>())).ReturnsAsync((Adress adress) =>
            {
                adress.Id = adresses.Count + 1;
                adresses.Add(adress);
                return adress;
            });

            mockAdressRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(adresses);


            return mockAdressRepository;
        }

        private static List<Adress> GetAdresses()
        {
            Adress a1 = new Adress()
            {
                Id = 1,
                Name = "Jan Kowlaski",
                Country = "Polska",
                City = "Łódź",
                Street = "Łódzka",
                HouseNumber = "2a",
                ZipCode = "12345",
                Email = "janxyzkowalskiasd@asd.pl",
                Telephone = "123456789",
                UserId = 1
            };
            Adress a2 = new Adress()
            {
                Id = 1,
                Name = "Jan Kowlaski",
                Country = "Polska",
                City = "Łódź",
                Street = "Łódzka",
                HouseNumber = "2a",
                ZipCode = "12345",
                Email = "janxyzkowalskiasd@asd.pl",
                Telephone = "123456789",
                UserId = 3
            };
            Adress a3 = new Adress()
            {
                Id = 1,
                Name = "Jan Kowlaski",
                Country = "Polska",
                City = "Łódź",
                Street = "Łódzka",
                HouseNumber = "2a",
                ZipCode = "12345",
                Email = "janxyzkowalskiasd@asd.pl",
                Telephone = "123456789",
                UserId = 1
            };
            Adress a4 = new Adress()
            {
                Id = 1,
                Name = "Jan Kowlaski",
                Country = "Polska",
                City = "Łódź",
                Street = "Łódzka",
                HouseNumber = "2a",
                ZipCode = "12345",
                Email = "janxyzkowalskiasd@asd.pl",
                Telephone = "123456789",
                UserId = 2
            };

            List<Adress> list = new List<Adress>();
            list.Add(a1); list.Add(a2); list.Add(a3); list.Add(a4); return list;
        }
    }
}
