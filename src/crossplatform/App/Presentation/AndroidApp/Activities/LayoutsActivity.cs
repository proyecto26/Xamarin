using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace AndroidApp
{
    [Activity(Label = "@string/Layouts")]
    public class LayoutsActivity : AppCompatActivity
    {
        Button customViewGroupActivityButton, customListViewActivityButton;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Layouts);
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            customViewGroupActivityButton = FindViewById<Button>(Resource.Id.customViewGroupActivityButton);
            customViewGroupActivityButton.Click += delegate { StartActivity<LayoutCustomViewGroup>(); };

            customListViewActivityButton = FindViewById<Button>(Resource.Id.customListViewActivityButton);
            customListViewActivityButton.Click += delegate { StartActivity<LayoutListItem>(); };
        }

        private void StartActivity<T>()
        {
            StartActivity(new Android.Content.Intent(this, typeof(T)));
        }
    }
}