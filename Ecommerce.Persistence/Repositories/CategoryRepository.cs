using Ecommerce.Application.Interfaces;
using Ecommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Persistence.Repositories
{
    internal class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(EcommerceContext context) : base(context)
        {
            
        }

        public Task<Category> UpdateParentCategoryAsync(Category childCategory, Category parentCategory)
        {
            throw new NotImplementedException();
        }
    }
}
