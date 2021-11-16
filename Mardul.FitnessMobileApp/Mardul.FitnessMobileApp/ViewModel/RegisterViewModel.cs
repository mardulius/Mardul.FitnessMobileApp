using Mardul.FitnessMobileApp.Model;
using Mardul.FitnessMobileApp.Service;
using Mardul.FitnessMobileApp.View;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Mardul.FitnessMobileApp.ViewModel
{
    public class RegisterViewModel
    {
        public Command RegisterCommand { get; }
        public Command CancelCommand { get; }
        public User User { get; set; }
        
        private const string MainWebApiUrl = "http://192.168.1.34:5030/";

        public RegisterViewModel()
        {
            RegisterCommand = new Command(OnRegisterClicked);
            CancelCommand = new Command(OnCancelClicked);
            User = new User();

        }
        public async Task<Token> Register(User user)
        {

            var ApiRequest = RestService.For<IFitnessWebApi>(MainWebApiUrl);
            var ApiResponse = await ApiRequest.Register(user);
            if (ApiResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var token = ApiResponse.Content;
                return token;
            }
            else
            {

                return null;
            }

        }

        public async void OnRegisterClicked()
        {
            var AuthResponse = await Register(User);
            if (AuthResponse != null)
            {
                await SecureStorage.SetAsync("oauth_token", "Bearer " + AuthResponse.accessToken);
                await Shell.Current.GoToAsync("//workouts");
            }
            else
            {

                var CurrentPage = (RegPage)(Shell.Current.CurrentPage);
                CurrentPage.ChangeLabel();
                await Shell.Current.GoToAsync($"//{nameof(RegPage)}");
            }
        }
        public async void OnCancelClicked()
        {
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }

    }
}
