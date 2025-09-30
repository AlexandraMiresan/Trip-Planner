using TripPlanner.Domain;

namespace TripPlanner.Services.Interfaces;

public interface ITransportService
{
    Task<TransportType> CreateAsync(TransportType transportType);
    Task<TransportType?> GetByIdAsync(Guid id);
    Task<IEnumerable<TransportType>> GetAllAsync();
    Task UpdateAsync(TransportType transportType);
    Task DeleteAsync(Guid id);
}