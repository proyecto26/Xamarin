using Android.App;
using Android.Widget;
using Android.OS;
using PCL.Interfaces;
using AndroidApp.PlatformSpecific;
using PCL.Helpers;
using System;
using Android.Support.V7.App;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace AndroidApp
{
    [Activity(Label = "@string/ApplicationName", MainLauncher = true, Icon = "@drawable/Icon")]
    public class MainActivity : AppCompatActivity
    {
        Button validateActivityButton, callsButton, manageResourcesButton;
        CurrentPlatform currentPlatform;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            //Change the icon at runtime
            //this.ActionBar.SetIcon(Android.Resource.Drawable.Icon);

            SetContentView(Resource.Layout.Main);
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            this.Initialize();
        }

        private void Initialize()
        {
            currentPlatform = new CurrentPlatform(new MessageDialog(this));
            validateActivityButton = FindViewById<Button>(Resource.Id.validateActivityButton);
            callsButton = FindViewById<Button>(Resource.Id.callsButton);
            manageResourcesButton = FindViewById<Button>(Resource.Id.manageResourcesButton);

            callsButton.Click += CallsButton_Click;
            manageResourcesButton.Click += ManageResourcesButton_Click;
            validateActivityButton.Click += ValidateActivityButton_Click;

            //Show the path of a file
            this.ShowFilePath("database.db");
        }

        private void ManageResourcesButton_Click(object sender, EventArgs e)
        {
            StartActivity(new Android.Content.Intent(this, typeof(ManageResourcesActivity)));
        }

        private void CallsButton_Click(object sender, EventArgs e)
        {
            StartActivity(new Android.Content.Intent(this, typeof(CallsActivity)));
        }

        private void ValidateActivityButton_Click(object sender, EventArgs e)
        {
            StartActivity(new Android.Content.Intent(this, typeof(ValidateActivity)));
        }

        void ShowFilePath(string fileName)
        {
            var Utilities = new SharedProject.Utilities();
            new Android.App.AlertDialog.Builder(this)
                .SetMessage(Utilities.GetFilePath(fileName))
                .Show();
        }

        protected override void OnResume()
        {
            base.OnResume();
            //Your code when the app resumes
        }

        protected override void OnPause()
        {
            base.OnPause();
            //Your code when the app is paused
        }
    }
}

