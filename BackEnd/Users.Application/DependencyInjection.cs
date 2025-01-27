using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Users.Application.Services;

namespace Users.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices
        (this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHttpClient<ICountryService, CountryService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IGenderService, GenderService>();
        services.AddScoped<ICountryService, CountryService>();
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        services.AddMemoryCache();
        
        return services;
    }
}
