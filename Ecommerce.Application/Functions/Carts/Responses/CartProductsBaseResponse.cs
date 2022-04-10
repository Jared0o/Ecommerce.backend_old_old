using Ecommerce.Application.Functions.Products.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Functions.Carts.Responses
{
    public class CartProductsBaseResponse
    {
        public ProductVariantBaseResponse ProductVariant { get; set; }
        public int Quantity { get; set; }
    }
}
