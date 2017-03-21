using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using XamarinTeek.Object;
using Square.Picasso;

namespace XamarinTeek
{
    class ActivityListAdapter : BaseAdapter<Activities>
    {
        private List<Activities> items;
        private Activity context;

        public ActivityListAdapter(Activity context, List<Activities> items)
        {
            this.context = context;
            this.items = items;
        }

        public override Activities this[int position]
        {
            get
            {
                return items[position];
            }
        }

        public override int Count
        {
            get
            {
                return items.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = items[position];

            if (convertView == null)
            {
                convertView = context.LayoutInflater.Inflate(Resource.Layout.ActivityRowView, null);
            }

            ImageView imgActivity = convertView.FindViewById<ImageView>(Resource.Id.imgActivity);

            //replace load imageFromUrl with Picasso
            Picasso.With(context).Load(item.imageUrl).Into(imgActivity);
            

            TextView txtDescription = convertView.FindViewById<TextView>(Resource.Id.txtActivtyDescription);
            txtDescription.Text = item.name;

            Button btnActivity = convertView.FindViewById<Button>(Resource.Id.btnActivity);
            btnActivity.Click += delegate
            {
                Toast.MakeText(context, "You get " + item.prizePoint + " point(s)", ToastLength.Short);
            };

            return convertView;
        }
    }
}