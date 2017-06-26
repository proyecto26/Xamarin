
using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace AndroidApp
{
    [Activity(Label = "@string/Forms")]
    public class FormsActivity : AppCompatActivity
    {
        Button validateActivityButton, inlineLabelsActivityButton;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Forms);
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            validateActivityButton = FindViewById<Button>(Resource.Id.validateActivityButton);
            inlineLabelsActivityButton = FindViewById<Button>(Resource.Id.inlineLabelsActivityButton);

            validateActivityButton.Click += delegate { StartActivity<ValidateActivity>(); };
            inlineLabelsActivityButton.Click += delegate { StartActivity<InlineLabels>(); };
        }

        private void StartActivity<T>()
        {
            StartActivity(new Android.Content.Intent(this, typeof(T)));
        }
    }
}