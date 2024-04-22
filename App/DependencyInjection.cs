using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace App
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAplication(
            this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            return services;
        }
    }
}
