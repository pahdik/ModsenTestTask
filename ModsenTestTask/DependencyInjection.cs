
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Configuration;
using DAL.Data;
using DAL.Repositories;
using DAL.Repositories.Interfaces;
using DAL.Models;
using Library.BLL.Profiles;
using Library.BLL.Services.Interfaces;
using Library.BLL.Services;
using Library.BLL.Options;
using Library.DAL.Repositories.Interfaces;
using Library.DAL.Repositories;
using Library.BLL.Models;
using Microsoft.Extensions.Options;


namespace Library.WebApi
{
    public static class DependencyInjection
    {
        //public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
        //{
        //    services.AddDbContext<DataContext>(options =>
        //    options.UseSqlServer(
        //             configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("Library.DAL")));

        //    services.AddScoped<IApplicationContext, ApplicationContext>();

        //    services.AddIdentityCore<User>().AddEntityFrameworkStores<ApplicationContext>().AddSignInManager<SignInManager<User>>();

        //    services.AddAuth(configuration);
        //    services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();

        //    return services;
        //}

        //public static IServiceCollection AddAuth(this IServiceCollection services, ConfigurationManager configuration)
        //{
        //    var jwtSettings = new JwtSettings();
        //    configuration.Bind(JwtSettings.SectionName, jwtSettings);

        //    services.AddSingleton(Options.Create(jwtSettings));
        //    services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

        //    services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
        //        .AddJwtBearer(options => options.TokenValidationParameters = new()
        //        {
        //            ValidateIssuer = true,
        //            ValidateAudience = true,
        //            ValidateLifetime = true,
        //            ValidateIssuerSigningKey = true,
        //            ValidIssuer = jwtSettings.Issuer,
        //            ValidAudience = jwtSettings.Audience,
        //            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret))
        //        });

        //    return services;
        //}
    }
}
