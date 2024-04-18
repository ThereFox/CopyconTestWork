using App.RepositorysInterfaces;
using Microsoft.Extensions.DependencyInjection;

namespace FackeDAL;

public static class DI
{
    public static IServiceCollection AddFakeDAL(this IServiceCollection services)
    {
        services.AddSingleton<IAuthorStore, FakeAuthorStore>();
        services.AddSingleton<IBookStore, FakeBookStore>();
        
        return services;
    }
}