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
using AndroidApp.Adapters;

namespace AndroidApp
{
    [Activity(Label = "@string/CustomListView")]
    public class LayoutListItem : AppCompatActivity
    {
        ListView colorsListView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.LayoutListItem);
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            colorsListView = FindViewById<ListView>(Resource.Id.colorsListView);
            colorsListView.Adapter = new ColorAdapter(this, Resource.Layout.ColorItem, Resource.Id.colorItemHeader, Resource.Id.colorItemSubHeader, Resource.Id.colorItemImage);
        }
    }
}