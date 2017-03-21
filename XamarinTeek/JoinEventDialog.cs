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
using System.Net;
using System.IO;
using Newtonsoft.Json;
using XamarinTeek.Object;
using Android.App;

namespace XamarinTeek.Resources
{
    public class JoinEventDialog : Android.Support.V4.App.DialogFragment
    {
        Android.Support.V4.App.FragmentManager fragManager;
        Android.Support.V4.App.Fragment fragment;
        Activity context;
        Bundle myBundle;

        public JoinEventDialog(Activity context, Android.Support.V4.App.FragmentManager fragManager, Android.Support.V4.App.Fragment fragment, Bundle myBundle)
        {
            this.fragManager = fragManager;
            this.fragment = fragment;
            this.context = context;
            this.myBundle = myBundle;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.JoinEvent, container, false);


            Button btnSendCode = view.FindViewById<Button>(Resource.Id.btnSendCode);

            btnSendCode.Click += delegate
            {
                var accountId = 1; // for test

                TextView txtCode = view.FindViewById<TextView>(Resource.Id.txtCode);
                string url = Ultility.SERVER_URL += "/Event/Event/checkCode?accountId=" + accountId + "&code=" + txtCode.Text;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                request.ContentType = "application/json";
                HttpWebResponse myResp = (HttpWebResponse)request.GetResponse();
                Stream rebut = myResp.GetResponseStream();
                StreamReader readStream = new StreamReader(rebut, Encoding.UTF8); // Pipes the stream to a higher level stream reader with the required encoding format. 
                string info = readStream.ReadToEnd();
                var newAccount = JsonConvert.DeserializeObject<Account>(info);

                if (newAccount == null)
                {
                    Toast.MakeText(context, "You don't have enough points to join this event", ToastLength.Long).Show();
                }
                else
                {
                    fragment.Arguments = myBundle;
                    var trans = fragManager.BeginTransaction();
                    trans.Replace(Resource.Id.content_frame, fragment);
                    trans.AddToBackStack(null);
                    trans.Commit();
                }
            };


            return view;
        }
    }
}