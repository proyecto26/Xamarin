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

namespace AndroidApp
{
    [Activity(Label = "InlineLabels")]
    public class InlineLabels : Activity
    {
        Button buttonValidate;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.InlineLabels);

            buttonValidate = FindViewById<Button>(Resource.Id.buttonValidate);
            buttonValidate.Click += ButtonValidate_Click;
        }

        private async void ButtonValidate_Click(object sender, EventArgs e)
        {
            var client = new SALLab14.ServiceClient();
            var result = await client.ValidateAsync(this);
            Android.App.AlertDialog.Builder builder = new AlertDialog.Builder(this);
            AlertDialog alert = builder.Create();
            alert.SetTitle("Resultado de la verificación");
            alert.SetIcon(Resource.Drawable.Icon);
            alert.SetMessage($"{result.Status}\n{result.FullName}\n{result.Token}");
            alert.SetButton("Ok", (s, ev) => { });
            alert.Show();
        }
    }
}