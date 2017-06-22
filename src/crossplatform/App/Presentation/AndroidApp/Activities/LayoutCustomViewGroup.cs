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
using Android.Graphics;

namespace AndroidApp
{
    [Activity(Label = "LayoutCustomViewGroup")]
    public class LayoutCustomViewGroup : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(new CustomViewGroup(this));
        }
    }

    class CustomViewGroup : ViewGroup
    {
        Context viewGroupContext;
        public CustomViewGroup(Context context) : base(context)
        {
            this.viewGroupContext = context;
        }

        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            this.SetBackgroundColor(Color.DarkViolet);
            var view = new View(viewGroupContext);
            view.SetBackgroundColor(Color.White);
            view.Layout((int)(r * 0.1), (int)(b * 0.1), (int)(r * 0.9), (int)(b * 0.9));
            AddView(view);
        }
    }
}