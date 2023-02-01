using Microsoft.OpenApi.Models;
using RandomGroupCreator.Domain.Interfaces.Services;
using RandomGroupCreator.Domain.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddTransient<IRandomGroupService, RandomGroupService>();

builder.Services.AddSwaggerGen(options =>
{
    options.CustomSchemaIds(type => type.ToString());

    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Random Group Creator API",
        Description = "API for access to Random Group Creator resources"
    });

    options.EnableAnnotations();
});

var app = builder.Build();

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

// Enable middleware to serve generated Swagger as a JSON endpoint.
app.UseSwagger();

// Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
// specifying the Swagger JSON endpoint.
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Random Group Creator API");
});

app.Run();
