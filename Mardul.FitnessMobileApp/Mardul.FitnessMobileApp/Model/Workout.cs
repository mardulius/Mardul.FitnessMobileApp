using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Mardul.FitnessMobileApp.Model
{
    public class Workout
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("exercises")]
        public List<Exercise> Exercises { get; set; }
    }
}
