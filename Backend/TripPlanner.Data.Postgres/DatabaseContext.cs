using Microsoft.EntityFrameworkCore;
using TripPlanner.Data.Postgres.Entities;


namespace TripPlanner.Data.Postgres;

public class DatabaseContext(DbContextOptions<DatabaseContext> options) : DbContext(options)
{
    public DbSet<Trip> Trips { get; set; }
    public DbSet<Activity> Activities { get; set; }
    public DbSet<TransportType> Transports { get; set; }
    public DbSet<Itinerary> Itineraries { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Trip>(entity =>
            entity.HasMany(s => s.Itinerary)
        );

        modelBuilder.Entity<Activity>()
            .Property(t => t.Category)
            .HasConversion<string>();

        modelBuilder.Entity<TransportType>()
            .Property(t => t.Mode)
            .HasConversion<string>();

        modelBuilder.Entity<Itinerary>(entity =>
            entity.HasMany(t => t.Transport));

        modelBuilder.Entity<Itinerary>(entity =>
            entity.HasMany(t => t.Activities));
    }
}