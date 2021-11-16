﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Mardul.FitnessMobileApp.Model
{
    public class Exercise
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("muscleGroupName")]
        public string MuscleGroupName { get; set; }
    }
}
