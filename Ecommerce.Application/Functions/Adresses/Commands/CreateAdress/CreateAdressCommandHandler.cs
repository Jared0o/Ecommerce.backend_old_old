using AutoMapper;
using Ecommerce.Application.Exceptions;
using Ecommerce.Application.Functions.Adresses.Responses;
using Ecommerce.Application.Interfaces;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Application.Functions.Adresses.Commands
{
    public class CreateAdressCommandHandler : IRequestHandler<CreateAdressCommand, AdressBaseDto>
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly IAdressRepository _adressRepository;

        public CreateAdressCommandHandler(UserManager<User> userManager, IMapper mapper, IAdressRepository adressRepository)
        {
            _userManager = userManager;
            _mapper = mapper;
            _adressRepository = adressRepository;
        }

        public async Task<AdressBaseDto> Handle(CreateAdressCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateAdressCommandValidator();
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validatorResult.IsValid)
                throw new ValidateException(validatorResult);

            var user = await _userManager.FindByEmailAsync(request.UserEmail);
            if (user == null)
                throw new AuthenticationByEmailException($"Not Find User With Email {request.UserEmail}");

            var adress = _mapper.Map<Adress>(request);
            adress.User = user;
            adress.UserId = user.Id;

            adress = await _adressRepository.AddAsync(adress);

            var response = _mapper.Map<AdressBaseDto>(adress);

            return response;
        }
    }
}
