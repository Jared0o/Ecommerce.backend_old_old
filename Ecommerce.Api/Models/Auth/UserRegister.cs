namespace Ecommerce.Api.Models.Auth
{
    public class UserRegister
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public UserRegister(string email, string password, string confirmPassword, string firstName, string lastName)
        {
            Email = email;
            Password = password;
            ConfirmPassword = confirmPassword;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
