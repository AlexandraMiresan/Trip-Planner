using TripPlanner.Domain;

namespace TripPlanner.Data;

public interface IItineraryRepository
{
    Task<Itinerary> CreateAsync(Itinerary itinerary);
    Task<Itinerary?> GetByIdAsync(Guid id);
    Task<IEnumerable<Itinerary>> GetAllAsync();
    Task UpdateAsync(Itinerary itinerary);
    Task DeleteAsync(Guid id);
    
}