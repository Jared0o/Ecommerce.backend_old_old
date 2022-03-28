using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Interfaces
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        public Task<Category> UpdateParentCategoryAsync(Category childCategory, Category parentCategory);
    }
}
