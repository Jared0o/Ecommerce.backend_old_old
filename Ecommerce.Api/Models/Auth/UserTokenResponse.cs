namespace Ecommerce.Api.Models.Auth
{
    public class UserTokenResponse
    {
        public string Token { get; set; }

        public UserTokenResponse(string token)
        {
            Token = token;
        }
    }
}
