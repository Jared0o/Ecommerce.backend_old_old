using Ecommerce.Application.Interfaces;
using Ecommerce.Domain.Entities;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace Ecommerce.Application.Tests.Mocks
{
    internal class ProductRepositoryMock
    {
        public static Mock<IProductRepository> GetProductReposiotory()
        {
            var products = GetProducts();

            var mockProductRepository = new Mock<IProductRepository>();

            mockProductRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(products);

            mockProductRepository.Setup(repo => repo.AddAsync(It.IsAny<Product>())).ReturnsAsync(
                (Product product) =>
                {
                    product.Id = products.Count + 1;
                    products.Add(product);
                    return product;
                });

            mockProductRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(
                (int id) =>
                {
                    return products.SingleOrDefault(x => x.Id == id);
                });

            mockProductRepository.Setup(repo => repo.UpdateAsync(It.IsAny<Product>())).ReturnsAsync((Product product) =>
            {
                var index = products.FindIndex(x => x.Id == product.Id);
                products[index] = product;

                return products.SingleOrDefault(x => x.Id == product.Id);
            });

            return mockProductRepository;
        }

        private static List<Product> GetProducts()
        {
            Product p1 = new Product()
            {
                Id = 1,
                Name = "Dell M1",
                Slug = "dell-m1",
                TaxId = 1,
                Description = "Laptop firmy Dell",
                BrandId = 1,
                IsActive = true,
                CategoryId = 1,
            };
            Product p2 = new Product()
            {
                Id = 2,
                Name = "Dell M2",
                Slug = "dell-m1",
                TaxId = 1,
                Description = "Laptop firmy Dell",
                BrandId = 1,
                IsActive = true,
                CategoryId = 1,
            };
            Product p3 = new Product()
            {
                Id = 3,
                Name = "Dell M3",
                Slug = "dell-m1",
                TaxId = 1,
                Description = "Laptop firmy Dell",
                BrandId = 1,
                IsActive = true,
                CategoryId = 1,
            };

            List<Product> products = new List<Product>();
            products.Add(p1);
            products.Add(p2);
            products.Add(p3);

            return products;
        }
    }
}
