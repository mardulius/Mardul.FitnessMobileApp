using Mardul.FitnessMobileApp.Model;
using Mardul.FitnessMobileApp.Service;
using Refit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Mardul.FitnessMobileApp.ViewModel
{
    public class ExercisesViewModel : BaseViewModel
    {
        private bool isBusy;
        protected bool initialized = false;
        public INavigation Navigation { get; set; }
        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;
                OnPropertyChanged("IsBusy");
                OnPropertyChanged("IsLoaded");
            }
        }
        public bool IsLoaded
        {
            get { return !isBusy; }
        }
       
        public ObservableCollection<Grouping<string,Exercise>> ExercisesGroups { get; set; }    

        private const string MainWebApiUrl = "http://192.168.1.34:5030";
        private const string WorkoutWebApiUrl = MainWebApiUrl + "/Exersice";

        public Command AddWorkout { get; set; }
        public ExercisesViewModel()
        {
            ExercisesGroups = new ObservableCollection<Grouping<string, Exercise>>();
            
            isBusy = false;
            

        }
        public async Task GetExercise()
        {
            if (initialized == true) return;
            IsBusy = true;

            var OauthToken = await SecureStorage.GetAsync("oauth_token");
            var ApiResponse = RestService.For<IFitnessWebApi>(MainWebApiUrl);
            IEnumerable<Exercise> ExerciseDto = await ApiResponse.GetExercises(OauthToken);

            var groups = ExerciseDto.GroupBy(m => m.MuscleGroupName).Select(g => new Grouping<string, Exercise>(g.Key, g));
            ExercisesGroups = new ObservableCollection<Grouping<string, Exercise>>(groups);
           
            //для отладки
            Thread.Sleep(500);

            IsBusy = false;
            initialized = true;
        }


        public  void OnAddWorkoutClicked()
        {

            throw new NotImplementedException();
        }

        public  void AddWorkoutAsync()
        {
            throw   new NotImplementedException();

        }


    }
}
