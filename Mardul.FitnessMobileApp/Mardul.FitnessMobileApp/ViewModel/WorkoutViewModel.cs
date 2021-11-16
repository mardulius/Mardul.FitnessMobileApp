using Mardul.FitnessMobileApp.Model;
using Mardul.FitnessMobileApp.Service;
using Mardul.FitnessMobileApp.View;
using Refit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;


namespace Mardul.FitnessMobileApp.ViewModel
{
    public class WorkoutViewModel : BaseViewModel
    {
        protected bool initialized = false;
        private bool isBusy;
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
        public ObservableCollection<Workout> Workouts { get; set; }
        private const string MainWebApiUrl = "http://192.168.1.34:5030";
        private const string WorkoutWebApiUrl = MainWebApiUrl + "/Workout";
        public Command AddWorkoutCommand { get; set; }

        public Command SelectItemCommand { get; set; }
        private Workout selectedItem;
        public Workout SelectedItem
        {
            get { return selectedItem; }
            set
            {
                if (selectedItem != value)
                {
                    selectedItem = value;
                    OnPropertyChanged();

                    OnItemSelected(selectedItem);
                    
                }
            }
        }

        public WorkoutViewModel()
        {
            Workouts = new ObservableCollection<Workout>();
            isBusy = false;
            AddWorkoutCommand = new Command(OnAddWorkoutClicked);
            

        }

        public async Task GetWorkout()
        {
            if (initialized == true) return;
            IsBusy = true;

            var OauthToken = await SecureStorage.GetAsync("oauth_token");
            var ApiResponse = RestService.For<IFitnessWebApi>(MainWebApiUrl);
           IEnumerable<Workout> WorkoutsDto = await ApiResponse.GetWorkouts(OauthToken);

            foreach(var Workout in WorkoutsDto)
            {
               Workouts.Add(Workout);
            }
            //для отладки
           //Thread.Sleep(10000);

            IsBusy = false;
            initialized = true;
        }

        public async void OnAddWorkoutClicked()
        {
            await Navigation.PushAsync(new ExercisesPage());
        }
        
        public async void OnItemSelected(Workout workout)
        {
            

            await Navigation.PushAsync(new WorkoutDetailPage(workout));
        }
        



    }
}
