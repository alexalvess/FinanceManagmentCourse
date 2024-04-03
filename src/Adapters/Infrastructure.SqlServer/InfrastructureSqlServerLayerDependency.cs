using Application.Abstractions.Ports.Repositories;
using Infrastructure.SqlServer.Databases;
using Infrastructure.SqlServer.Databases.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.SqlServer;

public static class InfrastructureSqlServerLayerDependency
{
    public static IServiceCollection AddSqlServerLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DbContext, FinanceManagmentContext>((provider, builder) =>
        {
            builder
                .EnableDetailedErrors()
                .EnableSensitiveDataLogging()
                .UseSqlServer(
                    connectionString: configuration.GetConnectionString("FinanceManagmentDB"),
                    sqlServerOptionsAction: options
                        => options.MigrationsAssembly(typeof(FinanceManagmentContext).Assembly.GetName().Name)
                );
        });

        services.AddScoped<IFinanceManagementRepository, FinanceManagmentRepository>();

        return services;
    }
}
