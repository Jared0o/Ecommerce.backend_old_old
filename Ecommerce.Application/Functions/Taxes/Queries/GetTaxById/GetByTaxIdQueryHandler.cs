using AutoMapper;
using Ecommerce.Application.Exceptions;
using Ecommerce.Application.Interfaces;
using MediatR;

namespace Ecommerce.Application.Functions.Taxes.Queries.GetTaxById
{
    internal class GetByTaxIdQueryHandler : IRequestHandler<GetTaxByIdQuery, GetTaxByIdQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITaxRepository _taxRepository;

        public GetByTaxIdQueryHandler(IMapper mapper, ITaxRepository taxRepository)
        {
            _mapper = mapper;
            _taxRepository = taxRepository;
        }
        public async Task<GetTaxByIdQueryResponse> Handle(GetTaxByIdQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetTaxByIdQueryValidator(_taxRepository);
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validatorResult.IsValid)
                throw new ValidateException(validatorResult);

            var tax = await _taxRepository.GetByIdAsync(request.Id);

            var response = _mapper.Map<GetTaxByIdQueryResponse>(tax);

            return response;
        }
    }
}
