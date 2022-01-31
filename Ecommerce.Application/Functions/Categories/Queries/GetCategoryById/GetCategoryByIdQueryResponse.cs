using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Functions.Categories.Queries.GetCategoryById
{
    public class GetCategoryByIdQueryResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool isDisable { get; set; }
    }
}
