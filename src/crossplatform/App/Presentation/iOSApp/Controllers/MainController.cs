using System;

using UIKit;

namespace iOSApp
{
    public partial class MainController : UIViewController
    {
        public MainController() : base("MainController", null)
        {
		}

		public MainController(IntPtr p) : base(p)
        {
		}

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            callsButton.TouchUpInside += delegate { CallsButton_TouchUpInside("Calls"); };

		}

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        void CallsButton_TouchUpInside(string storyBoardName)
        {
			UIStoryboard board = UIStoryboard.FromName(storyBoardName, null);
			UIViewController ctrl = (UIViewController)board.InstantiateInitialViewController();
			ctrl.ModalTransitionStyle = UIModalTransitionStyle.CrossDissolve;
			this.PresentViewController(ctrl, true, null);
		}
    }
}

