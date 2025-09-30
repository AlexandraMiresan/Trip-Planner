﻿using TripPlanner.Data;
using TripPlanner.Domain;


public interface ITripService
{
    Task<Trip> CreateAsync(Trip trip);
    Task<Trip?> GetByIdAsync(Guid id);
    Task<IEnumerable<Trip>> GetAllAsync();
    Task UpdateAsync(Trip trip);
    Task DeleteAsync(Guid id);
}
