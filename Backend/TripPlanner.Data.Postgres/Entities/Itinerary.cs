using System.ComponentModel.DataAnnotations;

namespace TripPlanner.Data.Postgres.Entities;

public class Itinerary
{
    [Key] public Guid Id { get; set; }
    public int Day { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public Domain.TransportType[] Transport { get; set; }
    public Domain.Activity[] Activities { get; set; }
    public float EstimatedCost { get; set; }

    public Domain.Itinerary ToDomain() => new(
        Id,
        Day,
        City,
        Country,
        Transport,
        Activities,
        EstimatedCost
    );

    public static Itinerary FromDomain(Domain.Itinerary itinerary) => new()
    {
        Id = itinerary.Id,
        Day = itinerary.Day,
        City = itinerary.City,
        Country = itinerary.Country,
        Transport = itinerary.Transport,
        Activities = itinerary.Activities,
        EstimatedCost = itinerary.EstimatedCost
    };
}