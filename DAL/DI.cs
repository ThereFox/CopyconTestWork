using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DAL;

public static class DI
{
    public static IServiceCollection AddDAL(this IServiceCollection services, Action<DbContextOptionsBuilder> DBconfiguration)
    {
        services.AddDbContext<BasicDataBaseContext>(DBconfiguration, ServiceLifetime.Singleton);

        return services;
    }
}