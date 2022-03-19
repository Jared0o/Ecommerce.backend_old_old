using Ecommerce.Application.Functions.Adresses.Responses;
using MediatR;

namespace Ecommerce.Application.Functions.Adresses.Commands
{
    public class CreateAdressCommand : IRequest<AdressBaseDto>
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string ZipCode { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string UserEmail { get; set; }
    }
}
