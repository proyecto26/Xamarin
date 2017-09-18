using PCL.Interfaces;
using System;
using UIKit;

namespace iOSApp.PlatformSpecific
{
    public class MessageDialog : IMessageDialog
    {
        public void ShowMessage(string message, string title = null, string okText = null, EventHandler okHandler = null, string cancelText = null, EventHandler cancelHandler = null)
        {
            UIApplication.SharedApplication.InvokeOnMainThread(() =>
            {
                var alert = UIAlertController.Create(title ?? string.Empty, message, UIAlertControllerStyle.Alert);
                okText = okText ?? "Ok";
				alert.AddAction(UIAlertAction.Create(okText, UIAlertActionStyle.Default, (sender) => {
					okHandler?.Invoke(sender.Self, null);
				}));
                if(!string.IsNullOrEmpty(cancelText) || cancelHandler!= null){
                    cancelText = cancelText ?? "Cancel";
                    alert.AddAction(UIAlertAction.Create(cancelText, UIAlertActionStyle.Cancel, (sender) => {
						cancelHandler?.Invoke(sender.Self, null);
					}));
                }
                UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(alert, true, null);
            });
        }
    }
}
