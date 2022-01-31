using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Ecommerce.Application
{
    public static class ApplicationInstalation
    {
        public static IServiceCollection EcommerceApplicationInstalation(this IServiceCollection service)
        {
            service.AddAutoMapper(Assembly.GetExecutingAssembly());
            service.AddMediatR(Assembly.GetExecutingAssembly());
            return service;
        }
    }
}
