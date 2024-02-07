using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;

namespace ProductDemo.Server.Presentation.Swagger;

public static class SwaggerConfigurations
{
    public static IServiceCollection AddCommonSwaggerSetting(this IServiceCollection services)
    {
        services.AddSwaggerGen(setup =>
        {
            // Security Scheme to use JWT Authentication
            var jwtSecurityScheme = new OpenApiSecurityScheme
            {
                BearerFormat = "JWT",
                Name = "JWT Authentication",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = JwtBearerDefaults.AuthenticationScheme,
                Description = "Put your JWT Bearer token",
                Reference = new OpenApiReference
                {
                    Id = JwtBearerDefaults.AuthenticationScheme,
                    Type = ReferenceType.SecurityScheme
                }
            };

            setup.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);
            setup.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                    { jwtSecurityScheme, Array.Empty<string>() }
            });
        });

        //services.AddSwaggerExamplesFromAssemblyOf<BadRequestExample>();
        //services.AddSwaggerExamplesFromAssemblyOf<ConflictExample>();

        return services;
    }


}