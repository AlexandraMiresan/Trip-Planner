using TripPlanner.Data;
using TripPlanner.Domain;
using TripPlanner.Services.Interfaces;

namespace TripPlanner.Services;

public class TransportService(ITransportRepository repository) : ITransportService
{
    public async Task<TransportType> CreateAsync(TransportType transport)
    {
        return await repository.CreateAsync(transport);
    }

    public async Task<TransportType?> GetByIdAsync(Guid id)
    {
        var transport = await repository.GetByIdAsync(id);
        if (transport is null)
        {
            throw new Exception("Transport not found");
        }
        
        return transport;
    }

    public async Task<IEnumerable<TransportType>> GetAllAsync()
    {
        return await repository.GetAllAsync();
    }

    public async Task UpdateAsync(TransportType transport)
    {
        var entity = await repository.GetByIdAsync(transport.Id);
        if (entity is null)
        {
            throw new Exception("Transport not found");
        }
        
        await repository.UpdateAsync(entity);
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await repository.GetByIdAsync(id);
        if (entity is null)
        {
            throw new Exception("Transport not found");
        }
        
        await repository.DeleteAsync(id);
    }
}