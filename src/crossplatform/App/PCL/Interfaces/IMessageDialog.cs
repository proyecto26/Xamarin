using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCL.Interfaces
{
    public interface IMessageDialog
    {
        void ShowMessage(string message, string title = null, string okText = null, EventHandler okHandler = null, string cancelText = null, EventHandler cancelHandler = null);
    }
}
