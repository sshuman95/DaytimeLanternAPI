﻿namespace DaytimeLanternAPI.Models.Workout
{
    public class Workout
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

    }
}
