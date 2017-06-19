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
using AlertDialog = Android.Support.V7.App.AlertDialog;

namespace AndroidApp.PlatformSpecific
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
            builder.SetTitle(title);
            builder.SetIcon(Resource.Drawable.Icon);
            builder.SetMessage(message);
            builder.SetPositiveButton(okText ?? appContext.Resources.GetString(Resource.String.Ok), (s, ev) => { okHandler?.Invoke(s, ev); });
            if(cancelText != null || cancelHandler != null)
            {
                builder.SetNegativeButton(cancelText ?? appContext.Resources.GetString(Resource.String.Cancel), (s, ev) => { cancelHandler?.Invoke(s, ev); });
            }
            builder.Show();
        }
    }
}