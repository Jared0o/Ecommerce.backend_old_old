using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Functions.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public int TaxId { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public string Sku { get; set; }
        public string Brand { get; set; }
        public string isDisable { get; set; }
    }
}
