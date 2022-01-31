using MediatR;

namespace Ecommerce.Application.Functions.Taxes.Commands.UpdateTax
{
    public class UpdateTaxCommand : IRequest<UpdateTaxCommandResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
    }
}
