namespace TripPlanner.Domain;

public class Activity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public Trip.TripCategory Category { get; set; }
    public int Rating { get; set; }
    public float Price { get; set; } //EURO
    public string City {get; set;} = string.Empty;

    public Activity(string name, Trip.TripCategory category, int rating, float price, string city)
    {
        Id = Guid.NewGuid();
        Name = name;
        Category = category;
        Rating = rating;
        Price = price;
        City = city;
    }
}