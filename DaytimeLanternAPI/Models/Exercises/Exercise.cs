using DaytimeLanternAPI.Models.Workouts;


namespace DaytimeLanternAPI.Models.Exercises
{
    public class Exercise
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public Guid? WorkoutId { get; set; }

        public string? Description { get; set; }

        public int Reps { get; set; }

        public decimal Weight { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public virtual Workout? Workout { get; set; }
    }
}
