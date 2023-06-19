using ConfStream.Database.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ConfStream.Common.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDatabaseContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<DatabaseContext>(
                options =>
                {
                    options.UseNpgsql(connectionString);
                    options.UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);
                });

            return services;
        }
    }
}
