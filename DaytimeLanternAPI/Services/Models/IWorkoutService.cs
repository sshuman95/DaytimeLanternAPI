using DaytimeLanternAPI.Models.Workout;

namespace DaytimeLanternAPI.Services.Models
{
    public interface IWorkoutService
    {
        public Task<IEnumerable<Workout>> GetWorkouts();

        public Task<Workout> PostWorkout(CreateWorkoutRequest workoutRequest);

        public Task<Workout?> GetWorkout(Guid id);

        public Task PutWorkout(Guid id, Workout workout);

        public Task DeleteWorkout(Guid id);

        public bool IsInvalidContext();

        public bool WorkoutExists(Guid id);
    }
}
