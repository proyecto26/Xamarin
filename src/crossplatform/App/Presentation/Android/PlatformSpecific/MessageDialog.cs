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
using PCL.Interfaces;

namespace Android.PlatformSpecific
{
    public class MessageDialog : IMessageDialog
    {
        Context appContext;
        public MessageDialog(Context context)
        {
            appContext = context;
        }

        public void ShowMessage(string message, string title = null, string okText = null, EventHandler okHandler = null, string cancelText = null, EventHandler cancelHandler = null)
        {
            var builder = new AlertDialog.Builder(appContext);
            var alert = builder.Create();
            alert.SetTitle(title);
            alert.SetIcon(Resource.Drawable.Icon);
            alert.SetMessage(message);
            alert.SetButton(okText ?? "Ok", (s, ev) => { okHandler?.Invoke(s, ev); });
            if(cancelText != null || cancelHandler != null)
            {
                alert.SetButton2(cancelText ?? "Cancel", (s, ev) => { cancelHandler?.Invoke(s, ev); });
            }
            alert.Show();
        }
    }
}