using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using OfflineTicketingSystem.Application.Common.Interfaces;
using OfflineTicketingSystem.Infrastructure.Mongo;
using OfflineTicketingSystem.Infrastructure.Security;
using OfflineTicketingSystem.Infrastructure.Settings;

namespace OfflineTicketingSystem.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfigurationManager configuration)
    {
        // Mongo Connection
        services.AddSingleton<IMongoClient>(sp =>
        {
            var connectionString = configuration.GetValue<string>("MongoDbSettings:ConnectionString");
            return new MongoClient(connectionString);
        });

        services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

        // Database context
        services.AddScoped<IMongoDbContext, MongoDbContext>();

        // Repository
        services.AddScoped<ITicketRepository, TicketRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IJwtService, JwtService>();

        return services;
    }
}
