using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using XamarinTeek.Object;
using Android.Support.V4.App;
using System.Net;
using Newtonsoft.Json;
using System.IO;

namespace XamarinTeek
{
    public class ActivityOptionsFragment : Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public static ActivityOptionsFragment NewInstance()
        {
            var activityFrag = new ActivityOptionsFragment { Arguments = new Bundle() };
            return activityFrag;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            // Get event info
            Bundle bundle = this.Arguments;
            var eventId = bundle.GetInt("EventId");
            var eventUrl = bundle.GetString("EventImageUrl");
            var eventName = bundle.GetString("EventName");

            //get activity list
            string url = Ultility.SERVER_URL + "/Activity/Activity/getActivitiesByEventId?eventId=" + eventId;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            HttpWebResponse myResp = (HttpWebResponse)request.GetResponse();
            Stream rebut = myResp.GetResponseStream();
            StreamReader readStream = new StreamReader(rebut, Encoding.UTF8); // Pipes the stream to a higher level stream reader with the required encoding format. 
            string info = readStream.ReadToEnd();
            var ActivityList = JsonConvert.DeserializeObject<List<Activities>>(info);


            //join activity

            //string url = "http://10.0.2.2:63096/Activity/Activity/goActivity?accountId=<value>&activityId=<value>";
            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            //request.Method = "GET";
            //request.ContentType = "application/json";
            //HttpWebResponse myResp = (HttpWebResponse)request.GetResponse();
            //Stream rebut = myResp.GetResponseStream();
            //StreamReader readStream = new StreamReader(rebut, Encoding.UTF8); // Pipes the stream to a higher level stream reader with the required encoding format. 
            //string info = readStream.ReadToEnd();
            //var newAccount = JsonConvert.DeserializeObject<Account>(info);

            //end

            View view = inflater.Inflate(Resource.Layout.ActivityOptions, container, false);

            ImageView imgEvent = view.FindViewById<ImageView>(Resource.Id.imgEvent);
            var imageBitmap = Ultility.GetImageBitmapFromUrl(eventUrl);
            imgEvent.SetImageBitmap(imageBitmap);
            
            ListView listViewActivity = view.FindViewById<ListView>(Resource.Id.listActivity);
            listViewActivity.Adapter = new ActivityListAdapter(this.Activity, ActivityList);
            listViewActivity.FastScrollEnabled = true;

            return view;
        }
    }
}