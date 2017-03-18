
using Android.App;
using Android.Widget;
using System.Collections.Generic;
using Java.Lang;
using Android.Views;
using System;

namespace XamarinTeek
{
    public class BrandListAdapter: BaseAdapter<Brand>
    {
        List<Brand> items;
        Activity context;


        public BrandListAdapter(Activity context, List<Brand> items) : base()
        {
            this.items = items;
            this.context = context;
        }

        public override int Count
        {
            get
            {
            return items.Count;

            }
        }

        public override Brand this[int position]
        {
            get
            {
                return items[position];
            }
        }

       
        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = items[position];
            //set content image here using bitmap read file from url

            if(convertView == null)
            {
                convertView = context.LayoutInflater.Inflate(Android.Resource.Layout.ActivityListItem, null);
            }

            convertView.FindViewById<TextView>(Android.Resource.Id.Text1).Text = item.name;

            return convertView;
        }

        
    }

}