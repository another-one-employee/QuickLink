using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QuickLink.Application.Models;
using QuickLink.Application.Interfaces;
using QuickLink.Infrastructure.Data;
using QuickLink.Infrastructure.Repositories;

namespace QuickLink.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddDbContext<ShortLinksDbContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString(nameof(ShortLinksDbContext))))
                .AddScoped<DbContext, ShortLinksDbContext>()
                .AddScoped<IAsyncRepository<ShortLink>, EntityRepository<ShortLink>>();

            return services;
        }
    }
}
