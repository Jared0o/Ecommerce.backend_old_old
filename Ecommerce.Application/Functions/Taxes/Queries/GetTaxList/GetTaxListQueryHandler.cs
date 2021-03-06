using AutoMapper;
using Ecommerce.Application.Functions.Taxes.Responses;
using Ecommerce.Application.Interfaces;
using MediatR;

namespace Ecommerce.Application.Functions.Taxes.Queries.GetTaxList
{
    public class GetTaxListQueryHandler : IRequestHandler<GetTaxListQuery, IReadOnlyList<TaxBaseDto>>
    {
        private readonly IMapper _mapper;
        private readonly ITaxRepository _taxRepository;

        public GetTaxListQueryHandler(IMapper mapper, ITaxRepository taxRepository)
        {
            _mapper = mapper;
            _taxRepository = taxRepository;
        }
        public async Task<IReadOnlyList<TaxBaseDto>> Handle(GetTaxListQuery request, CancellationToken cancellationToken)
        {
            var taxes = await _taxRepository.GetAllAsync();
            var response = _mapper.Map<IReadOnlyList<TaxBaseDto>>(taxes);

            return response;
        }
    }
}
