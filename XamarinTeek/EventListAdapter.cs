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

namespace XamarinTeek
{
    class EventListAdapter : BaseAdapter<Event>
    {
        List<Event> items;
        Activity context;
        Android.Support.V4.App.FragmentManager fragManager;
        Android.Support.V4.App.Fragment fragment;
        EventListAdapterViewHolder holder;

        public EventListAdapter(Activity context, List<Event> listEvent, Android.Support.V4.App.FragmentManager fragManager,
        Android.Support.V4.App.Fragment fragment)
        {
            this.context = context;
            this.items = listEvent;
            this.fragManager = fragManager;
            this.fragment = fragment;
        }



        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = items[position];

            var imageBitmap = Ultility.GetImageBitmapFromUrl(item.ImageUrl);

            //do this to increase performance
            if (convertView == null)
            {
                convertView = context.LayoutInflater.Inflate(Resource.Layout.EventRowView, null);
                holder = new EventListAdapterViewHolder(convertView);
                convertView.Tag = holder;
            }
            else
            {
                holder = convertView.Tag as EventListAdapterViewHolder;
            }


            holder.getImageButton().SetImageBitmap(imageBitmap);
            holder.getDescription().Text = item.Description;

            Bundle arguments = new Bundle();
            arguments.PutString("BrandName", item.Name);
            arguments.PutString("BrandImageUrl", item.ImageUrl);
            fragment.Arguments = arguments;


            holder.getImageButton().Click += (sender, args) =>
            {
                fragManager.BeginTransaction().Replace(Resource.Id.content_frame, fragment)
                .Commit();

            };
            holder.getDescription().Click += (sender, args) =>
            {
                fragManager.BeginTransaction().Replace(Resource.Id.content_frame, fragment)
                .Commit();

            };


            return convertView;
        }

        //Fill in cound here, currently 0
        public override int Count
        {
            get
            {
                return items.Count;
            }
        }

        public override Event this[int position]
        {
            get
            {
                return items[position];

            }
        }
    }

    class EventListAdapterViewHolder : Java.Lang.Object
    {
        //Your adapter views to re-use
        //public TextView Title { get; set; }

        private View row;
        private TextView description;
        private ImageButton imageButton;

        public EventListAdapterViewHolder(View row)
        {
            this.row = row;
        }

        public TextView getDescription()
        {
            if (description == null)
            {
                description = (TextView) row.FindViewById(Resource.Id.EventDescription);
            }
            return description;
        }
        public ImageButton getImageButton()
        {
            if (imageButton == null)
            {
                imageButton = (ImageButton) row.FindViewById(Resource.Id.EventImage);
            }
            return imageButton;
        }
    }

}