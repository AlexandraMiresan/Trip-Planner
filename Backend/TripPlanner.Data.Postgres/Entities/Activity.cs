using System.ComponentModel.DataAnnotations;

namespace TripPlanner.Data.Postgres.Entities;

public class Activity
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Domain.Trip.TripCategory Category { get; set; }
    public int Rating { get; set; }
    public float Price { get; set; }
    public string City { get; set; }

    public Domain.Activity ToDomain() => new(
        Name,
        Category,
        Rating,
        Price,
        City
    );

    public static Activity FromDomain(Domain.Activity activity) => new()
    {
        Id = activity.Id,
        Name = activity.Name,
        Category = activity.Category,
        Rating = activity.Rating,
        Price = activity.Price,
        City = activity.City
    };
}