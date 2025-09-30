using TripPlanner.Data;
using Microsoft.Extensions.DependencyInjection;
using TripPlanner.Services.Interfaces;

namespace TripPlanner.Services;

public static class DependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IActivityService,ActivityService>();
        services.AddScoped<IItineraryService,ItineraryService>();
        services.AddScoped<ITransportService,TransportService>();
        services.AddScoped<ITripService,TripService>();

        return services;
    }
}