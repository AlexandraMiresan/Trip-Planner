using Microsoft.EntityFrameworkCore;
using TripPlanner.Domain;

namespace TripPlanner.Data.Postgres.Repositories;

public class TransportRepository(DatabaseContext context) : ITransportRepository
{
    public async Task<TransportType> CreateAsync(TransportType transport)
    {
        var entity = Entities.TransportType.FromDomain(transport);
        context.Transports.Add(entity);
        await context.SaveChangesAsync();
        return entity.ToDomain();
    }

    public async Task<TransportType?> GetByIdAsync(Guid id)
    {
        return (await context.Transports.FindAsync(id))?.ToDomain();
    }

    public async Task<IEnumerable<TransportType>> GetAllAsync()
    {
        return await context.Transports.Select(transport => transport.ToDomain())
            .ToListAsync();
    }

    public async Task UpdateAsync(TransportType transport)
    {
        var entity = await context.Transports.FindAsync(transport.Id);
        if (entity is null)
        {
            throw new Exception("Entity not found");
        }

        entity.Mode = transport.Mode;
        entity.From = transport.From;
        entity.To = transport.To;
        entity.DurationMinutes = transport.DurationMinutes;
        entity.Cost = transport.Cost;
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await context.Transports.FindAsync(id);
        if (entity is null)
        {
            throw new Exception("Entity not found");
        }
        
        context.Transports.Remove(entity);
        await context.SaveChangesAsync();
    }
}