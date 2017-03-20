﻿
using Android.App;
using Android.Widget;
using System.Collections.Generic;
using Java.Lang;
using Android.Views;
using System;
using Android.Support.V4.App;
using Android.OS;

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
            //set content image here using bitmap read file from url
            var imageBitmap = Ultility.GetImageBitmapFromUrl(item.imageUrl);

            if(convertView == null)
            {
                convertView = context.LayoutInflater.Inflate(Resource.Layout.BrandRowView, null);
            }

            convertView.FindViewById<TextView>(Resource.Id.brandName).Text = item.name;
           var btnImage =  convertView.FindViewById<ImageView>(Resource.Id.btnBrandImage);
                btnImage.SetImageBitmap(imageBitmap);
            btnImage.Focusable = true;

            Bundle arguments = new Bundle();
            arguments.PutString("BrandName", item.name);
            arguments.PutString("BrandImageUrl", item.imageUrl);
            fragment.Arguments = arguments;
            btnImage.Click += (sender, args) =>
            {
                fragManager.BeginTransaction().Replace(Resource.Id.content_frame, fragment)
                .Commit();

            };
            return convertView;
        }

        
    }

}