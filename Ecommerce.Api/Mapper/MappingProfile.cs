using AutoMapper;
using Ecommerce.Api.Models.Adresses;
using Ecommerce.Api.Models.Auth;
using Ecommerce.Application.Functions.Adresses.Commands;
using Ecommerce.Application.Functions.Adresses.Commands.UpdateAdress;
using Ecommerce.Application.Functions.Auth.Queries.LoginUser;
using Ecommerce.Application.Functions.Users.Commands.RegisterUser;
using Ecommerce.Application.Functions.Users.Responses;

namespace Ecommerce.Api.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserRegister, RegisterUserCommand>();
            CreateMap<UserLogin, LoginUserQuery>();
            CreateMap<UserBaseDto, UserTokenResponse>();
            CreateMap<CreateAdressDto, CreateAdressCommand>();
            CreateMap<UpdateAdressDto, UpdateAdressCommand>();
        }
    }
}
