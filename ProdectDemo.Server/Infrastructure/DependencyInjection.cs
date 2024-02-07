using ProductDemo.Server.Application.Abstract.Infrastructure;
using ProductDemo.Server.Infrastructure.Notification;

namespace ProductDemo.Server.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<INotify, NotifyImplementation>();

        return services;
    }

}