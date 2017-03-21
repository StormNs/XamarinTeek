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
using Newtonsoft.Json;
using System.Net;
using System.IO;
using XamarinTeek.Object;

namespace XamarinTeek
{
    public class EventListFragment : Fragment
    {

        private List<Events> listEvent;
        private ListView listEventView;
        public static FragmentManager dadFrag;
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public static EventListFragment NewInstance(FragmentManager fraM)
        {
            var eventListFrag = new EventListFragment { Arguments = new Bundle() };
            dadFrag = fraM;
            return eventListFrag;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            this.Activity.Title = "Events";

            Bundle arguments = Arguments;
            int brandId = arguments.GetInt("BrandId");
            String desired_string = arguments.GetString("BrandName");
            String imageUrl = arguments.GetString("BrandImageUrl");
            Bitmap image = Ultility.GetImageBitmapFromUrl(imageUrl);
            View view = inflater.Inflate(Resource.Layout.EventsList, container, false);
            listEventView = view.FindViewById<ListView>(Resource.Id.eventList);
            view.FindViewById<ImageView>(Resource.Id.eveBrandImage).SetImageBitmap(image); ;

            string url = Ultility.SERVER_URL + "/Event/Event/getEventsByBrandId?brandId=" + brandId;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            HttpWebResponse myResp = (HttpWebResponse)request.GetResponse();
            Stream rebut = myResp.GetResponseStream();
            StreamReader readStream = new StreamReader(rebut, Encoding.UTF8); // Pipes the stream to a higher level stream reader with the required encoding format. 
            string info = readStream.ReadToEnd();
            listEvent = JsonConvert.DeserializeObject<List<Events>>(info);
            
            //FragmentManager fragManager = FragmentManager;
            Fragment fragment = EventFragment.NewInstance(dadFrag);
            listEventView.Adapter = new EventListAdapter(this.Activity, listEvent, dadFrag, fragment);
            
            return view;
        }
    }
}