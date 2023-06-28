namespace DaytimeLanternAPI.Models.Workout
{
    public class UpdateWorkoutRequest
    {
        public Guid WorkoutId { get; set; }
        public string? Name { get; set; }
    }
}
