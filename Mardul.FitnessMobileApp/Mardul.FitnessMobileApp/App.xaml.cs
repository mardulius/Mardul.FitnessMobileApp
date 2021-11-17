using Mardul.FitnessMobileApp.Service;
using Mardul.FitnessMobileApp.View;
using Refit;
using System;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mardul.FitnessMobileApp
{
    public partial class App : Application
    {


        private const string MainWebApiUrl = "http://192.168.1.34:5030";



        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();

            

        }

        protected override async void OnStart()
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {

                await Shell.Current.GoToAsync("//NoConnectPage");

                return;
            }
           
            await AuthCheck();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        public async Task AuthCheck()
        {
            var OauthToken = await SecureStorage.GetAsync("oauth_token");
            if(OauthToken != null)
            {
                var ApiRequest = RestService.For<IFitnessWebApi>(MainWebApiUrl);
                var ApiResponse = await ApiRequest.GetAuth(OauthToken);
                if (ApiResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    await Shell.Current.GoToAsync("//Profile");
                }
                else return;
            }
           
        }
  

    }
}
