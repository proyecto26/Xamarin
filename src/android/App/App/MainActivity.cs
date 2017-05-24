using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using App.Utilities;

namespace App
{
    [Activity(Label = "App", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        Button button;
        TextView txtView;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            button = FindViewById<Button>(Resource.Id.MyButton);
            txtView = FindViewById<TextView>(Resource.Id.txtView);

            button.Click += Button_Click;
        }

        private async void Button_Click(object sender, EventArgs e)
        {
            txtView.Text = "Loading...";

            string deviceId = Android.Provider.Settings.Secure.GetString(
                ContentResolver,
                Android.Provider.Settings.Secure.AndroidId
            );

            ServiceHelper helper = new ServiceHelper();
            var result = await helper.addUser("jdnichollsc@hotmail.com", "Juan David Nicholls Cardona", deviceId);
            if (result)
            {
                txtView.Text = "Loaded";
            }
            else
            {
                txtView.Text = "The user could not be added";
            }
        }
    }
}

