using Mardul.FitnessMobileApp.Model;
using Mardul.FitnessMobileApp.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Mardul.FitnessMobileApp.ViewModel
{

    public class WorkoutDetailViewModel
    {
        public INavigation Navigation { get; set; }
       
        public ObservableCollection<Grouping<string, Exercise>> ExercisesGroups { get; set; }
        private Workout workout;

        public Workout Workout
        {
            get { return workout; }
            set 
            {
                workout = value;
                GetWorkoutExercises(value);
            }
        }
        
        public WorkoutDetailViewModel()
            
        {
          
            ExercisesGroups = new ObservableCollection<Grouping<string, Exercise>>();

        }


       public void GetWorkoutExercises(Workout workout)
        {
            
            var groups = workout.Exercises.GroupBy(m => m.MuscleGroupName).Select(g => new Grouping<string, Exercise>(g.Key, g));
            ExercisesGroups = new ObservableCollection<Grouping<string, Exercise>>(groups);


        }
    }
}
