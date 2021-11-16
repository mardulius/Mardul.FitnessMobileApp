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
    public partial class RegPage : ContentPage
    {
        public RegPage()
        {
            InitializeComponent();
            this.BindingContext = new RegisterViewModel();
        }

        public void ChangeLabel()
        {
            Validation.IsVisible = true;
            EntryPassword.Text = "";
            EntryPasswordConfirm.Text = "";
        }

    }
}