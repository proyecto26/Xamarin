using System;
using iOSApp.PlatformSpecific;
using PCL.Helpers;
using UIKit;

namespace iOSApp
{
    public partial class CallsController : UIViewController
    {
        string translatedNumber = string.Empty;


        public CallsController() : base("CallsController", null)
        {
        }

		public CallsController(IntPtr p) : base(p)
        {
		}

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            translatedNumber = string.Empty;

            translateButton.TouchUpInside += TranslateButton_TouchUpInside;
            callButton.TouchUpInside += CallButton_TouchUpInside;
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        void TranslateButton_TouchUpInside(object sender, EventArgs e)
        {
            PhoneTranslator translator = new PhoneTranslator();
            translatedNumber = translator.ToNumber(phoneNumberText.Text);
			if (string.IsNullOrWhiteSpace(translatedNumber))
			{
                callButton.SetTitle("Llamar", UIControlState.Disabled);
				//callButton.Enabled = false;
			}
			else
			{
				callButton.SetTitle($"Llamar al {translatedNumber}", UIControlState.Normal);
				callButton.Enabled = true;
			}
        }

        void CallButton_TouchUpInside(object sender, EventArgs e)
        {
            Application.currentPlatform.Dialog.ShowMessage(
				$"Llamar al {translatedNumber}?", null, "Llamar",
				delegate
				{
					var url = new Foundation.NSUrl($"tel:{translatedNumber}");

					if (!UIApplication.SharedApplication.OpenUrl(url))
					{
						Application.currentPlatform.Dialog.ShowMessage(
                            "El esquema 'tel:' no es soportado en este Dispositivo",
                            "No soportado"
                        );
					}
            },
				"Cancelar"
			);
		}
    }
}

