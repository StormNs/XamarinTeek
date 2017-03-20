using Android.App;
using Android.Widget;
using Android.OS;
using System;
using Android.Content;
using Android.Views;
using System.Net;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace XamarinTeek
{
    [Activity(Label = "XamarinTeek", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
       
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource

            SetContentView(Resource.Layout.Main);

            //Check account

            //string url = "http://10.0.2.2:63096/Account/Account/getAccountByUsernameAndPassword?username=<value>&password=<value>";
            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            //request.Method = "GET";
            //request.ContentType = "application/json";
            //HttpWebResponse myResp = (HttpWebResponse)request.GetResponse();
            //Stream rebut = myResp.GetResponseStream();
            //StreamReader readStream = new StreamReader(rebut, Encoding.UTF8); // Pipes the stream to a higher level stream reader with the required encoding format. 
            //string info = readStream.ReadToEnd();
            //var validate = JsonConvert.DeserializeObject<Boolean>(info);

            //Signup

            //string url = "http://10.0.2.2:63096/Account/Account/createAccount?username=<value>&password=<value>";
            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            //request.Method = "GET";
            //request.ContentType = "application/json";
            //HttpWebResponse myResp = (HttpWebResponse)request.GetResponse();
            //Stream rebut = myResp.GetResponseStream();
            //StreamReader readStream = new StreamReader(rebut, Encoding.UTF8); // Pipes the stream to a higher level stream reader with the required encoding format. 
            //string info = readStream.ReadToEnd();
            //var success = JsonConvert.DeserializeObject<Boolean>(info);


            Button btnLogin = FindViewById<Button>(Resource.Id.btnLogin);
            btnLogin.Click += delegate
            {
                StartActivity(typeof(MainLayoutActivity));
            };

            Button btnSignIn = FindViewById<Button>(Resource.Id.btnSignUp);
            btnSignIn.Click += delegate
            {
                StartActivity(typeof(RegisterActivity));
            };

        }
        
    }
}

