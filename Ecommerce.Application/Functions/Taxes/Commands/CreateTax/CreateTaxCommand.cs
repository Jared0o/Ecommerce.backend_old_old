using MediatR;

namespace Ecommerce.Application.Functions.Taxes.Commands.CreateTax
{
    public class CreateTaxCommand : IRequest<CreateTaxCommandResponse>
    {
        public string Name { get; set; }
        public int Value { get; set; }
    }
}
