namespace Ecommerce.Application.Functions.Users.Responses
{
    public class UserBaseDto
    {
        public string Email { get; set; }
        public string Token { get; set; }
        public string Name { get; set; }

        public UserBaseDto(string email, string token, string name)
        {
            Email = email;
            Token = token;
            Name = name;
        }
    }
}
