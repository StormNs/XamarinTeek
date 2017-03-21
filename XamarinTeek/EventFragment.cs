using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using XamarinTeek.Resources;
using Android.Support.V4.App;
using System.Net;
using Newtonsoft.Json;
using System.IO;
using XamarinTeek.Object;

namespace XamarinTeek
{
    
    public class EventFragment : Fragment
    {
        public static FragmentManager dadFrag;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public static EventFragment NewInstance(FragmentManager fragM)
        {
            var eventFrag = new EventFragment { Arguments = new Bundle() };
            dadFrag = fragM;
            return eventFrag;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            this.Activity.Title = "Event Detail";
            View view = inflater.Inflate(Resource.Layout.EventDetail, container, false);

            // Get event info
            Bundle bundle = this.Arguments;
            var eventId = bundle.GetInt("EventId");
            var eventUrl = bundle.GetString("EventImageUrl");
            var eventDescription = bundle.GetString("EventDecription");
            var eventEntryPoint = bundle.GetInt("EventEntryPoint");

            var eventImg = Ultility.GetImageBitmapFromUrl(eventUrl);

            ImageView imgEvent = view.FindViewById<ImageView>(Resource.Id.imgEvent);
            //imgEvent.SetBackgroundResource(eventImg);
            imgEvent.SetImageBitmap(eventImg);
            imgEvent.RequestLayout();

            TextView txtDescription = view.FindViewById<TextView>(Resource.Id.txtDescription);
            txtDescription.Text = eventDescription;
            
            TextView txtPoint = view.FindViewById<TextView>(Resource.Id.txtPoint);
            txtPoint.Text = "Need " + eventEntryPoint + (eventEntryPoint > 1 ? " point" : " points") + " to join";
            
            Button btnJoin = view.FindViewById<Button>(Resource.Id.btnJoin);
            btnJoin.Click += delegate
            {
                Fragment fragment = ActivityOptionsFragment.NewInstance(dadFrag);
                JoinEventDialog dialog = new JoinEventDialog(this.Activity, dadFrag, fragment, bundle);
                FragmentTransaction trans = FragmentManager.BeginTransaction();
                dialog.Show(trans, "JoinDialog");
            };


           
            return view;
        }

    }
}