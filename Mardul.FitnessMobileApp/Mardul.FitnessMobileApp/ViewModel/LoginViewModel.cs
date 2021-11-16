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
   public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }
        public Command RegisterCommand { get; }
        public User User { get; set; }
        //private const string MainWebApiUrl = "http://192.168.1.34:5030/api";
        private const string MainWebApiUrl = "http://192.168.1.34:5030/";
       

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
            RegisterCommand = new Command(OnRegisterClicked);
            User = new User();
     
        }


        public async Task<Token> Login(User user)
        {
            
            var ApiRequest = RestService.For<IFitnessWebApi>(MainWebApiUrl);
            var ApiResponse = await ApiRequest.Login(user);
            if(ApiResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var token = ApiResponse.Content;
                return token;
            }
            else
            {
               
                return null;
            }
          
        }


        
        private async void OnLoginClicked(object obj)
        {
            
            var AuthResponse = await Login(User);
            if (AuthResponse != null)
            {
                await SecureStorage.SetAsync("oauth_token", "Bearer " + AuthResponse.accessToken);
                await Shell.Current.GoToAsync("//Profile");
            }
            else
            {

                var CurrentPage =  (LoginPage)(Shell.Current.CurrentPage);
                CurrentPage.ChangeLabel();
                await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
            }



        }

        private async void OnRegisterClicked(object obj)
        {
            await Shell.Current.GoToAsync("//RegPage");
        }
    }
}
