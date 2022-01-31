using AutoMapper;
using Ecommerce.Application.Exceptions;
using Ecommerce.Application.Interfaces;
using Ecommerce.Domain.Entities;
using MediatR;

namespace Ecommerce.Application.Functions.Taxes.Commands.UpdateTax
{
    internal class UpdateTaxCommandHandler : IRequestHandler<UpdateTaxCommand, UpdateTaxCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITaxRepository _taxRepository;

        public UpdateTaxCommandHandler(IMapper mapper, ITaxRepository taxRepository)
        {
            _mapper = mapper;
            _taxRepository = taxRepository;
        }
        public async Task<UpdateTaxCommandResponse> Handle(UpdateTaxCommand request, CancellationToken cancellationToken)
        {

            var validator = new UpdateTaxCommandValidator(_taxRepository);
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validatorResult.IsValid)
                throw new ValidateException(validatorResult);

            var tax = _mapper.Map<Tax>(request);
            tax = await _taxRepository.UpdateAsync(tax);

            var response = _mapper.Map<UpdateTaxCommandResponse>(tax);

            return response;
        }
    }
}
