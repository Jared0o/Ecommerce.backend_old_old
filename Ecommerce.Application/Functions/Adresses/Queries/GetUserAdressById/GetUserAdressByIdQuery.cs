using Ecommerce.Application.Functions.Adresses.Responses;
using MediatR;

namespace Ecommerce.Application.Functions.Adresses.Queries.GetUserAdressById
{
    public class GetUserAdressByIdQuery : IRequest<AdressBaseDto>
    {
        public int AdressId { get; set; }
        public string UserEmail { get; set; }

        public GetUserAdressByIdQuery(int adressId, string userEmail)
        {
            AdressId = adressId;
            UserEmail = userEmail;
        }
    }
}
