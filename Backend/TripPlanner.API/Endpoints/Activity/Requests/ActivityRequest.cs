namespace TripPlanner.API.Endpoints.Activity.Requests;

public class ActivityRequest
{
    public string Name { get; set; } = string.Empty;
    public Domain.Trip.TripCategory Category { get; set; }
    public int Rating { get; set; }
    public float Price { get; set; }
    public string City { get; set; } = string.Empty;
}