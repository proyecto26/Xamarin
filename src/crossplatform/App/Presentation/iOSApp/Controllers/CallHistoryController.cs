using Foundation;
using System;
using UIKit;
using System.Collections.Generic;

namespace iOSApp
{
    public partial class CallHistoryController : UITableViewController
    {
        public CallHistoryController (IntPtr handle) : base (handle)
        {
            TableView.RegisterClassForCellReuse(typeof(UITableViewCell), CallHistoryCellId);
            TableView.Source = new CallHistoryDataSource(this);
        }

        public List<string> PhoneNumbers { get; set; }

        public NSString CallHistoryCellId = new NSString("CallHistoryCell");
    }

    class CallHistoryDataSource : UITableViewSource
    {
        CallHistoryController controller;
        public CallHistoryDataSource(CallHistoryController controller){
            this.controller = controller;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return controller.PhoneNumbers.Count;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell(controller.CallHistoryCellId);
            cell.TextLabel.Text = controller.PhoneNumbers[indexPath.Row];
            return cell;
        }
    }
}