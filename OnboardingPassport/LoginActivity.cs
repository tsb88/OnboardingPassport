using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using SQLite;

namespace OnboardingPassport.Resources.layout
{
    [Activity(Label = "LoginActivity", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true, ScreenOrientation = ScreenOrientation.Portrait)]
    public class LoginActivity : AppCompatActivity
    {
        EditText loginUsername;
        EditText loginPassword;
        Button loginButton;

        readonly string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "dbTest.db3");
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.activity_login);
            
            loginUsername = FindViewById<EditText>(Resource.Id.loginUsername);
            loginPassword = FindViewById<EditText>(Resource.Id.loginPassword);
            loginButton = FindViewById<Button>(Resource.Id.loginButton);

            var db = new SQLite.SQLiteConnection(dbPath);
            db.CreateTable<LoginDataBase>();

            loginButton.Click += LoginButton_Click;
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            string ADID = loginUsername.Text;
            string Password = loginPassword.Text;

            var db = new SQLite.SQLiteConnection(dbPath);
            var table = db.Table<LoginDataBase>();
            var CheckPass = db.Query<LoginDataBase>("SELECT * FROM LoginDataBase");

            foreach (var item in CheckPass)
            {
                if(item.ADID == ADID)
                {
                    if(item.Password == Password)
                    {
                        Intent intent = new Intent(this, typeof(MainActivity));
                        intent.PutExtra("ADID", ADID);
                        StartActivity(intent);
                    }
                    else
                    {
                        Toast.MakeText(this, "Incorrect ADID or Password", ToastLength.Long).Show();
                    }
                }
                else
                {
                    Toast.MakeText(this, "No user found", ToastLength.Long).Show();
                }
            }
        }

    }
}
