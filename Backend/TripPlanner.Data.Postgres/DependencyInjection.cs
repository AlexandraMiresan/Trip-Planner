
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Npgsql;
using TripPlanner.Data.Postgres.Repositories;

namespace TripPlanner.Data.Postgres;

public static class DependencyInjection
{
    public static IHostApplicationBuilder AddPostgresData(this IHostApplicationBuilder builder)
    {
        // builder.AddNpgsqlDbContext<DatabaseContext>(connectionName: "tripPlannerDb");
        // builder.Services.AddDbContext<DatabaseContext>(options =>
        //     options.UseNpgsql(builder.Configuration.GetConnectionString("tripPlannerDb")
        //                       ?? throw new InvalidOperationException("Connection string 'tripPlannerDb' not found.")));
        builder.Services.AddNpgsqlDataSource(builder.Configuration.GetConnectionString("tripPlannerDb") ?? string.Empty);
        builder.Services.AddDbContext<DatabaseContext>((sp, options) => {
            var dataSource = sp.GetRequiredService<NpgsqlDataSource>();
            options.UseNpgsql(dataSource);
        });
        
        // builder.EnrichNpgsqlDbContext<DatabaseContext>(
        //     configureSettings: settings =>
        //     {
        //         settings.DisableRetry = false;
        //         settings.CommandTimeout = 30;
        //     });

        builder.Services.AddRepositories();
        
        return builder;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IActivityRepository,ActivityRepository>();
        services.AddScoped<IItineraryRepository,ItineraryRepository>();
        services.AddScoped<ITransportRepository,TransportRepository>();
        services.AddScoped<ITripRepository,TripRepository>();
        return services;
    }
}