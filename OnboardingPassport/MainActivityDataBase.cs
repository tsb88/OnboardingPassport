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
        public string EventName { get; set; }
        public int Points { get; set; }


        public MainActivityDataBase(string id, string eventName, int points)
        {
            ADID = id;
            EventName = eventName;
            Points = points;
        }

        public MainActivityDataBase()
        {

        }
    }

    class Events
    {
        public string EventName { get; set; }
        public int Points { get; set; }


        public Events(string eventName, int points)
        {
            EventName = eventName;
            Points = points;
        }

        public Events()
        {

        }
    }
}