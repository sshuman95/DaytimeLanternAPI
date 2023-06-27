using DaytimeLanternAPI.Data;
using DaytimeLanternAPI.Exceptions;
using DaytimeLanternAPI.Models.Workout;
using DaytimeLanternAPI.Services.Models;
using Microsoft.EntityFrameworkCore;

namespace DaytimeLanternAPI.Services
{
    public class WorkoutService : IWorkoutService
    {
        private readonly WorkoutDbContext _context;
        public WorkoutService(WorkoutDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Workout>> GetWorkouts()
        {
            return await _context.Workouts.ToListAsync();
        }

        public async Task<Workout?> GetWorkout(Guid id)
        {
            var workout = await _context.Workouts.FindAsync(id);
            return workout;
        }

        public async Task<Workout> PostWorkout(CreateWorkoutRequest request)
        {
            var w = new Workout()
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            };
            _context.Workouts.Add(w);
            await _context.SaveChangesAsync();

            return w;
        }

        public async Task PutWorkout(Guid id, UpdateWorkoutRequest workout)
        {
            if (!WorkoutExists(id))
            {
                throw new NotFoundException("Workout not found");
            };

            var existingWorkout = await _context.Workouts.FindAsync(id);

            if (existingWorkout == null)
            {
                throw new NotFoundException("Workout not found");
            }

            existingWorkout.Name = workout.Name;
            existingWorkout.UpdatedDate = DateTime.Now;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteWorkout(Guid id)
        {
            var workout = await _context.Workouts.FindAsync(id);
            if (workout == null)
            {
                throw new NotFoundException("Workout not found"); // Custom exception to handle not found scenarios
            }

            try
            {
                _context.Workouts.Remove(workout);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public bool WorkoutExists(Guid id)
        {
            return (_context.Workouts?.Any(e => e.Id == id)).GetValueOrDefault();
        }

    }
}
