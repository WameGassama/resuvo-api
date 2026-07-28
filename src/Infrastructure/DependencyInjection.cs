using Application.Common.Interfaces;
using Infrastructure.Authentication;
using Infrastructure.Common.Persistence;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfigurationManager configuration)
    {
        services.AddScoped<IResumeRepository, ResumeRepository>();
        services.AddScoped<IUnitOfWork>(serviceProvider => serviceProvider.GetRequiredService<ResumeDBContext>());
        services.AddDbContext<ResumeDBContext>(options => options.UseNpgsql(configuration.GetConnectionString("DbConnection")).UseSnakeCaseNamingConvention());
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddScheme<AuthenticationSchemeOptions, ClerkAuthenticationHandler>(JwtBearerDefaults.AuthenticationScheme, (o) => { });

        return services;
    }
}