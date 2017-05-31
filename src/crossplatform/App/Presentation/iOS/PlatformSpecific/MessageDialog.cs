using PCL.Interfaces;
using System;
using UIKit;

namespace iOS.PlatformSpecific
{
    public class MessageDialog : IMessageDialog
    {
        public void ShowMessage(string message, string title = null, string okText = null, EventHandler okHandler = null, string cancelText = null, EventHandler cancelHandler = null)
        {
            UIApplication.SharedApplication.InvokeOnMainThread(() =>
            {
                var alertView = new UIAlertView(title ?? string.Empty, message, null, okText ?? "OK", cancelText ?? (cancelHandler != null ? "Cancel" : null));
                alertView.Clicked += (s, ev) => { okHandler?.Invoke(s, ev); };
                alertView.Canceled += (s, ev) => { cancelHandler?.Invoke(s, ev); };
                alertView.Show();
            });
        }
    }
}
