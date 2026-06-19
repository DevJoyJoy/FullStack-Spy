using Backend.Application.Services;
using Backend.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

public static class ServiceConfiguration
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddTransient<SeedService>();
        services.AddTransient<IUserService, UserService>();
        services.AddTransient<IGroupService, GroupService>();
        services.AddTransient<IPlaceService, PlaceService>();
    }
}