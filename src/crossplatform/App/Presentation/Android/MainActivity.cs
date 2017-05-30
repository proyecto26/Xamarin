using Android.App;
using Android.Widget;
using Android.OS;
using SALLab03;

namespace Android
{
    [Activity(Label = "Android", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            //Example to validate authentication
            this.Validate();

            //Show the path of a file
            this.ShowFilePath("database.db");
        }

        async void Validate()
        {
            var serviceClient = new ServiceClient();
            string studentEmail = "jdnichollsc@hotmail.com";
            string password = "...";

            string deviceId = Android.Provider.Settings.Secure.GetString(ContentResolver, Android.Provider.Settings.Secure.AndroidId);

            var result = await serviceClient.ValidateAsync(studentEmail, password, deviceId);

            ShowDialog("Result", $"{result.Status}\n{result.Fullname}\n{result.Token}");
        }

        void ShowDialog(string title, string message, System.EventHandler<Content.DialogClickEventArgs> listener = null)
        {
            if (listener == null)
            {
                listener = (s, ev) => { };
            }
            var builder = new AlertDialog.Builder(this);
            var alert = builder.Create();
            alert.SetTitle(title);
            alert.SetIcon(Resource.Drawable.Icon);
            alert.SetMessage(message);
            alert.SetButton("Ok", listener);
            alert.Show();
        }

        void ShowFilePath(string fileName)
        {
            var Utilities = new SharedProject.Utilities();
            new AlertDialog.Builder(this)
                .SetMessage(Utilities.GetFilePath(fileName))
                .Show();
        }
    }
}

