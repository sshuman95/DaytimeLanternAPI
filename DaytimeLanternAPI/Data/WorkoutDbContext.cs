using DaytimeLanternAPI.Models;
using DaytimeLanternAPI.Models.Workout;
using Microsoft.EntityFrameworkCore;

namespace DaytimeLanternAPI.Data
{
    public class WorkoutDbContext: DbContext
    {
            public WorkoutDbContext(DbContextOptions<WorkoutDbContext> options) : base(options) { }

            public DbSet<Workout> Workouts { get; set; }

    }
}
