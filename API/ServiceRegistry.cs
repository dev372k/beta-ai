using API.Attributes;
using Application.Apps;
using Application.Users;
using Domain;
using Domain.Abstractions;
using Infrastructure;
using Infrastructure.Externals.OpenAI;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Shared.Constants;
using System.Text;

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
        services.AddScoped<AppServices>();
        services.AddScoped<UserServices>();
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
                builder.WithOrigins("*.zakhaer.com", "zakhaer.com", "localhost")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
        });

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidateAudience = false,
                ValidateIssuer = false,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("JWT:Secret").Value!))
            };
        });


        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Beta AI", Version = "v1" });
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Please insert JWT token with the prefix Bearer into field",
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "bearer",
                BearerFormat = "JWT"
            });
            c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] { }
                }
            });
        });

        services.AddScoped<CustomAuthorizeAttribute>();
        //services.AddSingleton(new MapperConfiguration(mc =>
        //{
        //    mc.AddProfile(new MappingProfile());
        //}).CreateMapper());
    }

    public static void Database(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<IApplicationDBContext, ApplicationDBContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("cs")));
    }

    public static void Validator(this IServiceCollection services)
    {
        //Users
        //services.AddValidatorsFromAssemblyContaining<AddUserDto>();

        //services.AddFluentValidationAutoValidation();
    }
}
