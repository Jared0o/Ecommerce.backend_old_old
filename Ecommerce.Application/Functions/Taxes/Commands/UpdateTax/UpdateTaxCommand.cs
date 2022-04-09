using Ecommerce.Application.Functions.Taxes.Responses;
using MediatR;

namespace Ecommerce.Application.Functions.Taxes.Commands.UpdateTax
{
    public class UpdateTaxCommand : IRequest<TaxBaseDto>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? Value { get; set; }

        public UpdateTaxCommand(int id, string? name, int? value)
        {
            Id = id;
            Name = name;
            Value = value;
        }
    }
}
