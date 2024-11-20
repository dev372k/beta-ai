using Domain;
using Domain.Abstractions;
using Infrastructure;
using Infrastructure.Externals.OpenAI;
using Shared.Constants;

namespace API;

public static class ServiceRegistry
{
    public static IServiceCollection AddPresentation(this IServiceCollection services, IConfiguration configuration)
    {
        services.Database(configuration);
        services.Misc(configuration);
        services.Services();
        services.External();
        services.Validator();

        return services;
    }
    public static void Services(this IServiceCollection services)
    {

    }
    
    public static void External(this IServiceCollection services)
    {
        services.AddHttpClient<IGPTService, GPTService>();
    }

    public static void Misc(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddCors(opt =>
        {
            opt.AddPolicy(name: DevContants.CORS, builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
        });

        //services.AddSingleton(new MapperConfiguration(mc =>
        //{
        //    mc.AddProfile(new MappingProfile());
        //}).CreateMapper());


        //services.AddMassTransit(configurator =>
        //{
        //    configurator.SetKebabCaseEndpointNameFormatter();
        //    configurator.AddConsumers(typeof(Program).Assembly);
        //    configurator.UsingRabbitMq((context, config) =>
        //    {
        //        config.Host(new Uri(builder.Configuration["Rabbitmq:cs"]!));
        //        config.ConfigureEndpoints(context);
        //    });
        //});

        //services.AddStackExchangeRedisCache(opt =>
        //{
        //    opt.Configuration = configuration.GetSection("Redis:cs").Value;
        //    opt.InstanceName = "";
        //});

        //services.AddScoped<CacheService>();
        //services.AddScoped<TaskPublisher>();
    }

    public static void Database(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IApplicationDBContext, ApplicationDBContext>();
    }

    public static void Validator(this IServiceCollection services)
    {
        //Users
        //services.AddValidatorsFromAssemblyContaining<AddUserDto>();

        //services.AddFluentValidationAutoValidation();
    }
}
