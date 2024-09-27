using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QuickLink.Application.Interfaces;
using QuickLink.Infrastructure.Configurations;
using QuickLink.Infrastructure.Extensions;
using QuickLink.Infrastructure.Repositories;
using QuickLink.Infrastructure.Utils;

namespace QuickLink.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddNHibernate(configuration.GetConnectionString(ConnectionStringNames.QuickLinkDb)!)
                .AddScoped<IShortLinkRepository, ShortLinkRepository>();

            return services;
        }
    }
}
