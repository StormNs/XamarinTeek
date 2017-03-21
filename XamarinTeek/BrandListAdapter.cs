
using Android.App;
using Android.Widget;
using System.Collections.Generic;
using Java.Lang;
using Android.Views;
using System;
using Android.Support.V4.App;
using Android.OS;
using Square.Picasso;

namespace XamarinTeek
{
    public class BrandListAdapter: BaseAdapter<Brand>
    {
        List<Brand> items;
        Activity context;
        Android.Support.V4.App.FragmentManager fragManager;
        Android.Support.V4.App.Fragment fragment;

        public BrandListAdapter(Activity context, List<Brand> items, 
            Android.Support.V4.App.FragmentManager trans, Android.Support.V4.App.Fragment frag) : base()
        {
            this.items = items;
            this.context = context;
            this.fragManager = trans;
            this.fragment = frag;
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
           
            
            if(convertView == null)
            {
                convertView = context.LayoutInflater.Inflate(Resource.Layout.BrandRowView, null);
            }

            convertView.FindViewById<TextView>(Resource.Id.brandName).Text = item.name;
           var btnImage =  convertView.FindViewById<ImageButton>(Resource.Id.btnBrandImage);

            //replace loadImageUrl with Picasso
            Picasso.With(context).Load(item.imageUrl).Into(btnImage);
                
            btnImage.Focusable = true;

            Bundle arguments = new Bundle();
            arguments.PutString("BrandName", item.name);
            arguments.PutString("BrandImageUrl", item.imageUrl);
            fragment.Arguments = arguments;
            btnImage.Click += (sender, args) =>
            {
               var trans =  fragManager.BeginTransaction();
                trans.Replace(Resource.Id.content_frame, fragment);
                trans.AddToBackStack(null);
                trans.Commit();

            };
            return convertView;
        }

        
    }
}