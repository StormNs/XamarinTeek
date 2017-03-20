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
       

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            
            
        }

        public static EventFragment NewInstance()
        {
            var eventFrag = new EventFragment { Arguments = new Bundle() };
            return eventFrag;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            //getEventList

            ////string data = "brandId=1"; //replace <value>
            ////byte[] dataStream = Encoding.UTF8.GetBytes(data);
            //string url = "http://10.0.2.2:63096/Event/Event/getEventsByBrandId?brandId=1";
            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            //request.Method = "GET";
            //request.ContentType = "application/json";
            ////request.ContentLength = dataStream.Length;
            ////Stream newStream = request.GetRequestStream();
            ////// Send the data.
            ////newStream.Write(dataStream, 0, dataStream.Length);
            ////newStream.Close();
            //HttpWebResponse myResp = (HttpWebResponse)request.GetResponse();
            //Stream rebut = myResp.GetResponseStream();
            //StreamReader readStream = new StreamReader(rebut, Encoding.UTF8); // Pipes the stream to a higher level stream reader with the required encoding format. 
            //string info = readStream.ReadToEnd();
            //var EventList = JsonConvert.DeserializeObject<List<Events>>(info);

            //end

            View view = inflater.Inflate(Resource.Layout.Event, container, false);
            var eventImg = Resource.Drawable.logo;
            var eventDescription = "Lorem Ipsum is simply dummy text of the printing and typesetting industry."
                + " Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown"
                + " printer took a galley of type and scrambled it to make a type specimen book. It has survived not"
                + " only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged."
                + " It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages,"
                + " and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.";
            var eventPoint = 5;

            ImageView imgEvent = view.FindViewById<ImageView>(Resource.Id.imgEvent);
            //imgEvent.SetBackgroundResource(eventImg);
            imgEvent.SetImageResource(eventImg);
            imgEvent.RequestLayout();

            TextView txtDescription = view.FindViewById<TextView>(Resource.Id.txtDescription);
            txtDescription.Text = eventDescription;

            

            TextView txtPoint = view.FindViewById<TextView>(Resource.Id.txtPoint);
            txtPoint.Text = "Need " + eventPoint + (eventPoint > 1 ? " point" : " points") + " to join";


            Button btnJoin = view.FindViewById<Button>(Resource.Id.btnJoin);
            btnJoin.Click += delegate
            {

                FragmentTransaction trans = FragmentManager.BeginTransaction();
                JoinEventDialog dialog = new JoinEventDialog();
                dialog.Show(trans, "JoinDialog");
            };


           
            return view;
        }

      


    }
}