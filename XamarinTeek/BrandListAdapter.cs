
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
            var imageBitmap = Ultility.GetImageBitmapFromUrl(item.imageUrl);

            if(convertView == null)
            {
                convertView = context.LayoutInflater.Inflate(Resource.Layout.BrandRowView, null);
            }

            convertView.FindViewById<TextView>(Resource.Id.brandName).Text = item.name;
            convertView.FindViewById<ImageView>(Resource.Id.brandImage).SetImageBitmap(imageBitmap);

            return convertView;
        }

        
    }

}