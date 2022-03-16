using Ecommerce.Application.Interfaces;
using Ecommerce.Application.Interfaces.Services;
using Ecommerce.Domain.Entities.Identity;
using Ecommerce.Persistence.Repositories;
using Ecommerce.Persistence.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Ecommerce.Persistence
{
    public static class PersistenceAndEFInstalation
    {
        public static IServiceCollection EcommercePersistenceEFInstalation(this IServiceCollection service, IConfiguration config)
        {
            service.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            service.AddScoped<ICategoryRepository, CategoryRepository>();
            service.AddScoped<ITaxRepository, TaxRepository>();
            service.AddScoped<IProductRepository, ProductRepository>();
            service.AddScoped<ITokenService, TokenService>();

            service.AddDbContext<EcommerceContext>(opt =>
            {
                opt.UseSqlServer(config.GetConnectionString("SqlServerConnectionString"));
            });

            service.AddIdentityCore<User>()
                .AddRoles<Role>()
                .AddRoleManager<RoleManager<Role>>()
                .AddSignInManager<SignInManager<User>>()
                .AddRoleValidator<RoleValidator<Role>>()
                .AddEntityFrameworkStores<EcommerceContext>();

            service.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opt =>
                {
                    opt.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Token:Key"])),
                        ValidIssuer = config["Token:Issuer"],
                        ValidateIssuer = true,
                        ValidateAudience = false
                    };
                });

            service.AddAuthorization(opt =>
            {
                opt.AddPolicy("AdminRoleRequire", policy => policy.RequireRole(BaseRoleEnum.Admin.ToString()));
                opt.AddPolicy("UserRoleRequire", policy => policy.RequireRole(BaseRoleEnum.Admin.ToString(), BaseRoleEnum.User.ToString()));
            });


            return service;
        }
    }
}
