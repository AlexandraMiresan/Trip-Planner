using Microsoft.EntityFrameworkCore;
using TripPlanner.Domain;

namespace TripPlanner.Data.Postgres.Repositories;

public class ItineraryRepository(DatabaseContext context) : IItineraryRepository
{
    public async Task<Itinerary> CreateAsync(Itinerary itinerary)
    {
        var entity = Entities.Itinerary.FromDomain(itinerary);
        context.Itineraries.Add(entity);
        await context.SaveChangesAsync();
        return entity.ToDomain();
    }

    public async Task<Itinerary?> GetByIdAsync(Guid id)
    {
        return (await context.Itineraries.FindAsync(id))?.ToDomain();
    }

    public async Task<IEnumerable<Itinerary>> GetAllAsync()
    {
        return await context.Itineraries.Select(itinerary => itinerary.ToDomain())
            .ToListAsync();
    }

    public async Task UpdateAsync(Itinerary itinerary)
    {
        var entity = await context.Itineraries.FindAsync(itinerary.Id);
        if (entity is null)
        {
            throw new Exception("Entity not found");
        }
        
        entity.Day = itinerary.Day;
        entity.City = itinerary.City;
        entity.Country = itinerary.Country;
        entity.TransportTypeId = itinerary.TransportTypeId;
        entity.Activities = itinerary.Activities;
        entity.EstimatedCost = itinerary.EstimatedCost;
        
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await context.Itineraries.FindAsync(id);
        if (entity is null)
        {
            throw new Exception("Entity not found");
        }
        
        context.Itineraries.Remove(entity);
        await context.SaveChangesAsync();
    }
}