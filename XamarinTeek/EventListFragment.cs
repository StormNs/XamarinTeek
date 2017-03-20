using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Support.V4.App;
using Android.Graphics;

namespace XamarinTeek
{
    public class EventListFragment : Fragment
    {

        private List<Event> listEvent;
        private ListView listEventView;
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public static EventListFragment NewInstance()
        {
            var eventListFrag = new EventListFragment { Arguments = new Bundle() };
            return eventListFrag;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            View view = inflater.Inflate(Resource.Layout.EventsList, container, false);

            listEventView = view.FindViewById<ListView>(Resource.Id.eventList);

            listEvent = new List<Event>();

            listEvent.Add(new Event(1, "Discount Half", "http://www.sabiohairandbeauty.co.uk/uploaded_images/images/icons_50percent.png", "This is 50% boys Buy itttttt goooo do it. Just do itt"));

            Bundle arguments = Arguments;
            String desired_string = arguments.GetString("BrandName");
            String imageUrl = arguments.GetString("BrandImageUrl");
            Bitmap image = Ultility.GetImageBitmapFromUrl(imageUrl);
             view.FindViewById<ImageView>(Resource.Id.eveBrandImage).SetImageBitmap(image); ;
               

            FragmentManager fragManager = FragmentManager;
            Fragment fragment = EventFragment.NewInstance();
            listEventView.Adapter = new EventListAdapter(this.Activity, listEvent, fragManager, fragment);
            
            return view;
        }
    }
}