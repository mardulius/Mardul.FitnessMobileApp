using Mardul.FitnessMobileApp.View;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mardul.FitnessMobileApp
{
    public partial class App : Application
    {
        public bool isLogged { get; set; }

        



        public App()
        {
           
        InitializeComponent();
         
               MainPage = new AppShell();
        
         
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }


  

    }
}
