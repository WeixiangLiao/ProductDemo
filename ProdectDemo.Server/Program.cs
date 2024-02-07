using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using ProductDemo.Server;
using ProductDemo.Server.Application;
using ProductDemo.Server.Domain.Entities;
using ProductDemo.Server.Infrastructure;
using ProductDemo.Server.Persistence;
using ProductDemo.Server.Presentation;
using System.IdentityModel.Tokens.Jwt;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddMappings();
builder.Services.AddApplication();
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddPresentation();
builder.Services.AddInfrastructure();

builder.Services.AddCors(
    options =>
    {
        options.AddDefaultPolicy(policy =>
            policy
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .WithExposedHeaders(
                    "X-Pagination",
                    "X-Permissions"
                )
                .WithHeaders(HeaderNames.AcceptLanguage)
        );
    }
);

//builder.Services.AddApplicationOptions();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
}
else
{
    var environment = builder.Configuration["EnvironmentPath"];
    var basePath = $"{environment}/user";
    app.UseSwagger(c =>
    {
        c.RouteTemplate = "swagger/{documentName}/swagger.json";
        c.PreSerializeFilters.Add((swaggerDoc, httpReq) =>
        {
            swaggerDoc.Servers = new List<OpenApiServer> { new OpenApiServer { Url = $"{httpReq.Scheme}://{httpReq.Host.Value}{basePath}" } };
        });
    });
}
app.UseSwaggerUI();

JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
//app.UseAuthentication();
//app.UseAuthorization();

app.UseCors();

app.UseHttpsRedirection();
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ProductModuleDbContext>();

    dbContext.SeedBuyerData();
    dbContext.SeedProductData();

}

app.Run();
