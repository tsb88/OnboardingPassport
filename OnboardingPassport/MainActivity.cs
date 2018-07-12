using System;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;

namespace OnboardingPassport
{
	[Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
	public class MainActivity : AppCompatActivity
	{
        ProgressBar pointsBar; //progress bar
        ListView challengesList; //list of challenges
        ListView leaderboardsList; //list of leaderboards
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.activity_main);

            pointsBar = FindViewById<ProgressBar>(Resource.Id.progressBar);
            challengesList = FindViewById<ListView>(Resource.Id.listViewChallenges);
            leaderboardsList = FindViewById<ListView>(Resource.Id.listViewLeaderboards);
		}

        public void loadChallengesList()
        {

        }

        public void loadLeaderboardsList()
        {

        }
	}
}

