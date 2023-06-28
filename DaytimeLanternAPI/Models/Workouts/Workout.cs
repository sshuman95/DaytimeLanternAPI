using DaytimeLanternAPI.Models.Exercises;

namespace DaytimeLanternAPI.Models.Workouts
{
    public class Workout
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public List<Exercise>? Exercises { get; set; }

    }
}
