using TripPlanner.API.Endpoints.Activity.Requests;
using TripPlanner.API.Endpoints.Activity.Responses;
using TripPlanner.Domain;

namespace TripPlanner.API.Endpoints.Activity.Mapping;

public static class ActivityMapping
{
    public static Domain.Activity ToDomain(this ActivityRequest request)
    {
        return new Domain.Activity(
            request.Name,
            request.Category,
            request.Rating,
            request.Price,
            request.City
        );
    }

    public static ActivityResponse ToResponse(this Domain.Activity activity)
    {
        return new ActivityResponse
        {
            Id = activity.Id,
            Name = activity.Name,
            Category = activity.Category,
            Rating = activity.Rating,
            Price = activity.Price,
            City = activity.City
        };
    }
}