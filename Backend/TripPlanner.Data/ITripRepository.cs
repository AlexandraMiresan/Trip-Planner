using TripPlanner.Domain;

namespace TripPlanner.Data;

public interface ITripRepository
{
    Task<Trip> CreateAsync(Trip trip);
    Task<Trip?> GetByIdAsync(Guid id);
    Task<IEnumerable<Trip>> GetAllAsync();
    Task UpdateAsync(Trip trip);
    Task DeleteAsync(Guid id);
}