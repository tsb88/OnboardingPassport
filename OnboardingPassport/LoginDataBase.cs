using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace OnboardingPassport
{
    class LoginDataBase
    {
        public string ADID { get; set; }
        public string Password { get; set; }


        public LoginDataBase(string id, string password)
        {
            ADID = id;
            Password = Password;
        }

        public LoginDataBase()
        {

        }


        //public override string ToString()
        //{
        //    return SenderID + " " + Content;
        //}
    }
}