using Android.App;
using Android.Widget;
using Android.OS;
using SALLab02;

namespace Android.App
{
    [Activity(Label = "Android.App", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            this.Validate();
        }

        private async void Validate()
        {
            var serviceClient = new ServiceClient();
            string studentEmail = "jdnichollsc@hotmail.com";
            string password = "...";

            string deviceId = Android.Provider.Settings.Secure.GetString(ContentResolver, Android.Provider.Settings.Secure.AndroidId);

            var result = await serviceClient.ValidateAsync(studentEmail, password, deviceId);

            ShowDialog("Result", $"{result.Status}\n{result.Fullname}\n{result.Token}");
        }

        private void ShowDialog(string title, string message)
        {
            var builder = new AlertDialog.Builder(this);
            var alert = builder.Create();
            alert.SetTitle(title);
            alert.SetIcon(Resource.Drawable.Icon);
            alert.SetMessage(message);
            alert.SetButton("Ok", (s, ev) => { });
            alert.Show();
        }
    }
}

