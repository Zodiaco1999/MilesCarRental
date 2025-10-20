using MilesCarRental.Application.Abstractions.Clock;
using MilesCarRental.Application.Abstractions.Data;
using MilesCarRental.Application.Abstractions.Email;
using MilesCarRental.Domain.Abstractions;
using MilesCarRental.Domain.Alquileres;
using MilesCarRental.Domain.Users;
using MilesCarRental.Domain.Vehiculos;
using MilesCarRental.Infrastructure.Clock;
using MilesCarRental.Infrastructure.Data;
using MilesCarRental.Infrastructure.Email;
using MilesCarRental.Infrastructure.Repositories;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MilesCarRental.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration
        )
    {
        services.AddTransient<IDateTimeProvider, DateTimeProvider>();
        services.AddTransient<IEmailService, EmailService>();

        var connectionString = configuration.GetConnectionString("Database")
             ?? throw new ArgumentNullException(nameof(configuration));

        services.AddDbContext<ApplicationDbContext>(options => {
            options.UseNpgsql(connectionString).UseSnakeCaseNamingConvention();
        });

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IVehiculoRepository, VehiculoRepository>();
        services.AddScoped<IAlquilerRepository, AlquilerRepository>();

        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());

        services.AddSingleton<ISqlConnectionFactory>(_ => new SqlConnectionFactory(connectionString));

        SqlMapper.AddTypeHandler(new DateOnlyTypeHandler());
        return services;
    }

}
