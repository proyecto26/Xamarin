using Android.App;
using Android.Widget;
using Android.OS;
using PCL.Interfaces;
using AndroidApp.PlatformSpecific;
using PCL.Helpers;
using System;

namespace AndroidApp
{
    [Activity(Label = "@string/ApplicationName", MainLauncher = true, Icon = "@drawable/Icon")]
    public class MainActivity : Activity
    {
        string translatedNumber = string.Empty;
        EditText phoneNumberText;
        Button translateButton, callButton, callHistoryButton, validateActivityButton;
        CurrentPlatform currentPlatform;
        PhoneTranslator translator = new PhoneTranslator();
        static readonly System.Collections.Generic.List<string> phoneNumbers = new System.Collections.Generic.List<string>();

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            //Change the icon at runtime
            //this.ActionBar.SetIcon(Android.Resource.Drawable.Icon);

            SetContentView(Resource.Layout.Main);
            this.Initialize();
        }

        private void Initialize()
        {
            currentPlatform = new CurrentPlatform(new MessageDialog(this));
            phoneNumberText = FindViewById<EditText>(Resource.Id.phoneNumberText);
            translateButton = FindViewById<Button>(Resource.Id.translateButton);
            callButton = FindViewById<Button>(Resource.Id.callButton);
            callHistoryButton = FindViewById<Button>(Resource.Id.callHistoryButton);
            validateActivityButton = FindViewById<Button>(Resource.Id.validateActivityButton);

            callButton.Enabled = false;
            translateButton.Click += TranslateButton_Click;
            callButton.Click += CallButton_Click;
            callHistoryButton.Click += CallHistoryButton_Click;
            validateActivityButton.Click += ValidateActivityButton_Click;

            //Show the path of a file
            this.ShowFilePath("database.db");
        }

        private void ValidateActivityButton_Click(object sender, EventArgs e)
        {
            var newValidateActivityIntent = new Android.Content.Intent(this, typeof(ValidateActivity));
            StartActivity(newValidateActivityIntent);
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

        void ShowFilePath(string fileName)
        {
            var Utilities = new SharedProject.Utilities();
            new AlertDialog.Builder(this)
                .SetMessage(Utilities.GetFilePath(fileName))
                .Show();
        }

        protected override void OnResume()
        {
            base.OnResume();
            //Your code when the app resumes
        }

        protected override void OnPause()
        {
            base.OnPause();
            //Your code when the app is paused
        }
    }
}

