using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//using Android.App;
using Android.Support.V4.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace XamarinTeek.Resources
{
    public class JoinEventDialog : DialogFragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            //string url = "http://10.0.2.2:63096/Event/Event/checkCode?accountId=<value>&code=<value>";
            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            //request.Method = "GET";
            //request.ContentType = "application/json";
            //HttpWebResponse myResp = (HttpWebResponse)request.GetResponse();
            //Stream rebut = myResp.GetResponseStream();
            //StreamReader readStream = new StreamReader(rebut, Encoding.UTF8); // Pipes the stream to a higher level stream reader with the required encoding format. 
            //string info = readStream.ReadToEnd();
            //var newAccount = JsonConvert.DeserializeObject<Account>(info);
            var view = inflater.Inflate(Resource.Layout.JoinEvent, container, false);

            TextView txtCode = view.FindViewById<TextView>(Resource.Id.txtCode);

            Button btnSendCode = view.FindViewById<Button>(Resource.Id.btnSendCode);
            btnSendCode.Click += delegate {

            };


            return view;
        }
    }
}