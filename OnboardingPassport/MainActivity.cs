using System;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using System.IO;
using SQLite;
using Android.Content;

namespace OnboardingPassport
{
	[Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]

    
	public class MainActivity : AppCompatActivity
	{
        ProgressBar pointsBar;
        ListView challengesList;
        ListView leaderboardsList;
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.activity_main);

            Intent intent = new Intent(this, typeof(MainActivity));
            string ADIDRecived = intent.GetStringExtra("ADID");

            var db = new SQLite.SQLiteConnection(dbPath);
            db.CreateTable<MainActivityDataBase>();
            var table = db.Table<MainActivityDataBase>();
        }
    }
}

