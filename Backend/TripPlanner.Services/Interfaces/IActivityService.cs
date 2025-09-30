using TripPlanner.Domain;

namespace TripPlanner.Services.Interfaces;

public interface IActivityService
{
    Task<Activity> CreateAsync(Activity activity);
    Task<Activity?> GetByIdAsync(Guid id);
    Task<IEnumerable<Activity>> GetAllAsync();
    Task UpdateAsync(Activity activity);
    Task DeleteAsync(Guid id);
}