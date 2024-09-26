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
            var connectionString = configuration.GetConnectionString(ConnectionStringNames.QuickLinkDb);

            services
                .AddNHibernate(connectionString!)
                .AddScoped<IShortLinkRepository, ShortLinkRepository>();

            return services;
        }
    }
}
