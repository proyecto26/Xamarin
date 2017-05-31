using PCL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWP.PlatformSpecific
{
    public class MessageDialog : IMessageDialog
    {
        public async void ShowMessage(string message, string title = null, string okText = null, EventHandler okHandler = null, string cancelText = null, EventHandler cancelHandler = null)
        {
            var dialog = new Windows.UI.Popups.MessageDialog(message, title ?? string.Empty);
            dialog.Commands.Add(new Windows.UI.Popups.UICommand(okText ?? "Ok", (s) => { okHandler?.Invoke(s.Id, null); }, 0));
            if (cancelText != null || cancelHandler != null)
            {
                dialog.Commands.Add(new Windows.UI.Popups.UICommand(okText ?? "Cancel", (s) => { cancelHandler?.Invoke(s.Id, null); }, 1));
            }
            await dialog.ShowAsync();
        }
    }
}
