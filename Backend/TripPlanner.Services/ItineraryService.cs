using TripPlanner.Data;
using TripPlanner.Domain;
using TripPlanner.Services.Interfaces;

namespace TripPlanner.Services;

public class ItineraryService(IItineraryRepository repository) : IItineraryService
{
    public async Task<Itinerary> CreateAsync(Itinerary itinerary)
    {
        return await repository.CreateAsync(itinerary);
    }

    public async Task<Itinerary?> GetByIdAsync(Guid id)
    {
        var itinerary = await repository.GetByIdAsync(id);
        if (itinerary is null)
        {
            throw new Exception($"Itinerary with id {id} not found");
        }
        return itinerary;
    }

    public async Task<IEnumerable<Itinerary>> GetAllAsync()
    {
        return await repository.GetAllAsync();
    }

    public async Task UpdateAsync(Itinerary itinerary)
    {
        var entity = await repository.GetByIdAsync(itinerary.Id);
        if (entity is null)
        {
            throw new Exception($"Itinerary with id {itinerary.Id} not found");
        }
        
        await repository.UpdateAsync(itinerary);
    }

    public async Task DeleteAsync(Guid id)
    {
        var itinerary = await repository.GetByIdAsync(id);
        if (itinerary is null)
        {
            throw new Exception($"Itinerary with id {id} not found");
        }
        
        await repository.DeleteAsync(itinerary.Id);
    }
}