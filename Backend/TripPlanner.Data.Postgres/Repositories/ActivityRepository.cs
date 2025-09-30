using Microsoft.EntityFrameworkCore;
using TripPlanner.Domain;

namespace TripPlanner.Data.Postgres.Repositories;

public class ActivityRepository(DatabaseContext context) : IActivityRepository
{
    public async Task<Activity> CreateAsync(Activity activity)
    {
        var entity = Entities.Activity.FromDomain(activity);
        context.Activities.Add(entity);
        await context.SaveChangesAsync();
        return entity.ToDomain();
    }

    public async Task<Activity?> GetByIdAsync(Guid id)
    {
        return (await context.Activities.FindAsync(id))?.ToDomain();
    }

    public async Task<IEnumerable<Activity>> GetAllAsync()
    {
        return await context.Activities.Select(activity => activity.ToDomain())
            .ToListAsync();
    }

    public async Task UpdateAsync(Activity activity)
    {
        var entity =  await context.Activities.FindAsync(activity.Id);
        if (entity is null)
        {
            throw new Exception("Entity not found");
        }
        entity.Name = activity.Name;
        entity.Category = activity.Category;
        entity.Rating = activity.Rating;
        entity.Price = activity.Price;
        entity.City = activity.City;
        
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await context.Activities.FindAsync(id);
        if (entity is null)
        {
            throw new Exception("Entity not found");
        }

        context.Activities.Remove(entity);
        await context.SaveChangesAsync();
    }
}