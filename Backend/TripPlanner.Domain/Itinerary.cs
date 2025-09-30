namespace TripPlanner.Domain;

public class Itinerary
{
    public Guid Id { get; set; }
    public int Day { get; set; }
    public string City { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public TransportType[] Transport { get; set; }
    public Activity[] Activities { get; set; }
    public float EstimatedCost { get; set; }

    public Itinerary(Guid id, int day, string city, string country, TransportType[] transport, Activity[] activities,
        float estimatedCost)
    {
        Id = id;
        Day = day;
        City = city;
        Country = country;
        Transport = transport;
        Activities = activities;
        EstimatedCost = estimatedCost;
    }
}