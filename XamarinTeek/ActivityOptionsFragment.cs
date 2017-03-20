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

            //get activity list

            //string url = "http://10.0.2.2:63096/Activity/Activity/getActivitiesByEventId?eventId=<value>";
            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            //request.Method = "GET";
            //request.ContentType = "application/json";
            //HttpWebResponse myResp = (HttpWebResponse)request.GetResponse();
            //Stream rebut = myResp.GetResponseStream();
            //StreamReader readStream = new StreamReader(rebut, Encoding.UTF8); // Pipes the stream to a higher level stream reader with the required encoding format. 
            //string info = readStream.ReadToEnd();
            //var ActivityList = JsonConvert.DeserializeObject<List<Activities>>(info);

            //end

            View view = inflater.Inflate(Resource.Layout.ActivityOptions, container, false);

            ListView listActivity = view.FindViewById<ListView>(Resource.Id.listActivity);

            ImageView imgEvent = view.FindViewById<ImageView>(Resource.Id.imgEvent);
            var imageBitmap = Ultility.GetImageBitmapFromUrl("http://www.vietcv.net/wp-content/uploads/2016/08/4fb04b7765e4.jpg");
            imgEvent.SetImageBitmap(imageBitmap);

            Activities act1 = new Activities();
            act1.imageUrl = "http://www.vietcv.net/wp-content/uploads/2016/08/4fb04b7765e4.jpg";
            act1.name = "Long long long long long long long long long long name";
            act1.prizePoint = 100;

            List<Activities> list = new List<Activities>();
            list.Add(act1);
            list.Add(act1);
            list.Add(act1);

            listActivity.Adapter = new ActivityListAdapter(this.Activity, list);
            listActivity.FastScrollEnabled = true;

            return view;
        }
    }
}