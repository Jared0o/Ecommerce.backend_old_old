using Ecommerce.Application.Interfaces;
using FluentValidation;

namespace Ecommerce.Application.Functions.Taxes.Queries.GetTaxById
{
    internal class GetTaxByIdQueryValidator : AbstractValidator<GetTaxByIdQuery> 
    {
        private readonly ITaxRepository _taxRepository;

        public GetTaxByIdQueryValidator(ITaxRepository taxRepository)
        {
            _taxRepository = taxRepository;

            RuleFor(x => x.Id)
                .MustAsync(async (id, CancellationToken) => await CheckExistAsync(id))
                .WithMessage("Not find tax with Id {PropertyValue}");
        }

        private async Task<bool> CheckExistAsync(int id)
        {
            var tax = await _taxRepository.GetByIdAsync(id);
            if (tax == null)
                return false;

            return true;
        }
    }
}
