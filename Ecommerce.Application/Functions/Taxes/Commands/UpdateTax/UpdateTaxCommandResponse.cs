using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Functions.Taxes.Commands.UpdateTax
{
    public class UpdateTaxCommandResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
    }
}
