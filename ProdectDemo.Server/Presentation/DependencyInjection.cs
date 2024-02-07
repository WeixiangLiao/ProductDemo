using ProductDemo.Server.Presentation.Swagger;
using System.Text.Json.Serialization;

namespace ProductDemo.Server.Presentation;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });
        services.AddSwaggerGen();

        return services;
    }

}