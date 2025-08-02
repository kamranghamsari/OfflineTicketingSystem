using MediatR;
using Microsoft.Extensions.DependencyInjection;
using OfflineTicketingSystem.Application.Common;
using System.Reflection;

namespace OfflineTicketingSystem.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(x => x.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddAutoMapper((config) =>
        {
            config.AddProfile<ApplicationMappingProfile>();
        });

        return services;
    }
}
