using AutoMapper;
using Ecommerce.Application.Exceptions;
using Ecommerce.Application.Functions.Taxes.Responses;
using Ecommerce.Application.Interfaces;
using Ecommerce.Domain.Entities;
using MediatR;

namespace Ecommerce.Application.Functions.Taxes.Commands.CreateTax
{
    internal class CreateTaxCommandHandler : IRequestHandler<CreateTaxCommand, TaxBaseDto>
    {
        private readonly IMapper _mapper;
        private readonly ITaxRepository _taxRepository;

        public CreateTaxCommandHandler(IMapper mapper, ITaxRepository taxRepository)
        {
            _mapper = mapper;
            _taxRepository = taxRepository;
        }
        public async Task<TaxBaseDto> Handle(CreateTaxCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateTaxCommandValidator();
            var validatorResult = await validator.ValidateAsync(request); 

            if (!validatorResult.IsValid)
                throw new ValidateException(validatorResult);

            var tax = _mapper.Map<Tax>(request);

            tax = await _taxRepository.AddAsync(tax);

            var response = _mapper.Map<TaxBaseDto>(tax);

            return response;
        }
    }
}
