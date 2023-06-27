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
            };
            _context.Workouts.Add(w);
            await _context.SaveChangesAsync();

            return w;
        }

        public async Task PutWorkout(Guid id, Workout workout)
        {
            try
            {
                _context.Entry(workout).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the workout.", ex);
            }
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
                throw new Exception("An error occurred while deleting the workout.", ex);
            }

        }


        public bool IsInvalidContext()
        {
            return _context.Workouts == null;
        }

        public bool WorkoutExists(Guid id)
        {
            return (_context.Workouts?.Any(e => e.Id == id)).GetValueOrDefault();
        }

    }
}
