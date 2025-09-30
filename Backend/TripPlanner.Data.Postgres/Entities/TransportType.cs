namespace TripPlanner.Data.Postgres.Entities;

public class TransportType
{
    public Guid Id { get; set; }
    public Domain.TransportType.TransportMode Mode { get; set; }
    public string From { get; set; }
    public string To { get; set; }
    public int DurationMinutes { get; set; }
    public float Cost { get; set; }

    public Domain.TransportType ToDomain() => new(
        Id,
        Mode,
        From,
        To,
        DurationMinutes,
        Cost
    );

    public static TransportType FromDomain(Domain.TransportType transport) => new()
    {
        Id = transport.Id,
        Mode = transport.Mode,
        From = transport.From,
        To = transport.To,
        DurationMinutes = transport.DurationMinutes,
        Cost = transport.Cost
    };
}