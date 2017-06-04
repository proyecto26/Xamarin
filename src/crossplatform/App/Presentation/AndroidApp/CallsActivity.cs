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
using PCL.Helpers;
using Android.Support.V7.App;
using Toolbar = Android.Support.V7.Widget.Toolbar;
using AndroidApp.PlatformSpecific;

namespace AndroidApp
{
    [Activity(Label = "@string/Calls")]
    public class CallsActivity : AppCompatActivity
    {
        string translatedNumber = string.Empty;
        EditText phoneNumberText;
        CurrentPlatform currentPlatform;
        Button translateButton, callButton, callHistoryButton;
        PhoneTranslator translator = new PhoneTranslator();

        static readonly System.Collections.Generic.List<string> phoneNumbers = new System.Collections.Generic.List<string>();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            currentPlatform = new CurrentPlatform(new MessageDialog(this));

            SetContentView(Resource.Layout.Calls);
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            phoneNumberText = FindViewById<EditText>(Resource.Id.phoneNumberText);
            translateButton = FindViewById<Button>(Resource.Id.translateButton);
            callButton = FindViewById<Button>(Resource.Id.callButton);
            callHistoryButton = FindViewById<Button>(Resource.Id.callHistoryButton);

            callButton.Enabled = false;
            translateButton.Click += TranslateButton_Click;
            callButton.Click += CallButton_Click;
            callHistoryButton.Click += CallHistoryButton_Click;
        }

        private void CallHistoryButton_Click(object sender, EventArgs e)
        {
            var newCallHistoryIntent = new Android.Content.Intent(this, typeof(CallHistoryActivity));
            newCallHistoryIntent.PutStringArrayListExtra("phone_numbers", phoneNumbers);
            StartActivity(newCallHistoryIntent);
        }

        private void CallButton_Click(object sender, EventArgs e)
        {
            currentPlatform.Dialog.ShowMessage(
                $"{this.Resources.GetString(Resource.String.CallToNumber)} {translatedNumber}?", null, this.Resources.GetString(Resource.String.Call),
                delegate
                {
                    phoneNumbers.Add(translatedNumber);
                    callHistoryButton.Enabled = true;
                    var callIntent = new Android.Content.Intent(Android.Content.Intent.ActionCall);
                    callIntent.SetData(Android.Net.Uri.Parse($"tel:{translatedNumber}"));
                    StartActivity(callIntent);
                },
                this.Resources.GetString(Resource.String.Cancel)
            );
        }

        private void TranslateButton_Click(object sender, EventArgs e)
        {
            translatedNumber = translator.ToNumber(phoneNumberText.Text);
            if (string.IsNullOrWhiteSpace(translatedNumber))
            {
                callButton.Text = this.Resources.GetString(Resource.String.Call);
                callButton.Enabled = false;
            }
            else
            {
                callButton.Text = $"{this.Resources.GetString(Resource.String.CallTo)} {translatedNumber}";
                callButton.Enabled = true;
            }
        }
    }
}