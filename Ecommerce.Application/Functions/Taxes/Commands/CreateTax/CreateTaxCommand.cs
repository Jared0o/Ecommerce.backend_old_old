using Ecommerce.Application.Functions.Taxes.Responses;
using MediatR;

namespace Ecommerce.Application.Functions.Taxes.Commands.CreateTax
{
    public class CreateTaxCommand : IRequest<TaxBaseDto>
    {
        public string Name { get; set; }
        public int Value { get; set; }

        public CreateTaxCommand(string name, int value)
        {
            Name = name;
            Value = value;
        }
    }
}
