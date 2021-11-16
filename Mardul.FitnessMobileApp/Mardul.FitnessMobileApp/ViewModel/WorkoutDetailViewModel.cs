using Mardul.FitnessMobileApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Mardul.FitnessMobileApp.ViewModel
{
    public class WorkoutDetailViewModel
    {
        public INavigation Navigation { get; set; }
        public ObservableCollection<Exercise> Exercises { get; set; }
        public Workout Workout;
        public WorkoutDetailViewModel()
            
        {
            
            Exercises = new ObservableCollection<Exercise>();
           
        }


       public void GetWorkoutExercises()
        {
            foreach(var exercise in Workout.Exercises)
            {
                 Exercises.Add(exercise);
            }
        }
    }
}
