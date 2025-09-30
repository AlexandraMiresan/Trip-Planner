using TripPlanner.Data;
using TripPlanner.Domain;

namespace TripPlanner.Services;

public class TripService(ITripRepository repository) : ITripService
{
    public async Task<Trip> CreateAsync(Trip trip)
    {
        return await repository.CreateAsync(trip);
    }

    public async Task<Trip?> GetByIdAsync(Guid id)
    {
        var trip = await repository.GetByIdAsync(id);
        if (trip is null)
        {
            throw new Exception($"Trip with id {id} was not found");
        }
        
        return trip;
    }

    public async Task<IEnumerable<Trip>> GetAllAsync()
    {
        return await repository.GetAllAsync();
    }

    public async Task UpdateAsync(Trip trip)
    {
        var entity = await repository.GetByIdAsync(trip.Id);
        if (entity is null)
        {
            throw new Exception($"Trip with id {trip.Id} was not found");
        }
        
        await repository.UpdateAsync(trip);
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await repository.GetByIdAsync(id);
        if (entity is null)
        {
            throw new Exception($"Trip with id {id} was not found");
        }
        
        await repository.DeleteAsync(id);
    }
}