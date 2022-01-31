using Ecommerce.Application.Interfaces;
using Ecommerce.Domain.Entities;
using Moq;
using System.Collections.Generic;

namespace Ecommerce.Application.Tests.Mocks
{
    internal  class CategoryRepositoryMock
    {
        public static Mock<ICategoryRepository> GetCategoryRepository()
        {
            var categories = GetCategories();

            var mockCategoryRepository = new Mock<ICategoryRepository>();
            mockCategoryRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(categories);

            mockCategoryRepository.Setup(repo => repo.AddAsync(It.IsAny<Category>())).ReturnsAsync(
                (Category category) =>
                {
                    categories.Add(category);
                    return category;
                });

            mockCategoryRepository.Setup(repo => repo.AddAsync(It.IsAny<Category>())).ReturnsAsync(
                (Category category) =>
                {
                    category.Id = categories.Count + 1;
                    categories.Add(category);
                    return category;
                });

            return mockCategoryRepository;
        }

        private static List<Category> GetCategories()
        {
            Category c1 = new Category()
            {
                Id = 1,
                Name = "Computer",
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries"
            };

            Category c2 = new Category()
            {
                Id = 2,
                Name = "Laptop",
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries"
            };

            Category c3 = new Category()
            {
                Id = 3,
                Name = "T-Shirt",
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries"
            };

            Category c4 = new Category()
            {
                Id = 4,
                Name = "Car!",
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries"
            };

            Category c5 = new Category()
            {
                Id = 5,
                Name = "Cap-123",
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries"
            };


            List<Category> p = new List<Category>();
            p.Add(c1); p.Add(c3);
            p.Add(c2); p.Add(c4);
            p.Add(c5);

            return p;

        }
    }
}
