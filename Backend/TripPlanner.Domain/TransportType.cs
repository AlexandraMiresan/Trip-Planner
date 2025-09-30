namespace TripPlanner.Domain;

public class TransportType
{
    public enum TransportMode
    {
        Flight,
        Car,
        Train,
        Bicycle,
        Walk
    }
    
    public Guid Id { get; set; }
    public TransportMode Mode { get; set; }
    public string From { get; set; } = string.Empty;
    public string To { get; set; } = string.Empty;
    public int DurationMinutes  { get; set; }
    public float Cost { get; set; } //EURO

    public TransportType(TransportMode mode, string from, string to, int durationMinutes, float cost)
    {
        Id = Guid.NewGuid();
        Mode = mode;
        From = from;
        To = to;
        DurationMinutes = durationMinutes;
        Cost = cost;
        
    }
}