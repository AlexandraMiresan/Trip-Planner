namespace TripPlanner.Domain;

public class Trip
{
    public enum TripCategory
    {
        History,
        Foodie,
        Adventure,
        Relaxation,
        Nature,
        Nightlife
    }
    
    public Guid Id { get; set; }
    public string Origin { get; set; } = string.Empty;
    public string Destination { get; set; } = string.Empty;
    public int Days {get; set;}
    public float Price {get; set;}
    public TripCategory Category {get; set;}
    public List<Itinerary> Itinerary { get; set; }

    public Trip(string origin, string destination, int days, float price, TripCategory category)
    {
        Id = Guid.NewGuid();
        Origin = origin;
        Destination = destination;
        Days = days;
        Price = price;
        Category = category;
        Itinerary = new List<Itinerary>();
    }
    
    protected Trip() { }
}