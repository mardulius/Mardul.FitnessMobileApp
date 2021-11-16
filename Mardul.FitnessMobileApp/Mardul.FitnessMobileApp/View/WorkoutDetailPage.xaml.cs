using Mardul.FitnessMobileApp.Model;
using Mardul.FitnessMobileApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mardul.FitnessMobileApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WorkoutDetailPage : ContentPage
    {
        public WorkoutDetailViewModel viewModel;
        public WorkoutDetailPage( Workout workout)
        {
            InitializeComponent();
            viewModel = new WorkoutDetailViewModel() { Navigation = this.Navigation };
            viewModel.Workout = workout;
            BindingContext = viewModel; 

        }

        protected override void OnAppearing()
        {
            viewModel.GetWorkoutExercises();
            base.OnAppearing();
        }
    }
}