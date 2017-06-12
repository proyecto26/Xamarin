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
        Button validateActivityButton, counterActivityButton, callsButton, manageResourcesButton, mediaPlayerActivityButton, manageAssetsActivityButton;
        CurrentPlatform currentPlatform;

        protected override void OnCreate(Bundle bundle)
        {
            Android.Util.Log.Debug("AppLog", "Home Activity - OnCreate");

            base.OnCreate(bundle);

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
            counterActivityButton = FindViewById<Button>(Resource.Id.counterActivityButton);
            mediaPlayerActivityButton = FindViewById<Button>(Resource.Id.mediaPlayerActivityButton);
            manageAssetsActivityButton = FindViewById<Button>(Resource.Id.manageAssetsActivityButton);

            callsButton.Click += CallsButton_Click;
            manageResourcesButton.Click += ManageResourcesButton_Click;
            validateActivityButton.Click += ValidateActivityButton_Click;
            counterActivityButton.Click += CounterActivityButton_Click;
            mediaPlayerActivityButton.Click += mediaPlayerActivityButton_Click;
            manageAssetsActivityButton.Click += ManageAssetsActivityButton_Click;
        }

        private void ManageAssetsActivityButton_Click(object sender, EventArgs e)
        {
            StartActivity(new Android.Content.Intent(this, typeof(ManageAssetsActivity)));
        }

        private void mediaPlayerActivityButton_Click(object sender, EventArgs e)
        {
            StartActivity(new Android.Content.Intent(this, typeof(MediaPlayerActivity)));
        }

        private void CounterActivityButton_Click(object sender, EventArgs e)
        {
            StartActivity(new Android.Content.Intent(this, typeof(CounterActivity)));
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
                .SetMessage($"Path file: {Utilities.GetFilePath(fileName)}")
                .Show();
        }

        /// <summary>
        /// Your code when the activity starts
        /// </summary>
        /// <example>
        /// - Update variables of views.
        /// </example>
        protected override void OnStart()
        {
            Android.Util.Log.Debug("AppLog", "Home Activity - OnCreate");
            base.OnStart();
        }

        /// <summary>
        /// Your code when the activity resumes
        /// </summary>
        /// <example>
        /// - Increase frame rate for games.
        /// - Start animations.
        /// - Listen to GPS updates.
        /// - Show alerts and dialogs.
        /// - Connect to external event handlers.
        /// </example>
        protected override void OnResume()
        {
            Android.Util.Log.Debug("AppLog", "Home Activity - OnResume");
            base.OnResume();

            //Show the path of a file
            this.ShowFilePath("database.db");
        }

        /// <summary>
        /// Your code when the activity is paused
        /// </summary>
        /// <example>
        /// - Save pending changes.
        /// - Destroy objets.
        /// - Pause animations and reduce frame rate.
        /// - Diconnect to external event handlers.
        /// - Dismiss dialogs.
        /// </example>
        protected override void OnPause()
        {
            Android.Util.Log.Debug("AppLog", "Home Activity - OnPause");
            base.OnPause();
        }

        /// <summary>
        /// Your code when the activity is stopped
        /// </summary>
        /// <example>
        /// - Destroy objects before the activity is placed in the background.
        /// </example>
        protected override void OnStop()
        {
            Android.Util.Log.Debug("AppLog", "Home Activity - OnStop");
            base.OnStop();
        }

        /// <summary>
        /// Your code when the activity is destroyed
        /// </summary>
        /// <example>
        /// - End long-running processes (Background threads).
        /// </example>
        protected override void OnDestroy()
        {
            Android.Util.Log.Debug("AppLog", "Home Activity - OnDestroy");
            base.OnDestroy();
        }

        /// <summary>
        /// Your code when the activity is restarted
        /// </summary>
        protected override void OnRestart()
        {
            Android.Util.Log.Debug("AppLog", "Home Activity - OnRestart");
            base.OnRestart();
        }
    }
}

