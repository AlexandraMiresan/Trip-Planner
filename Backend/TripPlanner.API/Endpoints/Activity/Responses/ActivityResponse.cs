namespace TripPlanner.API.Endpoints.Activity.Responses;

public class ActivityResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Domain.Trip.TripCategory Category { get; set; }
    public int Rating { get; set; }
    public float Price { get; set; }
    public string City { get; set; } = string.Empty;
}