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
    [Register ("ProductController")]
    partial class ProductController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField categoryText { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton findButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField idText { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField nameText { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField priceText { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel productMessage { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField quantityText { get; set; }

        [Action ("FindButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void FindButton_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (categoryText != null) {
                categoryText.Dispose ();
                categoryText = null;
            }

            if (findButton != null) {
                findButton.Dispose ();
                findButton = null;
            }

            if (idText != null) {
                idText.Dispose ();
                idText = null;
            }

            if (nameText != null) {
                nameText.Dispose ();
                nameText = null;
            }

            if (priceText != null) {
                priceText.Dispose ();
                priceText = null;
            }

            if (productMessage != null) {
                productMessage.Dispose ();
                productMessage = null;
            }

            if (quantityText != null) {
                quantityText.Dispose ();
                quantityText = null;
            }
        }
    }
}