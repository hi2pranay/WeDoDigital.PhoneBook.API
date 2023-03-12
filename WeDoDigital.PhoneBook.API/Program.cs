using Microsoft.OpenApi.Models;
using WeDoDigital.PhoneBook.Core;
using WeDoDigital.PhoneBook.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.
// Allowing CORS for all domains and methods
string[] origins = new string[] { "http://localhost:3000" };
builder.Services.AddCors(o => o.AddPolicy("default", builder =>
{
    builder.WithOrigins(origins).AllowAnyMethod().AllowAnyHeader().WithExposedHeaders("WWW-Authenticate");
}));
builder.Services.AddApiVersioning(config =>
{
    // Specify the default API Version as 1.0
    config.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
    // if the client hasn't specified the API Version in the request, use the default API version number
    config.AssumeDefaultVersionWhenUnspecified = true;
    // Advertise the API versions supported for the particular endpoint
    config.ReportApiVersions = true;

});

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "WeDoDigital PhoneBook API", Version = "v1" });
});

builder.Services.AddCore();
builder.Services.AddInfrastructure(configuration);

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
// Enable middleware to serve generated Swagger as a JSON endpoint.
app.UseSwagger();
// specifying the Swagger JSON endpoint.
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
});

// Enable Cors
app.UseCors("default");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
