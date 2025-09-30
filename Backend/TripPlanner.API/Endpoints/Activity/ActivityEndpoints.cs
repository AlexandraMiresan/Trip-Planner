using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using TripPlanner.API.Endpoints.Activity.Mapping;
using TripPlanner.API.Endpoints.Activity.Requests;
using TripPlanner.Services.Interfaces;

namespace TripPlanner.API.Endpoints.Activity;

public static class ActivityEndpoints
{
    public static RouteGroupBuilder MapActivityEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/activities")
            .WithTags("Activity");

        group.MapGet("/", GetAllAsync);
        group.MapGet("/{id:guid}", GetByIdAsync);
        group.MapPost("/", CreateAsync);
        group.MapPut("/{id:guid}", UpdateAsync);
        group.MapDelete("/{id:guid}", DeleteAsync);
        
        return group;
    }
    
    public abstract class ActivityLogging { }

    public static async Task<IResult> GetAllAsync(IActivityService service, ILogger<ActivityLogging> logger)
    {
        logger.LogInformation("Getting all activities");
        var activities = await service.GetAllAsync();
        return Results.Ok(activities.Select(ActivityMapping.ToResponse));
    }

    public static async Task<IResult> GetByIdAsync(Guid id, IActivityService service, ILogger<ActivityLogging> logger)
    {
        logger.LogInformation("Fetching activity with ID: {Id}", id);
        var item = await service.GetByIdAsync(id);
        return item is not null ? Results.Ok(ActivityMapping.ToResponse(item)) : Results.NotFound();
    }

    public static async Task<IResult> CreateAsync(ActivityRequest activity, IActivityService service,
        ILogger<ActivityLogging> logger)
    {
        logger.LogInformation("Creating activity");
        var domain = activity.ToDomain();
        var created = await service.CreateAsync(domain);
        return Results.Created($"/activities/{created.Id}", ActivityMapping.ToResponse(created));
    }

    public static async Task<IResult> UpdateAsync(Guid id, ActivityRequest activity, IActivityService service,
        ILogger<ActivityLogging> logger)
    {
        logger.LogInformation("Updating activity");
        var existing = await service.GetByIdAsync(id);
        if (existing is null)
        {
            return Results.NotFound();
        }

        await service.UpdateAsync(existing);
        return Results.NoContent();
    }

    public static async Task<IResult> DeleteAsync(Guid id, IActivityService service, ILogger<ActivityLogging> logger)
    {
        logger.LogInformation("Deleting activity");
        var existing = await service.GetByIdAsync(id);
        if (existing is null)
        {
            return Results.NotFound();
        }


        await service.DeleteAsync(id);
        return Results.NoContent();
    }
}