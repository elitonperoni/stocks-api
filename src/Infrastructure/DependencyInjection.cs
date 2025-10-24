using Application.Caching;
using Application.HttpRequest.ApiKeys;
using Infrastructure.Caching;
using Infrastructure.DomainEvents;
using Infrastructure.Time;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SharedKernel;
using StackExchange.Redis;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration) =>
        services
            .AddServices(configuration);

    private static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        services.AddTransient<IDomainEventsDispatcher, DomainEventsDispatcher>();        
        
        services.Configure<ApiKeys>(configuration.GetSection("ApiKeys"));       

        return services;
    }
    public static IServiceCollection AddCache(this IServiceCollection services, IConfiguration configuration)
    {
        string? redisConnectionString = configuration.GetConnectionString("Cache")!;       

        try
        {
            IConnectionMultiplexer connectionMultiplexer = ConnectionMultiplexer.Connect(redisConnectionString);
            services.TryAddSingleton(connectionMultiplexer);

            services.AddStackExchangeRedisCache(options =>
                options.ConnectionMultiplexerFactory = () => Task.FromResult(connectionMultiplexer));
        }
        catch
        {
            services.AddDistributedMemoryCache();
        }

        services.TryAddSingleton<ICacheService, CacheService>();

        return services;
    }
}
