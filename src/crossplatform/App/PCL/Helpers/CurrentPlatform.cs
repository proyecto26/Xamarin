using PCL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCL.Helpers
{
    public class CurrentPlatform
    {
        public IMessageDialog Dialog { get; set; }
        public CurrentPlatform(IMessageDialog platformDialog)
        {
            Dialog = platformDialog;

            //Show a dialog in the current platform
            //Dialog.ShowMessage("Hello world!", null, null, null, null, (s, ev) => { throw new Exception("LOL"); });
        }
    }
}
