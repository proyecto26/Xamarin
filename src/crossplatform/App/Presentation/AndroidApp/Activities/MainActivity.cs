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
        Button formsActivityButton,
            counterActivityButton,
            callsButton,
            manageResourcesButton,
            mediaPlayerActivityButton,
            manageAssetsActivityButton,
            layoutsActivityButton;

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
            callsButton = FindViewById<Button>(Resource.Id.callsButton);
            manageResourcesButton = FindViewById<Button>(Resource.Id.manageResourcesButton);
            formsActivityButton = FindViewById<Button>(Resource.Id.formsActivityButton);
            counterActivityButton = FindViewById<Button>(Resource.Id.counterActivityButton);
            mediaPlayerActivityButton = FindViewById<Button>(Resource.Id.mediaPlayerActivityButton);
            manageAssetsActivityButton = FindViewById<Button>(Resource.Id.manageAssetsActivityButton);
            layoutsActivityButton = FindViewById<Button>(Resource.Id.layoutsActivityButton);

            callsButton.Click += delegate { StartActivity<CallsActivity>(); };
            manageResourcesButton.Click += delegate { StartActivity<ManageResourcesActivity>(); };
            formsActivityButton.Click += delegate { StartActivity<FormsActivity>(); };
            counterActivityButton.Click += delegate { StartActivity<CounterActivity>(); };
            mediaPlayerActivityButton.Click += delegate { StartActivity<MediaPlayerActivity>(); };
            manageAssetsActivityButton.Click += delegate { StartActivity<ManageAssetsActivity>(); };
            layoutsActivityButton.Click += delegate { StartActivity<LayoutsActivity>(); };
        }

        private void StartActivity<T>()
        {
            StartActivity(new Android.Content.Intent(this, typeof(T)));
        }

        /// <summary>
        /// When the activity starts
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
        /// When the activity resumes
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
        }

        /// <summary>
        /// When the activity is paused
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
        /// When the activity is stopped
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
        /// When the activity is destroyed
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
        /// When the activity is restarted
        /// </summary>
        protected override void OnRestart()
        {
            Android.Util.Log.Debug("AppLog", "Home Activity - OnRestart");
            base.OnRestart();
        }
    }
}

