using PCL.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UWP.PlatformSpecific;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        CurrentPlatform currentPlatform;
        public MainPage()
        {
            this.InitializeComponent();

            currentPlatform = new CurrentPlatform(new MessageDialog());

            //Show the path of a file
            this.ShowFilePath("database.db");
        }

        void ShowFilePath(string fileName)
        {
            var Utilities = new SharedProject.Utilities();
            currentPlatform.Dialog.ShowMessage(Utilities.GetFilePath(fileName));
        }
    }
}
