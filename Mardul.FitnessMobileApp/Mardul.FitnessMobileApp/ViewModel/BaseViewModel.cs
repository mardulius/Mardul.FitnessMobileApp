using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Essentials;

namespace Mardul.FitnessMobileApp.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;


    }
}

