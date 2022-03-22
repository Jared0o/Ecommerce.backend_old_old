using Ecommerce.Application.Functions.Adresses.Responses;
using MediatR;

namespace Ecommerce.Application.Functions.Adresses.Queries.GetUserAdresses
{
    public class GetUserAdressesQuery : IRequest<IReadOnlyList<AdressBaseDto>>
    {
        public string UserEmail { get; set; }

        public GetUserAdressesQuery(string userEmail)
        {
            UserEmail = userEmail;
        }
    }
}
