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
using Android.Support.V7.App;
using Toolbar = Android.Support.V7.Widget.Toolbar;

using SALLab11;

namespace AndroidApp
{
    [Activity(Label = "@string/ManageResources")]
    public class ManageResourcesActivity : AppCompatActivity
    {
        TextView userNameTextView, statusTextView, tokenTextView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.ManageResources);
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            userNameTextView = FindViewById<TextView>(Resource.Id.userNameTextView);
            statusTextView = FindViewById<TextView>(Resource.Id.statusTextView);
            tokenTextView = FindViewById<TextView>(Resource.Id.tokenTextView);

            this.ValidateAccount();
        }

        //TODO: Remove temporal code
        async void ValidateAccount()
        {
            var serviceClient = new ServiceClient();

            string deviceId = Android.Provider.Settings.Secure.GetString(ContentResolver, Android.Provider.Settings.Secure.AndroidId);

            var result = await serviceClient.ValidateAsync("jdnichollsc@hotmail.com", "...", deviceId);

            userNameTextView.Text = result.Fullname;
            statusTextView.Text = result.Status.ToString();
            tokenTextView.Text = result.Token;
        }
    }
}