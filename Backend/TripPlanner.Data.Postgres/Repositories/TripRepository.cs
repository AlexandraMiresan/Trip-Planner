using Microsoft.EntityFrameworkCore;
using TripPlanner.Domain;

namespace TripPlanner.Data.Postgres.Repositories;

public class TripRepository(DatabaseContext context) : ITripRepository
{
    public async Task<Trip> CreateAsync(Trip trip)
    {
        var entity = Entities.Trip.FromDomain(trip);
        context.Trips.Add(entity);
        await context.SaveChangesAsync();
        return entity.ToDomain();
    }

    public async Task<Trip?> GetByIdAsync(Guid id)
    {
        return (await context.Trips.FindAsync(id))?.ToDomain();
    }

    public async Task<IEnumerable<Trip>> GetAllAsync()
    {
        return await context.Trips.Select(trip => trip.ToDomain())
            .ToListAsync();
    }

    public async Task UpdateAsync(Trip trip)
    {
        var entity = await context.Trips.FindAsync(trip.Id);
        if (entity is null)
        {
            throw new Exception("Trip not found");
        }
        entity.Origin =  trip.Origin;
        entity.Destination = trip.Destination;
        entity.Days = trip.Days;
        entity.Price = trip.Price;
        entity.Category = trip.Category;
        entity.Itinerary = trip.Itinerary;
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await context.Trips.FindAsync(id);
        if (entity is null)
        {
            throw new Exception("Trip not found");
        }
        context.Trips.Remove(entity);
        await context.SaveChangesAsync();
    }
}