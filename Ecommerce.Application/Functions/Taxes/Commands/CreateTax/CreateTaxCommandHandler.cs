using AutoMapper;
using Ecommerce.Application.Exceptions;
using Ecommerce.Application.Interfaces;
using Ecommerce.Domain.Entities;
using MediatR;

namespace Ecommerce.Application.Functions.Taxes.Commands.CreateTax
{
    public class CreateTaxCommandHandler : IRequestHandler<CreateTaxCommand, CreateTaxCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITaxRepository _taxRepository;

        public CreateTaxCommandHandler(IMapper mapper, ITaxRepository taxRepository)
        {
            _mapper = mapper;
            _taxRepository = taxRepository;
        }
        public async Task<CreateTaxCommandResponse> Handle(CreateTaxCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateTaxCommandValidator();
            var validatorResult = await validator.ValidateAsync(request); 

            if (!validatorResult.IsValid)
                throw new ValidateException(validatorResult);

            var tax = _mapper.Map<Tax>(request);

            tax = await _taxRepository.AddAsync(tax);

            var response = _mapper.Map<CreateTaxCommandResponse>(tax);

            return response;
        }
    }
}
