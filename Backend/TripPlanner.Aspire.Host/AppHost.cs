var builder = DistributedApplication.CreateBuilder(args);

// Ref: https://learn.microsoft.com/en-us/dotnet/aspire/database/postgresql-integration?tabs=dotnet-cli 
var postgresInstance = builder.AddPostgres("TripPlanner-Postgres")
    .WithPgAdmin()
    .WithLifetime(ContainerLifetime.Persistent);
var postgresdb = postgresInstance.AddDatabase("tripPlannerDb");

var api = builder.AddProject<Projects.TripPlanner_API>("TripPlanner-API")
    .WithReference(postgresdb)
    .WaitFor(postgresdb);

builder.Build().Run();