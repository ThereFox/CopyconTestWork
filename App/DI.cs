using App.Services;
using Microsoft.Extensions.DependencyInjection;

namespace App;

public static class DI
{
    public static IServiceCollection AddApp(this IServiceCollection services)
    {
        services.AddTransient<AuthorsServices>();
        services.AddTransient<BooksServices>();

        return services;
    }
}