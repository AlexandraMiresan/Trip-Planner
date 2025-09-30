using System.ComponentModel.DataAnnotations;

namespace TripPlanner.Data.Postgres.Entities;

public class Trip
{
    [Key] public Guid Id { get; set; }
    public string Origin { get; set; }
    public string Destination { get; set; }
    public int Days { get; set; }
    public float Price { get; set; }
    public Domain.Trip.TripCategory Category { get; set; }
    public Domain.Itinerary[] Itinerary { get; set; }

    public Domain.Trip ToDomain() => new(
        Id,
        Origin,
        Destination,
        Days,
        Price,
        Category,
        Itinerary
    );

    public static Trip FromDomain(Domain.Trip trip) => new()
    {
        Id = trip.Id,
        Origin = trip.Origin,
        Destination = trip.Destination,
        Days = trip.Days,
        Price = trip.Price,
        Category = trip.Category,
        Itinerary = trip.Itinerary
    };
}