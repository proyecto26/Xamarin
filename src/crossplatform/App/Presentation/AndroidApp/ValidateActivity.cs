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

using SALLab06;

namespace AndroidApp
{
    [Activity(Label = "@string/ValidateActivity", Icon = "@drawable/Icon")]
    public class ValidateActivity : Activity
    {
        TextView resultText;
        EditText emailText, passwordText;
        Button validateButton;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Validate);

            resultText = FindViewById<TextView>(Resource.Id.resultText);
            emailText = FindViewById<EditText>(Resource.Id.emailText);
            passwordText = FindViewById<EditText>(Resource.Id.passwordText);
            validateButton = FindViewById<Button>(Resource.Id.validateButton);
            validateButton.Click += ValidateButton_Click;
        }

        private void ValidateButton_Click(object sender, EventArgs e)
        {
            this.ValidateAccount();
        }

        async void ValidateAccount()
        {
            var serviceClient = new ServiceClient();

            string deviceId = Android.Provider.Settings.Secure.GetString(ContentResolver, Android.Provider.Settings.Secure.AndroidId);

            var result = await serviceClient.ValidateAsync(emailText.Text, passwordText.Text, deviceId);

            resultText.Text = $"{result.Status}\n{result.Fullname}\n{result.Token}";
        }
    }
}