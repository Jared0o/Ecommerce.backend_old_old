using AutoMapper;
using Ecommerce.Application.Exceptions;
using Ecommerce.Application.Functions.Adresses.Responses;
using Ecommerce.Application.Interfaces;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Application.Functions.Adresses.Commands.UpdateAdress
{
    public class UpdateAdressCommandHandler : IRequestHandler<UpdateAdressCommand, AdressBaseDto>
    {
        private readonly IAdressRepository _adressRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public UpdateAdressCommandHandler(IAdressRepository adressRepository, IMapper mapper, UserManager<User> userManager)
        {
            _adressRepository = adressRepository;
            _mapper = mapper;
            _userManager = userManager;
        }
        public async Task<AdressBaseDto> Handle(UpdateAdressCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateAdressCommandValidator();
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validatorResult.IsValid)
                throw new ValidateException(validatorResult);

            var user = _userManager.FindByEmailAsync(request.UserEmail);
            if (user == null)
                throw new AuthenticationByEmailException($"Not Find User With Email {request.UserEmail}");

            var adressFromDb = await _adressRepository.GetByIdAsync(request.Id);
            if (user.Id != adressFromDb.UserId)
                throw new AuthenticationException($"Adress id {request.Id} is not adress user {request.UserEmail}");

            var adress = _mapper.Map<Adress>(request);

            adress = await _adressRepository.UpdateAsync(adress);

            var response = _mapper.Map<AdressBaseDto>(adress);

            return response;
        }
    }
}
