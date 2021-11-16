using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;


namespace Mardul.FitnessMobileApp.Model
{
    public class UserWorkout
    {
        [JsonPropertyName("workouts")]
        public List<Workout> Workouts { get; set; }
    }
}
