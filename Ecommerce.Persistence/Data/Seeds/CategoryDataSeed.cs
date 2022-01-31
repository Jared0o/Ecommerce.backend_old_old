using Ecommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Persistence.Data.Seeds
{
    internal class CategoryDataSeed
    {
        internal static List<Category> GetCategories()
        {
            Category c1 = new Category() {Id=1, Name = "Category 1", Description = "Lorem ipsum dolor sit amet" };
            Category c2 = new Category() {Id=2, Name = "Category 2", Description = "Lorem ipsum dolor sit amet" };
            Category c3 = new Category() {Id=3, Name = "Category 3", Description = "Lorem ipsum dolor sit amet" };
            Category c4 = new Category() {Id=4, Name = "Category 4", Description = "Lorem ipsum dolor sit amet" };

            return new List<Category>() { c1, c2, c3, c4 };
        }
    }
}
