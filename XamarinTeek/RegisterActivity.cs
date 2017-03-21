using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace XamarinTeek
{
    [Activity(Label = "RegisterActivity")]
    public class RegisterActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            this.SetContentView(Resource.Layout.Register);
           Button btnRegister = FindViewById<Button>(Resource.Id.btnRegister);
            btnRegister.Click += delegate
            {
                if (SignUp())
                {
                    StartActivity(typeof(MainLayoutActivity));
                }
                else
                {
                    Toast.MakeText(this.ApplicationContext, "Sign up fail due to invalid username or password", ToastLength.Long);
                    StartActivity(typeof(RegisterActivity));
                }
            };
        }

        public bool SignUp()
        {
            String username = FindViewById<TextView>(Resource.Id.regisUsername).Text;
            String pass = FindViewById<TextView>(Resource.Id.regisPassword).Text;

            string url = "http://10.0.2.2:63096/Account/Account/createAccount?username="+username+"&password="+pass+"";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            HttpWebResponse myResp = (HttpWebResponse)request.GetResponse();
            Stream rebut = myResp.GetResponseStream();
            StreamReader readStream = new StreamReader(rebut, Encoding.UTF8); // Pipes the stream to a higher level stream reader with the required encoding format. 
            string info = readStream.ReadToEnd();
            var success = JsonConvert.DeserializeObject<Boolean>(info);

            return success;
        }
    }
}