using Ecommerce.Application.Interfaces;
using Ecommerce.Domain.Entities;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace Ecommerce.Application.Tests.Mocks
{
    internal class BrandRepositoryMock
    {

        public static Mock<IBrandRepository> GetBrandsRepository()
        {
            var brands = GetBrands();

            var mockBrandRepository = new Mock<IBrandRepository>();

            mockBrandRepository.Setup(r => r.AddAsync(It.IsAny<Brand>())).ReturnsAsync((Brand brand) =>
            {
                brand.Id = brands.Count + 1;
                brands.Add(brand);

                return brand;
            });

            mockBrandRepository.Setup(r => r.GetAllAsync()).ReturnsAsync(brands);
            mockBrandRepository.Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((int id) =>
            {
                return brands.SingleOrDefault(x => x.Id == id);
            });

            mockBrandRepository.Setup(r => r.UpdateAsync(It.IsAny<Brand>())).ReturnsAsync((Brand brand) =>
            {
                return brand;
            });


            return mockBrandRepository;
        }


        private static List<Brand> GetBrands()
        {
            Brand b1 = new Brand()
            {
                Id = 1,
                Name = "Brand 1",
                Description = "Brand 1 Desc",
                IsActive = true,
            };
            Brand b2 = new Brand()
            {
                Id = 2,
                Name = "Brand 2",
                Description = "Brand 2 Desc",
                IsActive = false,
            };
            Brand b3 = new Brand()
            {
                Id = 3,
                Name = "Brand 3",
                Description = "Brand 3 Desc",
                IsActive = true,
            };
            Brand b4 = new Brand()
            {
                Id = 4,
                Name = "Brand 4",
                Description = "Brand 4 Desc",
                IsActive = false,
            };

            var brands = new List<Brand>();
            brands.Add(b1); brands.Add(b2); brands.Add(b3); brands.Add(b4);

            return brands;
        }
    }
}
