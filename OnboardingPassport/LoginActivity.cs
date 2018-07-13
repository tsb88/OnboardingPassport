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
using Android.Util;

namespace OnboardingPassport.Resources.layout
{
    [Activity(Label = "LoginActivity", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true, ScreenOrientation = ScreenOrientation.Portrait)]
    public class LoginActivity : AppCompatActivity
    {
        EditText loginUsername;
        EditText loginPassword;
        Button loginButton;
        Button add;

        readonly string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "LoginDataBase.db3");
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_login);

            loginUsername = FindViewById<EditText>(Resource.Id.loginUsername);
            loginPassword = FindViewById<EditText>(Resource.Id.loginPassword);
            loginButton = FindViewById<Button>(Resource.Id.loginButton);
            add = FindViewById<Button>(Resource.Id.add);

            var db = new SQLiteConnection(dbPath);
            db.CreateTable<LoginDataBase>();

            loginButton.Click += LoginButton_Click;

            add.Click += delegate
            {
                //setup connection
                //var db = new SQLiteConnection(dbPath);

                ////setup table
                //db.CreateTable<Contact>();

                //create new contact obj
                LoginDataBase myContact = new LoginDataBase("YYG9ZZG", "TempPassword1");
                db.Insert(myContact);
                LoginDataBase myContact1 = new LoginDataBase("WYV1JGF", "TempPassword2");
                db.Insert(myContact1);
                LoginDataBase myContact3 = new LoginDataBase("ANT1ANT", "TempPassword2");
                db.Insert(myContact3);
            };
        }

        // testing upload
        private void LoginButton_Click(object sender, EventArgs e)
        {
            string ADID = loginUsername.Text;
            string Password = loginPassword.Text;

            var db = new SQLiteConnection(dbPath);
            var table = db.Table<LoginDataBase>();
            var CheckPass = db.Query<LoginDataBase>("SELECT * FROM LoginDataBase WHERE ADID = ?", ADID);

            foreach (var item in CheckPass)
            {
                if (item.Password == Password)
                {
                    Intent intent = new Intent(this, typeof(MainActivity));
                    intent.PutExtra("ADID", ADID);
                    StartActivity(intent);
                }
                else
                {
                    Toast.MakeText(this, "Incorect Information", ToastLength.Long).Show();
                }
            }
        }

    }
}