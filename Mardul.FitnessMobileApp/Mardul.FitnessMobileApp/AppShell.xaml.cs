using Mardul.FitnessMobileApp.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Mardul.FitnessMobileApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

           Routing.RegisterRoute(nameof(NoConnectPage),typeof(NoConnectPage));
            //Routing.RegisterRoute(nameof(WorkoutDetailPage), typeof(WorkoutDetailPage));

        }
    }
}
