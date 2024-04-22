using App.Common.Interfaces.Mappings;
using App.Common.Interfaces.Persistence;
using Microsoft.OpenApi.Models;
using System.Reflection;
using App;
using Infrastructure;
using server.Authentication;
using MediatR;
using App.Common.Behaviors;
using Infrastructure.Persistence.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.CookiePolicy;
using server.CustomMiddleware;

var builder = WebApplication.CreateBuilder(args);
{
    var services = builder.Services;

    services.AddControllers();
    services.AddEndpointsApiExplorer();

    services
        .AddCors(options =>
        {
            options.AddPolicy("AllowAllHeaders", builder =>
            {
                builder.WithOrigins("http://localhost:3000")
                       .AllowAnyHeader()
                       .AllowAnyMethod()
                       .AllowCredentials();
            });
        });

    services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

    //Добавление свагера
    services.AddSwaggerGen(option =>
    {
        option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
        {
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
        });
        option.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] {}
                }
            });
    });

    services.AddAutoMapper(config =>
    {
        config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
        config.AddProfile(new AssemblyMappingProfile(typeof(IUnitOfWork).Assembly));
    });

    services
        .AddAplication()
        .AddInfrastructure(builder.Configuration);

    services.AddUserContext();

    builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

    services.AddHttpContextAccessor();
}

var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            options.RoutePrefix = string.Empty;
        });
        builder.Configuration
            .AddJsonFile($"appsettings.Development.json", optional: true);
    }
    else
    {
        builder.Configuration
            .AddJsonFile($"appsettings.Production.json", optional: true);

        // Обновление структуры основной БД автоматически при перезапуске приложения
        using (var scope = app.Services.CreateScope())
        {
            try
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
                dbContext.Database.Migrate();
            }
            catch (Exception ex)
            {
            }
        }
    }

    app.UseCors("AllowAllHeaders");

    app.UseCookiePolicy(new CookiePolicyOptions
    {
        MinimumSameSitePolicy = SameSiteMode.Strict,
        HttpOnly = HttpOnlyPolicy.Always,
        Secure = CookieSecurePolicy.Always
    });

    app.UseCustomExceptionHandler();
    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers();

    app.UseStaticFiles();

    app.Run();
}
