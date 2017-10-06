using System;

using UIKit;

namespace iOSApp
{
    public partial class ValidateController : UIViewController
    {
        public ValidateController() : base("ValidateController", null)
        {
        }

		public ValidateController(IntPtr p) : base(p)
        {
		}

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        partial void ValidateActivityButton_TouchUpInside(UIButton sender)
        {
            //Remove the focus
            emailText.ResignFirstResponder();
            passwordText.ResignFirstResponder();
            //Validate activity
            ValidateActivity();
        }

        async void ValidateActivity(){
			var client = new SALLab06.ServiceClient();
			var result = await client.ValidateAsync(emailText.Text, passwordText.Text, this);
            Application.currentPlatform.Dialog.ShowMessage($"{result.Status}\n{result.FullName}\n{result.Token}", "Resultado");
        }
    }
}

