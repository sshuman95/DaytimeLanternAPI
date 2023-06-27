using DaytimeLanternAPI.Models.Workout;

namespace DaytimeLanternAPI.Services.Models
{
    public interface IWorkoutService
    {
        public Task<IEnumerable<Workout>> GetWorkouts();

        public Task<Workout> PostWorkout(CreateWorkoutRequest workoutRequest);

        public Task<Workout?> GetWorkout(Guid id);

        public Task PutWorkout(Guid id, UpdateWorkoutRequest workoutRequest);

        public Task DeleteWorkout(Guid id);

        public bool WorkoutExists(Guid id);
    }
}
