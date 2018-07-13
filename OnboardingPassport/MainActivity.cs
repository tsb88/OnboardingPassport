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
        Toolbar toolbar;
        int Adder = 0;

        readonly string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "dbTest.db3");

        protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.activity_main);

            pointsBar = FindViewById<ProgressBar>(Resource.Id.progressBar);

            challengesList = FindViewById<ListView>(Resource.Id.listViewChallenges);
            leaderboardsList = FindViewById<ListView>(Resource.Id.listViewLeaderboards);


            toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);

            SetActionBar(toolbar);

            ActionBar.Title = "Onboarding Passport";
            toolbar.InflateMenu(Resource.Menu.menu_main);

            Intent intent = new Intent(this, typeof(MainActivity));
            string ADIDRecived = intent.GetStringExtra("ADID");

            var db = new SQLite.SQLiteConnection(dbPath);
            db.CreateTable<MainActivityDataBase>();
            var table = db.Table<MainActivityDataBase>();

            var AddPoints = db.Query<MainActivityDataBase>("SELECT * FROM MainActivityDataBase WHERE ADID = ?", ADIDRecived);

            foreach (var item in AddPoints)
            {
                Adder = item.Points + Adder;
            }
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.settings:
                    Intent intent = new Intent(this, typeof(Settings));
                    StartActivity(intent);
                    return true;
                case Resource.Id.profile:
                    Intent intent2 = new Intent(this, typeof(Profile));
                    StartActivity(intent2);
                    return true;
                case Resource.Id.logout:
                    Intent intent3 = new Intent(this, typeof(Logout));
                    StartActivity(intent3);
                    return true;
                default:
                    return true;
            }
        }
    }
}

