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
    public partial class WorkoutsPage : ContentPage
    {
        private WorkoutViewModel viewModel;


        public WorkoutsPage()
        {
            InitializeComponent();
            viewModel = new WorkoutViewModel() { Navigation = this.Navigation };
            BindingContext = viewModel;
        }


        protected override async void OnAppearing()
        {
            await viewModel.GetWorkout();
            base.OnAppearing();
        }

        
    }
}