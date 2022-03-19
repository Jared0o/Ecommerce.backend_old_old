using Ecommerce.Domain.Common;
using Ecommerce.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace Ecommerce.Application.Tests.Mocks
{
    internal class UserManagerMock
    {
        public static Mock<UserManager<User>> MockUserManager() 
        {
            var users = GetUsers();

            var store = new Mock<IUserStore<User>>();
            var mgr = new Mock<UserManager<User>>(store.Object, null, null, null, null, null, null, null, null);
            mgr.Object.UserValidators.Add(new UserValidator<User>());
            mgr.Object.PasswordValidators.Add(new PasswordValidator<User>());

            mgr.Setup(x => x.FindByEmailAsync(It.IsAny<string>())).ReturnsAsync((string email) =>
            {
                var user = users.FirstOrDefault(x => x.Email == email);
                return user;
            });

            return mgr;
        }

        private static List<User> GetUsers()
        {
            var users = new List<User>
            {
                 new User() { Id = 1, Email = "janxyzkowalskiasd@asd.pl", UserName = "janxyzkowalskiasd@asd.pl" },
                 new User() { Id = 2, Email = "janxyzkowalskiasd1@asd.pl", UserName = "janxyzkowalskiasd1@asd.pl" }
            };

            return users;
        }
    }
}
