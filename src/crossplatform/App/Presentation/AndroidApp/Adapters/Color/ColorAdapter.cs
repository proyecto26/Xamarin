using Android.App;
using Android.Graphics;
using Android.Views;
using Android.Widget;
using System.Collections.Generic;

namespace AndroidApp.Adapters
{
    public class ColorAdapter : BaseAdapter<ColorItem>
    {
        private List<ColorItem> items;

        private Activity context;

        private int LayoutTemplate;

        private int ColorNameView;

        private int CodeView;

        private int ColorView;

        public override ColorItem this[int position]
        {
            get
            {
                return this.items[position];
            }
        }

        public override int Count
        {
            get
            {
                return this.items.Count;
            }
        }

        public ColorAdapter(Activity context, int layoutTemplate, int colorNameView, int codeView, int colorView)
        {
            this.context = context;
            this.items = Repository.GetItems();
            this.LayoutTemplate = layoutTemplate;
            this.ColorNameView = colorNameView;
            this.CodeView = codeView;
            this.ColorView = colorView;
        }

        public override long GetItemId(int position)
        {
            return (long)position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            ColorItem colorItem = this.items[position];
            View view = convertView;
            bool flag = view == null;
            if (flag)
            {
                view = this.context.LayoutInflater.Inflate(this.LayoutTemplate, null);
            }
            view.FindViewById<TextView>(this.ColorNameView).Text = colorItem.ColorName;
            view.FindViewById<TextView>(this.CodeView).Text = colorItem.Code;
            view.FindViewById<ImageView>(this.ColorView).SetBackgroundColor(colorItem.Color);
            return view;
        }
    }

    class Repository
    {
        public static List<ColorItem> GetItems()
        {
            List<ColorItem> list = new List<ColorItem>();
            list.Add(new ColorItem
            {
                Color = Color.DarkRed,
                ColorName = "Dark Red",
                Code = "8B0000"
            });
            list.Add(new ColorItem
            {
                Color = Color.SlateBlue,
                ColorName = "Slate Blue",
                Code = "6A5ACD"
            });
            list.Add(new ColorItem
            {
                Color = Color.ForestGreen,
                ColorName = "Forest Green",
                Code = "228B22"
            });
            list.Add(new ColorItem
            {
                Color = Color.BlueViolet,
                ColorName = "BlueViolet",
                Code = "8A2BE2 "
            });
            return list;
        }
    }
}