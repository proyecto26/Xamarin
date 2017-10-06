// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace iOSApp
{
    [Register ("CallsController")]
    partial class CallsController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton callButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton callHistoryButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField phoneNumberText { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton translateButton { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (callButton != null) {
                callButton.Dispose ();
                callButton = null;
            }

            if (callHistoryButton != null) {
                callHistoryButton.Dispose ();
                callHistoryButton = null;
            }

            if (phoneNumberText != null) {
                phoneNumberText.Dispose ();
                phoneNumberText = null;
            }

            if (translateButton != null) {
                translateButton.Dispose ();
                translateButton = null;
            }
        }
    }
}