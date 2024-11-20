using API;
using API.Middlewares;
using Application;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Shared.Constants;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1",
     new OpenApiInfo
     {
         Title = "Beta AI",
         Version = "v1",
         Description = "All you need.",
     });
});
builder.Services
    .AddPresentation(builder.Configuration)
    .AddApplication();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(DevContants.CORS);
app.UseMiddleware<ExceptionMiddleware>();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
