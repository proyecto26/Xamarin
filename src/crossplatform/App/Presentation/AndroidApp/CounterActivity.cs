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
    [Activity(Label = "@string/Counter")]
    public class CounterActivity : AppCompatActivity
    {
        int Counter = 0;
        Button clickMeButton;
        TextView ClickCounterText;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Counter);
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            if(savedInstanceState != null)
            {
                Counter = savedInstanceState.GetInt("Counter", 0);
            }
            ClickCounterText = FindViewById<TextView>(Resource.Id.ClickCounterText);
            clickMeButton = FindViewById<Button>(Resource.Id.clickMeButton);
            clickMeButton.Click += ClickMeButton_Click;

            ClickCounterText.Text = Resources.GetQuantityString(Resource.Plurals.numberOfClicks, Counter, Counter);
        }

        private void ClickMeButton_Click(object sender, EventArgs e)
        {
            Counter++;
            ClickCounterText.Text = Resources.GetQuantityString(Resource.Plurals.numberOfClicks, Counter, Counter);
        }

        /// <summary>
        /// Your code when the activity is being destroyed
        /// </summary>
        /// <example>
        /// - Persist key/value information.
        /// </example>
        protected override void OnSaveInstanceState(Bundle outState)
        {
            outState.PutInt("Counter", Counter);

            base.OnSaveInstanceState(outState);
        }
    }
}