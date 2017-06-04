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

namespace AndroidApp
{
    [Activity(Label = "@string/ManageResources")]
    public class ManageResourcesActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.ManageResources);
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            //Create controls dynamically
            //var viewGroup = Window.DecorView.FindViewById<ViewGroup>(Android.Resource.Id.Content);
            //var mainLayout = viewGroup.FindViewById<LinearLayout>(Resource.Id.main_content);

            //var headerImage = new ImageView(this);
            //headerImage.SetImageResource(Resource.Drawable.header_image);
            //mainLayout.AddView(headerImage);

            //var userNameTextView = new TextView(this);
            //userNameTextView.Text = GetString(Resource.String.UserName);
            //mainLayout.AddView(userNameTextView);
        }
    }
}