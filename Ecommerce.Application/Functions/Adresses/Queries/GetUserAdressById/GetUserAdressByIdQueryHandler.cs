using AutoMapper;
using Ecommerce.Application.Exceptions;
using Ecommerce.Application.Functions.Adresses.Responses;
using Ecommerce.Application.Interfaces;
using Ecommerce.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Application.Functions.Adresses.Queries.GetUserAdressById
{
    public class GetUserAdressByIdQueryHandler : IRequestHandler<GetUserAdressByIdQuery, AdressBaseDto>
    {
        private readonly IAdressRepository _adressRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public GetUserAdressByIdQueryHandler(IAdressRepository adressRepository, IMapper mapper, UserManager<User> userManager)
        {
            _adressRepository = adressRepository;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<AdressBaseDto> Handle(GetUserAdressByIdQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetUserAdressByIdQueryValidator();
            var validatorResult = await validator.ValidateAsync(request);
            if (!validatorResult.IsValid)
                throw new ValidateException(validatorResult);

            var user = await _userManager.FindByEmailAsync(request.UserEmail);
            if (user == null)
                throw new AuthenticationByEmailException($"Not find user with email: {request.UserEmail}");

            var adress = await _adressRepository.GetUserAdresssByIdAsync(user.Id, request.AdressId);
            if (adress == null)
                throw new NotFindException($"Not find adress with id: {request.AdressId} for user: {request.UserEmail}");

            var response = _mapper.Map<AdressBaseDto>(adress);

            return response;
        }
    }
}
