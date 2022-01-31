using Ecommerce.Application.Interfaces;
using Ecommerce.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.Persistence
{
    public static class PersistenceAndEFInstalation
    {
        public static IServiceCollection EcommercePersistenceEFInstalation(this IServiceCollection service, IConfiguration config)
        {
            service.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            service.AddScoped<ICategoryRepository, CategoryRepository>();
            service.AddScoped<ITaxRepository, TaxRepository>();

            service.AddDbContext<EcommerceContext>(opt =>
            {
                opt.UseSqlServer(config.GetConnectionString("SqlServerConnectionString"));
            });

            return service;
        }
    }
}
