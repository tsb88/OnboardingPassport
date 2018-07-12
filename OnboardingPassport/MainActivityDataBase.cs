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
    class MainActivityDataBase
    {
        public string ADID { get; set; }
        public string Points { get; set; }


        public MainActivityDataBase(string id, string points)
        {
            ADID = id;
            Points = points;
        }

        public MainActivityDataBase()
        {

        }


        //public override string ToString()
        //{
        //    return SenderID + " " + Content;
        //}
    }
}