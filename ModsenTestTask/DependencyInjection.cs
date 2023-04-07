
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using DAL.Data;
using DAL.Repositories;
using DAL.Repositories.Interfaces;
using Library.BLL.Profiles;
using Library.BLL.Services.Interfaces;
using Library.BLL.Services;
using Library.DAL.Repositories.Interfaces;
using Library.DAL.Repositories;
using Library.BLL.Models;
using Microsoft.Extensions.Options;
using System.Text;
using Library.BLL.Options;

namespace Library.WebApi
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastucture(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("Library.DAL")));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IAuthService, AuthService>();

            return services;
        }

        public static IServiceCollection AddAuth(this IServiceCollection services, ConfigurationManager configuration)
        {
            var jwtSettings = new JWTSettings();
            configuration.Bind(JWTSettings.SectionName, jwtSettings);

            services.AddAutoMapper(typeof(AppMappingProfile));
            services.AddSingleton(Options.Create(jwtSettings));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtSettings.Issuer,
                        ValidAudience = jwtSettings.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret))
                    };
                });
            return services;
        }
    }
}
