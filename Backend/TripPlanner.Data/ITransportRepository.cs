using TripPlanner.Domain;

namespace TripPlanner.Data;

public interface ITransportRepository
{
    Task<TransportType> CreateAsync(TransportType trip);
    Task<TransportType?> GetByIdAsync(Guid id);
    Task<IEnumerable<TransportType>> GetAllAsync();
    Task UpdateAsync(TransportType trip);
    Task DeleteAsync(Guid id);
    
}