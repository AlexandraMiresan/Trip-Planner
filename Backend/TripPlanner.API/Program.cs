using Microsoft.EntityFrameworkCore;
using Npgsql;
using TripPlanner.API.Endpoints.Activity;
using TripPlanner.Data.Postgres;
using TripPlanner.Services;

namespace TripPlanner.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddAuthorization();

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowFrontend",
                policy =>
                {
                    policy.WithOrigins("http://localhost:5173")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
        });

        builder.Services.AddOpenApi();
        builder.AddServiceDefaults();

        builder.AddPostgresData();
        builder.Services.AddServices();
        
        NpgsqlConnection.GlobalTypeMapper.EnableDynamicJson();
        
        var app = builder.Build();

        app.MapDefaultEndpoints();

        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/openapi/v1.json", "TripPlanner API");
                c.RoutePrefix = string.Empty;
            });
        }

        app.UseHttpsRedirection();
        app.UseCors("AllowFrontend");
        app.UseAuthorization();


        app.MapActivityEndpoints();
        

        using (var scope = app.Services.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
            db.Database.Migrate();
        }

        app.Run();
    }
}