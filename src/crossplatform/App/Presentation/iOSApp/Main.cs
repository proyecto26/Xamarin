using iOSApp.PlatformSpecific;
using PCL.Helpers;
using UIKit;

namespace iOSApp
{
    public class Application
    {
        public static CurrentPlatform currentPlatform;
        // This is the main entry point of the application.
        static void Main(string[] args)
        {
            currentPlatform = new CurrentPlatform(new MessageDialog());

            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.
            UIApplication.Main(args, null, "AppDelegate");
        }
    }
}