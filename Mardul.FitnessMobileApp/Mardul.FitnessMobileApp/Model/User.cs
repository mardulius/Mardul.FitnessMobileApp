using System;
using System.Collections.Generic;
using System.Text;

namespace Mardul.FitnessMobileApp.Model
{
    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PasswordConfirm { get; set; }
    }
}
