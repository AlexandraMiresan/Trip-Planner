using TripPlanner.Data;
using TripPlanner.Domain;
using TripPlanner.Services.Interfaces;

namespace TripPlanner.Services;

public class ActivityService(IActivityRepository repository) : IActivityService
{
    public async Task<Activity> CreateAsync(Activity activity)
    {
        return await repository.CreateAsync(activity);
    }

    public async Task<Activity?> GetByIdAsync(Guid id)
    {
        var  activity = await repository.GetByIdAsync(id);
        if (activity is null)
        {
            throw new Exception($"Activity with id {id} not found");
        }
        return activity;
    }

    public async Task<IEnumerable<Activity>> GetAllAsync()
    {
        return await repository.GetAllAsync();
    }

    public async Task UpdateAsync(Activity activity)
    {
        var entity = await repository.GetByIdAsync(activity.Id);
        if (entity is null)
        {
            throw new Exception($"Activity with id {activity.Id} not found");
        }
        
        await repository.UpdateAsync(entity);
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await repository.GetByIdAsync(id);
        if (entity is null)
        {
            throw new Exception($"Activity with id {id} not found");
        }
        
        await repository.DeleteAsync(id);
    }
}