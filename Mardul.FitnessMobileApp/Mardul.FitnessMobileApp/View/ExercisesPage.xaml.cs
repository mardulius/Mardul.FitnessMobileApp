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
    public partial class ExercisesPage : ContentPage
    {
        private ExercisesViewModel viewModel;
        public ExercisesPage()
        {
            InitializeComponent();
            viewModel = new ExercisesViewModel { Navigation = this.Navigation };
            BindingContext = viewModel;
        }

        

        protected override async void OnAppearing()
        {
            await viewModel.GetExercise();
            ExerciseList.ItemsSource = viewModel.ExercisesGroups;
            base.OnAppearing();
           
        }
    }
}