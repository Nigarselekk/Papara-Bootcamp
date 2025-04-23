using HW2_RestfulApi.Interfaces;
using HW2_RestfulApi.Services;

namespace HW2_RestfulApi.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddSingleton<IProductService, ProductService>();
        services.AddSingleton<IUserService, UserService>();
        return services;
    }
}
