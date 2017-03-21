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

            var view = inflater.Inflate(Resource.Layout.JoinEvent, container, false);

            TextView txtCode = view.FindViewById<TextView>(Resource.Id.txtCode);

            Button btnSendCode = view.FindViewById<Button>(Resource.Id.btnSendCode);
            btnSendCode.Click += delegate {

            };


            return view;
        }
    }
}