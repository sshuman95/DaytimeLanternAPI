using DaytimeLanternAPI.Models.Exercises;
using DaytimeLanternAPI.Models.Workouts;
using Microsoft.EntityFrameworkCore;

namespace DaytimeLanternAPI.Data
{
    public class WorkoutDbContext : DbContext
    {
        public WorkoutDbContext(DbContextOptions<WorkoutDbContext> options) : base(options) { }

        public DbSet<Workout> Workouts { get; set; }
        public DbSet<Exercise> Exercises { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Workout>()
                .HasMany(w => w.Exercises)
                .WithOne(e => e.Workout)
                .HasForeignKey(e => e.WorkoutId)
                .IsRequired(false);
        }

    }
}
