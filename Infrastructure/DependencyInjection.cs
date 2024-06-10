using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using App.Common.Interfaces.Persistence;
using Infrastructure.Persistence.DB.Repositories;
using Infrastructure.Persistence.DB;
using Microsoft.EntityFrameworkCore;
using App.Common.Interfaces.Authentication;
using Infrastructure.Authentication;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        ConfigurationManager configuration)
        {
            #region Регистрация БД
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddDbContext<ApplicationContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            #endregion

            #region Регистрация аутентификации и работы с файлами
            services.AddAuth(configuration);
            #endregion

            return services;
        }

        public static IServiceCollection AddAuth(this IServiceCollection services,
            ConfigurationManager configuration)
        {
            var jwtSettings = new JwtSettings();
            configuration.Bind(JwtSettings.SectionName, jwtSettings);
            services.AddSingleton(Options.Create(jwtSettings));

            services.AddSingleton<ITokenGenerator, JwtTokenGenerator>();

            services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(jwtSettings.SecretKey)),
                    LifetimeValidator = (DateTime? notBefore, DateTime? expires, SecurityToken securityToken,
                                     TokenValidationParameters validationParameters) =>
                    {
                        return expires > DateTime.UtcNow;
                    }
                });

            return services;
        }
    }
}
