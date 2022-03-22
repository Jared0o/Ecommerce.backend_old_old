using AutoMapper;
using Ecommerce.Application.Exceptions;
using Ecommerce.Application.Functions.Adresses.Responses;
using Ecommerce.Application.Interfaces;
using Ecommerce.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Application.Functions.Adresses.Queries.GetUserAdresses
{
    public class GetUserAdressesQueryHandler : IRequestHandler<GetUserAdressesQuery, IReadOnlyList<AdressBaseDto>>
    {
        private readonly IAdressRepository _adressRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public GetUserAdressesQueryHandler(IAdressRepository adressRepository, IMapper mapper, UserManager<User> userManager)
        {
            _adressRepository = adressRepository;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<IReadOnlyList<AdressBaseDto>> Handle(GetUserAdressesQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetUserAdressesQueryValidator();
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validatorResult.IsValid)
                throw new ValidateException(validatorResult);

            var user = await _userManager.FindByEmailAsync(request.UserEmail);
            if (user == null)
                throw new AuthenticationByEmailException($"Not find user with email: {request.UserEmail}");

            var adresses = await _adressRepository.GetUserAdressesAsync(user);
            
            var response = _mapper.Map<IReadOnlyList<AdressBaseDto>>(adresses);

            return response;
        }
    }
}
