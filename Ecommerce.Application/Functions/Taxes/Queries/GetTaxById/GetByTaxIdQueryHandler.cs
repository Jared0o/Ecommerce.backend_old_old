using AutoMapper;
using Ecommerce.Application.Exceptions;
using Ecommerce.Application.Functions.Taxes.Responses;
using Ecommerce.Application.Interfaces;
using MediatR;

namespace Ecommerce.Application.Functions.Taxes.Queries.GetTaxById
{
    internal class GetByTaxIdQueryHandler : IRequestHandler<GetTaxByIdQuery, TaxBaseDto>
    {
        private readonly IMapper _mapper;
        private readonly ITaxRepository _taxRepository;

        public GetByTaxIdQueryHandler(IMapper mapper, ITaxRepository taxRepository)
        {
            _mapper = mapper;
            _taxRepository = taxRepository;
        }
        public async Task<TaxBaseDto> Handle(GetTaxByIdQuery request, CancellationToken cancellationToken)
        {
            var tax = await _taxRepository.GetByIdAsync(request.Id);

            if (tax == null)
                throw new NotFindException($"Not find tax with Id {request.Id}");

            var response = _mapper.Map<TaxBaseDto>(tax);

            return response;
        }
    }
}
