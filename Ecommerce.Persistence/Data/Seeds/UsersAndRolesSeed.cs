using Ecommerce.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Persistence.Data.Seeds
{
    public static class UsersAndRolesSeed
    {
        public static async Task SeedUsersAndRolesAsync(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            if (!userManager.Users.Any())
            {
                if (!roleManager.Roles.Any())
                {
                    var rolesFromEnum = Enum.GetValues(typeof(BaseRoleEnum));
                    foreach (var role in rolesFromEnum)
                    {
                        await roleManager.CreateAsync(new Role { Name = role.ToString() });
                    }
                }


                var admin = new User
                {
                    Email = "admin@jarek.pl",
                    UserName = "admin@jarek.pl",
                    FirstName = "Admin",
                    LastName = "Adminowy",
                };

                var user = new User
                {
                    Email = "user@jarek.pl",
                    UserName = "user@jarek.pl",
                    FirstName = "User",
                    LastName = "Userowy"
                };

                await userManager.CreateAsync(admin, "Pa$$w0rd");
                await userManager.AddToRoleAsync(admin, BaseRoleEnum.Admin.ToString());

                await userManager.CreateAsync(user, "Pa$$w0rd");
                await userManager.AddToRoleAsync(user, BaseRoleEnum.User.ToString());
            }
        }
    }
}
