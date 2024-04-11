using App.Services;
using Microsoft.Extensions.DependencyInjection;

namespace App;

public static class DI
{
    public static IServiceCollection AddDAL(this IServiceCollection services)
    {
        services.AddSingleton<AuthorsServices>();
        services.AddSingleton<BooksServices>();

        return services;
    }
}