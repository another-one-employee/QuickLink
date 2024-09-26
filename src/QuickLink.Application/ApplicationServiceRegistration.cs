using Microsoft.Extensions.DependencyInjection;
using QuickLink.Application.Interfaces;
using QuickLink.Application.Services;
using System.Reflection;

namespace QuickLink.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services
                .AddAutoMapper(Assembly.GetExecutingAssembly())
                .AddScoped<IShortLinkService, ShortLinkService>();

            return services;
        }
    }
}
