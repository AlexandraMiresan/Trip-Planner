namespace TripPlanner.Domain;

public class Itinerary
{
    public Guid Id { get; set; }
    public int Day { get; set; }
    public string City { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public Guid TransportTypeId { get; set; }
    public List<Activity> Activities { get; set; } = new List<Activity>();
    public float EstimatedCost { get; set; }

    public Itinerary(int day, string city, string country, Guid transportTypeId, float estimatedCost)
    {
        Day = day;
        City = city;
        Country = country;
        TransportTypeId = transportTypeId;
        EstimatedCost = estimatedCost;
        Activities = new List<Activity>();
    }
    
    protected Itinerary() { }

}