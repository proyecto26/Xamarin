using Android.App;
using Android.Widget;
using Android.OS;
using SALLab05;
using PCL.Interfaces;
using Android.PlatformSpecific;
using PCL.Helpers;
using System;

namespace Android
{
    [Activity(Label = "@string/ApplicationName", MainLauncher = true, Icon = "@drawable/Icon")]
    public class MainActivity : Activity
    {
        string translatedNumber = string.Empty;
        TextView txtResult;
        EditText phoneNumberText;
        Button translateButton, callButton;
        CurrentPlatform currentPlatform;
        PhoneTranslator translator = new PhoneTranslator();

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            //Change the icon at runtime
            //this.ActionBar.SetIcon(Android.Resource.Drawable.Icon);

            SetContentView(Resource.Layout.Main);
            this.Initialize();

            currentPlatform = new CurrentPlatform(new MessageDialog(this));

            //Example to validate authentication
            //this.ValidateTiCapacitacionAccount();

            //Show the path of a file
            this.ShowFilePath("database.db");
        }

        private void Initialize()
        {
            phoneNumberText = FindViewById<EditText>(Resource.Id.phoneNumberText);
            translateButton = FindViewById<Button>(Resource.Id.translateButton);
            callButton = FindViewById<Button>(Resource.Id.callButton);
            txtResult = FindViewById<TextView>(Resource.Id.txtResult);

            callButton.Enabled = false;
            translateButton.Click += TranslateButton_Click;
            callButton.Click += CallButton_Click;
        }

        private void CallButton_Click(object sender, EventArgs e)
        {
            currentPlatform.Dialog.ShowMessage(
                $"Llamar al número {translatedNumber}?", null, "Llamar",
                delegate
                {
                    var callIntent = new Android.Content.Intent(Android.Content.Intent.ActionCall);
                    callIntent.SetData(Android.Net.Uri.Parse($"tel:{translatedNumber}"));
                    StartActivity(callIntent);
                },
                "Cancelar"
            );
        }

        private void TranslateButton_Click(object sender, EventArgs e)
        {
            translatedNumber = translator.ToNumber(phoneNumberText.Text);
            if (string.IsNullOrWhiteSpace(translatedNumber))
            {
                callButton.Text = "Llamar";
                callButton.Enabled = false;
            }
            else
            {
                callButton.Text = $"Llamar al {translatedNumber}";
                callButton.Enabled = true;
            }
        }

        async void ValidateTiCapacitacionAccount()
        {
            var serviceClient = new ServiceClient();
            string studentEmail = "jdnichollsc@hotmail.com";
            string password = "...";

            string deviceId = Android.Provider.Settings.Secure.GetString(ContentResolver, Android.Provider.Settings.Secure.AndroidId);

            var result = await serviceClient.ValidateAsync(studentEmail, password, deviceId);

            txtResult.Text = $"{result.Status}\n{result.Fullname}\n{result.Token}";
            //currentPlatform.Dialog.ShowMessage("Result", $"{result.Status}\n{result.Fullname}\n{result.Token}");
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

