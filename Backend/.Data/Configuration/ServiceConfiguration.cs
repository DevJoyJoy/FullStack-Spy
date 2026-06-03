public static class ServiceConfiguration
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddTransient<SeedService>();
        // services.AddTransient<I_Service, _Service>();
    }
}